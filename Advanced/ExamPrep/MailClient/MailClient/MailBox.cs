namespace MailClient
{
    public class MailBox
    {
        public int Capacity { get; set; }
        public List<Mail> Inbox;
        public List<Mail> Archive;

        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>(capacity);
            Archive = new List<Mail>();
        }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Inbox.Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            Mail mail = Inbox.FirstOrDefault(m => m.Sender == sender);

            if (mail != null)
            {
                Inbox.Remove(mail);
                return true;
            }

            return false;
        }

        public int ArchiveInboxMessages()
        {
            int mailsMoved = Inbox.Count;
            Archive.AddRange(Inbox);
            Inbox.Clear();
            return mailsMoved;
        }

        public string GetLongestMessage()
        {
            Mail mail = Inbox.OrderByDescending(m => m.Body.Length).First();
            return mail.ToString();
        }

        public string InboxView()
        {
            return "Inbox:"
                   + Environment.NewLine
                   + $"{string.Join(Environment.NewLine, Inbox)}";
        }
    }

}