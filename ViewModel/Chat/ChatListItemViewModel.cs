namespace NewProject
{
    /// <summary>
    /// a view model for chat list in the overview chat list
    /// </summary>
    public class ChatListItemViewModel:BaseViewModel
    {
        
        public string Name { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        //True if there are unread message in this chat
        public bool NewContentAvailable { get; set; }

        //True(if this item is selected)
        public bool IsSelected { get; set; }
    }
}
