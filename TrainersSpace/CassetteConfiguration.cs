using Cassette;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace TrainersSpace
{
    /// <summary>
    /// Configures the Cassette asset modules for the web application.
    /// </summary>
    public class CassetteConfiguration : IConfiguration<BundleCollection>
    {
        public void Configure(BundleCollection bundles)
        {
            // Call bundles.Add methods here, same as in v1
            bundles.AddPerSubDirectory<ScriptBundle>("Content/js");
            bundles.Add<StylesheetBundle>("Content/less/style.less");
            //bundles.Add<StylesheetBundle>("Content/less/bootstrap/bootstrap.less");
        }
    }
}