using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Sannel.House.Client.Interfaces;
using System.Collections.ObjectModel;

namespace Sannel.House.Client.Droid
{
	public class MenuAdapter : RecyclerView.Adapter
	{
		private ObservableCollection<Tuple<String, Type>> items = new ObservableCollection<Tuple<string, Type>>();

		public MenuAdapter()
		{
			items.CollectionChanged += Items_CollectionChanged;
		}

		private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			NotifyDataSetChanged();
		}

		public override int ItemCount
		{
			get
			{
				return items.Count;
			}
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var viewHolder = (ViewHolder)holder;
			var item = items[position];
			viewHolder.MenuText.Text = item.Item1;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var vi = LayoutInflater.From(parent.Context);
			var v = vi.Inflate(Resource.Layout.MenuItemLayout, parent, false);
			var ll = v.FindViewById<LinearLayout>(Resource.Id.menuLayout);
			return new ViewHolder(ll);
		}

		internal class ViewHolder : RecyclerView.ViewHolder
		{
			internal LinearLayout Layout;
			internal TextView MenuText;
			public ViewHolder(LinearLayout ll) : base(ll)
			{
				Layout = ll;
				MenuText = ll.FindViewById<TextView>(Resource.Id.menuText);
			}
		}
	}
}