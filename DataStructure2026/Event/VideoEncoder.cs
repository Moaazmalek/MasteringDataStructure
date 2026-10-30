using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure2026.Event
{
    public class VideoEventArgs: EventArgs
    {
        public Video  Video { get; set; }
    }
    public class VideoEncoder
    {
        //1- Define a delegate 
        //2- Define an event based on that delegate
        //3- Raise the event

        //Event handler
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        public event VideoEncodedEventHandler VideoEncoded;// happend and finished in past
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video....");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }
        //event publisher event
        protected virtual void OnVideoEncoded(Video video)
        {
            if(VideoEncoded !=null)
                VideoEncoded(this,new VideoEventArgs() {  Video=video });

            
        }
    }
}
