using MaterialDesignThemes.Wpf;
using System;

namespace InspectionBoardLibrary.Models
{
    public class SnackbarMessageQueue : ISnackbarMessageQueue
    {
        public void Enqueue(object content)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(object content, object actionContent, Action actionHandler)
        {
            throw new NotImplementedException();
        }

        public void Enqueue<TArgument>(object content, object actionContent, Action<TArgument> actionHandler, TArgument actionArgument)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(object content, bool neverConsiderToBeDuplicate)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(object content, object actionContent, Action actionHandler, bool promote)
        {
            throw new NotImplementedException();
        }

        public void Enqueue<TArgument>(object content, object actionContent, Action<TArgument> actionHandler, TArgument actionArgument, bool promote)
        {
            throw new NotImplementedException();
        }

        public void Enqueue<TArgument>(object content, object actionContent, Action<TArgument> actionHandler, TArgument actionArgument, bool promote, bool neverConsiderToBeDuplicate, TimeSpan? durationOverride = null)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(object content, object actionContent, Action<object> actionHandler, object actionArgument, bool promote, bool neverConsiderToBeDuplicate, TimeSpan? durationOverride = null)
        {
            throw new NotImplementedException();
        }
    }
}
