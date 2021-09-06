namespace UtopiaCity.Models.TimelineModel.CollectionDataModel
{
    public class Breadcrums
    {
        public Breadcrums() { }

        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool Active { get; set; }

        public Breadcrums(string text, string action, string controller, bool active)
        {
            this.Text = text;
            this.Action = action;
            this.Controller = controller;
            this.Active = active;
        }
    }
}
