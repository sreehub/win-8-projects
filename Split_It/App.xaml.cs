using Split_It.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Split_It
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        private TransitionCollection transitions;

        private string _dBPath = string.Empty;

        public string dBPath
        {
            get { return _dBPath; }
            set
            {
                if (_dBPath == value)
                    return;
                _dBPath = value;
            }
        }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            // get a reference to SQLite database 
            dBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "split_it.sqlite");

            // initialize the database if necessary 
            using (var db = new SQLite.SQLiteConnection(dBPath))
            {
                // creates tables if they dont exist.
                db.CreateTable<Category>();
                db.CreateTable<Event>();
                db.CreateTable<Member>();
                db.CreateTable<Expense>();

                // initial data pump 

                // events
                if (db.Table<Event>().Count() == 0)
                    db.Insert(new Event() { Name = "coorg 2014" });

                // categories 
                if (db.Table<Category>().Count() == 0)
                {
                    db.Insert(new Category { Name = "Food" });
                    db.Insert(new Category { Name = "Room Rent" });
                }

                // members 
                db.DropTable<Member>();
                db.CreateTable<Member>();
                db.Insert(new Member() { EventID = 1, Name = "Sreerag", PhoneNumber = "9884593984" });
                db.Insert(new Member() { EventID = 1, Name = "Kowshick", PhoneNumber = "9884593984" });
                db.Insert(new Member() { EventID = 1, Name = "Naveen", PhoneNumber = "9884593984" });
                db.Insert(new Member() { EventID = 1, Name = "Sarat", PhoneNumber = "9884593984" });
                db.Insert(new Member() { EventID = 1, Name = "Sriram", PhoneNumber = "9884593984" });

                // expenses 
                //if (db.Table<Expense>().Count() > 0)
                //{
                db.DropTable<Expense>();
                db.CreateTable<Expense>();
                db.Insert(new Expense() { EventID = 1, MemberID = 1, CategoryID = 1, Amount = 2000, TimeStamp = DateTime.Now });
                db.Insert(new Expense() { EventID = 1, MemberID = 1, CategoryID = 2, Amount = 4000, TimeStamp = DateTime.Now });
                db.Insert(new Expense() { EventID = 1, MemberID = 1, CategoryID = 1, Amount = 2000, TimeStamp = DateTime.Now });
                db.Insert(new Expense() { EventID = 1, MemberID = 2, CategoryID = 1, Amount = 3000, TimeStamp = DateTime.Now });
                db.Insert(new Expense() { EventID = 1, MemberID = 2, CategoryID = 2, Amount = 4000, TimeStamp = DateTime.Now });
                db.Insert(new Expense() { EventID = 1, MemberID = 3, CategoryID = 2, Amount = 4000, TimeStamp = DateTime.Now });

                //}

            }

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}