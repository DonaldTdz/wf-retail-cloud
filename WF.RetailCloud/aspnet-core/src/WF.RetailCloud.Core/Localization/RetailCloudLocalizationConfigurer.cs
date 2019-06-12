using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace WF.RetailCloud.Localization
{
    public static class RetailCloudLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(RetailCloudConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(RetailCloudLocalizationConfigurer).GetAssembly(),
                        "WF.RetailCloud.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

