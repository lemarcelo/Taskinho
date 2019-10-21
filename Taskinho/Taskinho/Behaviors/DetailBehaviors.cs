using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Taskinho.Behaviors
{
    public class DetailBehaviors : Behavior<ContentPage>
    {
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
