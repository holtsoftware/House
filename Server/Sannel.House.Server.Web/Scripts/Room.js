/*
Copyright 2013 Sannel Software, L.L.C.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
/// <reference path="_references.js" />

function GetRoomsApiUrl(method)
{
	return "/api/Rooms/" + method;
}

function ValidateAddRoom(room)
{
	/// <param name="room" type="RoomModelView" />
	var isValid = true;
	var addRoomPopup = $("#AddRoomPopup");
	var tmp = room.Name().trim();
	if (tmp.length < 1 || tmp.length > 256)
	{
		addRoomPopup.find("[data-field=Name").addClass("hasError");
		isValid = false;
	}
	else
	{
		addRoomPopup.find("[data-field=Name].hasError").removeClass("hasError");
	}

	tmp = room.Color().trim();
	if (tmp.length > 25)
	{
		addRoomPopup.find("[data-field=Color]").addClass("hasError");
		isValid = false;
	}
	else
	{
		addRoomPopup.find("[data-field=Color].hasError").removeClass("hasError");
	}

	return isValid;
}

function RoomModelView()
{
	var self = this;
	self.RoomId = ko.observable();
	self.Name = ko.observable();
	self.Description = ko.observable();
	self.Color = ko.observable();
	self.Order = ko.observable();
	self.CircitCount = ko.observable();
	self.IsLoading = ko.observable(false);

	self.AddAction = function (item)
	{
		/// <param name="item" type="RoomModelView" />
		if (ValidateAddRoom(item))
		{
			item.IsLoading(true);
			$.ajax({
				url: GetRoomsApiUrl("AddRoom"),
				method: "POST",
				data: {
					Name: item.Name(),
					Description: item.Description(),
					Color: item.Color()
				},
				success: function(data)
				{
					item.IsLoading(false);
					gvm.closePopup();
				},
				error: function()
				{
					item.IsLoading(false);
					gvm.showErrorDialog("Error", "Error Adding Room", function ()
					{
						gvm.loadSection("Rooms");
					}, "Go Back");
				}
			});
		}
	};
}

function RoomsModelView()
{
	var self = this;
	self.Loaded = ko.observable(false);
	self.Rooms = ko.observableArray();

	self.CurrentRoom = ko.observable(new RoomModelView());

	self.OpenAddRoomAction = function ()
	{
		$("#AddRoomPopup.popup").addClass("active");
	};

	self.FillRooms = function (data)
	{
		/// <param name="data" type="Array"></param>
		for(var j=0;j<data.length;j++)
		{
			self.Rooms.push(data[j]);
		}
	};

	self.RoomUpdated = function (room)
	{
		/// <param name="room" type="server.RoomModel"></param>
		var r;
		var found = undefined;
		for(var i=0;i<self.Rooms.length;i++)
		{
			r = self.Rooms()[i];
			if(room.RoomId == r.RoomId)
			{
				r = found;
				break;
			}
		}

		if(!found)
		{
			found = new RoomModelView();
			found.RoomId(room.RoomId);
			self.Rooms.push(found);
		}

		found.Name(room.Name);
		found.Description(room.Description);
		found.Color(room.Color);
		found.Order(room.Order);
		found.CircitCount(room.CircitCount);
	};
}