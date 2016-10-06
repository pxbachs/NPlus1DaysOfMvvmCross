using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using System.IO;

namespace CollectABull.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
			var path = System.Environment.GetFolderPath(
						System.Environment.SpecialFolder.Personal);
			var dbfile = "mydb.sqlite";

			var dbpath = Path.Combine(path, dbfile);

			System.Diagnostics.Debug.WriteLine("DB path = " + dbpath);

			//TODO: create if not exist
			if (!File.Exists(dbpath))
			{
				//copy file db from resource
				System.Diagnostics.Debug.WriteLine("DB path = " + dbpath + " exist!");
				//testing
				File.Delete(dbpath);
			}
			else {


			}
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

    }
}
