using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Provider;

namespace GroceryList
{
	[Activity(Label = "About")]			
	public class AboutActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.About);

			FindViewById<Button>(Resource.Id.learnMoreButton).Click += OnLearnMoreClick;
			FindViewById<Button>(Resource.Id.camera).Click += OnCameraClick;
			FindViewById<Button>(Resource.Id.map).Click += OnMapClick;
			FindViewById<Button>(Resource.Id.email).Click += OnEmailClick;
        }
        //Learn More
        void OnLearnMoreClick(object sender, EventArgs e)
		{
            // TODO
            //set a web address , and parse it from a string to a uri using android.net.uri. 
            var webUri = Android.Net.Uri.Parse("https://www.youtube.com/channel/UCsinMWgI7pXJQGc0gwMXimg/featured");
            //instanciate an implicit intent and load it with the action and the data
            var intent  = new Intent(Intent.ActionView,webUri);
            
            //or 

            //var intent = new Intent();
            //intent.SetAction(Intent.ActionView);
            //intent.SetData(webUri);

            //start the activity if android finds an acivity to handle my request.
            if(intent.ResolveActivity(PackageManager) != null)
            {
                StartActivity(intent);
            }
		}
        //Camera
        void OnCameraClick(object sender, EventArgs e)
        {
            //import android provider to get accesse to this activity.
            var intent = new Intent(MediaStore.ActionImageCapture);

            if(intent.ResolveActivity(PackageManager) != null)
            {
                StartActivity(intent);
            }
        }

       //email 
       void OnEmailClick(object sender , EventArgs e)
        {
            //var intent = new Intent(Intent.ActionSendto);
            // tells android to use only email apps to service this request
            //intent.SetData(Android.Net.Uri.Parse("mailto"));
            //intent.PutExtra(Intent.ExtraEmail, new string[] { "sendTo@email.com" });
            //intent.PutExtra(Intent.ExtraSubject, "how are you?");

            //or
            // intent with an action to open the email activity.
            var intent = new Intent(Android.Content.Intent.ActionSend);
            // load the intent with extra data such as the email address
            intent.PutExtra(Android.Content.Intent.ExtraEmail,
                new string[] { "person1@gmail.com", "person2@gmail.com" });
            // more data
            intent.PutExtra(Android.Content.Intent.ExtraCc, new string[] {"person3@gmail.com" });
            //more data such as the subject
            intent.PutExtra(Android.Content.Intent.ExtraSubject, "hello there!");
            //more data such as the text inside the email text body
            intent.PutExtra(Android.Content.Intent.ExtraText,
                "hello from jay i hope this repo is helping you to learn xamarin androind");
            //set the mime type to maessage to limit the activites that android have to chose from. 
            intent.SetType("message/rfc822");
            // start activity.
            if (intent.ResolveActivity(PackageManager) != null)
            {
                StartActivity(intent);
            }
        }


        //Maps
        void OnMapClick(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("geo:37.7576792,-122.5078119,12z"));
            
            if (intent.ResolveActivity(PackageManager)!= null)
            {
                StartActivity(intent);
            }
        }
    }
}