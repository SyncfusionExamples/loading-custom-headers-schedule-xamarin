using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulePageBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        Label label;
       
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            
            this.schedule = bindable.FindByName<SfSchedule>("schedule");
            this.label = bindable.FindByName<Label>("label");
            this.WireEvents();
        }

        private void WireEvents()
        {
            schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
        }
        private void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            List<DateTime> dateList = new List<DateTime>();
            dateList = (e.visibleDates);
            var headerString = String.Empty;
            var item = dateList[0];
            if (schedule.ScheduleView == ScheduleView.DayView)
            {
                item = dateList[0];
                headerString = item.Date.ToString("MMMM, yyyy");
                label.Text = headerString.ToUpper();
            }
            else
            {
                item = dateList[dateList.Count / 2];
                headerString = item.Date.ToString("MMMM, yyyy");
                label.Text = headerString.ToUpper();
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }
        private void UnWireEvents()
        {
            schedule.VisibleDatesChangedEvent -= Schedule_VisibleDatesChangedEvent;
        }
    }
}
    