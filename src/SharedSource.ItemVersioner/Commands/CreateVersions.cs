using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System.Collections.Specialized;

namespace SharedSource.ItemVersioner.Commands
{
    /// <summary>
    /// Class for creating versions in each language.
    /// </summary>
    public class CreateVersions : Command
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="context">The current context.</param>
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            if (context.Items.Length != 1) return;
            
            Item item = context.Items[0];
            var nameValueCollection = new NameValueCollection();
            nameValueCollection["id"] = item.ID.ToString();
            nameValueCollection["language"] = item.Language.ToString();
            nameValueCollection["version"] = item.Version.ToString();
            Sitecore.Context.ClientPage.Start(this, "Run", nameValueCollection); 
        }

        /// <summary>
        /// Get the state of the command. The command is always visible, but disabled if
        /// there is already a version in each language or if the user has no permission
        /// to edit the item.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <returns>State of the command.</returns>
        public override CommandState QueryState(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");

            if (context.Items.Length != 1)
            {
                return CommandState.Hidden;
            }

            Item item = context.Items[0];

            if (!Sitecore.Context.IsAdministrator && (!item.Access.CanWrite() || (!item.Locking.CanLock() && !item.Locking.HasLock())))
            {
                return CommandState.Disabled;
            }

            foreach (Language language in LanguageManager.GetLanguages(item.Database))
            {
                Item itemInLanguage = ItemManager.GetItem(item.ID, language, Sitecore.Data.Version.Latest, item.Database);
                if (itemInLanguage.Versions.GetVersions().Length == 0)
                {
                    return CommandState.Enabled;
                }
            }

            return CommandState.Disabled;
        }


        /// <summary>
        /// Runs the command and create a version in each language where no version
        /// already exists.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void Run(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            
            string itemId = args.Parameters["id"];
            string itemLanguage = args.Parameters["language"];
            string itemVersion = args.Parameters["version"];
            
            Item item = Sitecore.Context.ContentDatabase.Items[itemId, Language.Parse(itemLanguage), Sitecore.Data.Version.Parse(itemVersion)];
            if (!Sitecore.Context.IsAdministrator && (!item.Access.CanWrite() || (!item.Locking.CanLock() && !item.Locking.HasLock())))
            {
                return;
            }

            if (item == null)
            {
                SheerResponse.Alert("Item not found.", new string[0]);
                return;
            }

            if (!SheerResponse.CheckModified())
            {
                return;
            }


            foreach (Language language in LanguageManager.GetLanguages(item.Database))
            {
                Item itemInLanguage = ItemManager.GetItem(item.ID, language, Sitecore.Data.Version.Latest, item.Database);
                if (itemInLanguage.Versions.GetVersions().Length == 0)
                {
                    Log.Audit(this, "Add version: {0}", new string[]
			        {
				        AuditFormatter.FormatItem(itemInLanguage)
			        });
                    
                    Item newVersion = itemInLanguage.Versions.AddVersion();

                    Sitecore.Context.ClientPage.SendMessage(this, string.Concat(new object[]
				    {
					    "item:versionadded(id=",
					    newVersion.ID,
					    ",version=",
					    newVersion.Version,
					    ",language=",
					    newVersion.Language,
					    ")"
				    }));
                }
            }
        }
    }
}