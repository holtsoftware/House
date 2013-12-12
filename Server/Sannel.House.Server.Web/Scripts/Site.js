/// <reference path="_references.js" />

var mainContainer = document.getElementById("MainContainer");


function GlobalViewModel()
{
	var self = this;
	self.folders = ['Index', 'Register'];
	self.chosenFolderId = ko.observable();
	self.loginInfo = ko.observable({
		'Username': '',
		'DisplayName': '',
		'EmailAddress': '',
		'IsAllowed': false,
		'IsAdmin': false
	});

	self.registeredUser = ko.observable(new RegisterViewModel());
	self.loginUser = ko.observable(new LoginViewModel());
	self.rooms = ko.observable(new RoomsModelView());

	self.errorDialog = {
		Title: ko.observable(""),
		Body: ko.observable(""),
		Action: ko.observable(function () { }),
		ActionActivate: function () { self.errorDialog.Action()(); },
		ActionText: ko.observable("Ok")
	};

	self.closePopup = function ()
	{
		$("div.popup.active").removeClass("active");
	};


	self.loadSection = function (section)
	{
		$(".active").removeClass("active");
		if (section == 'Register')
		{
			$("#RegisterUser").addClass("active");
		}
		else if(section == 'Login')
		{
			$("#Login").addClass("active");
		}
		else if(section == 'Error')
		{
			$("#Error").addClass("active");
		}
		else if(section == "Rooms")
		{
			$("#Rooms").addClass("active");
			if (!self.rooms().Loaded())
			{
				$.ajax({
					url: GetRoomsApiUrl("GetRooms"),
					success: function(data)
					{
						if(data)
						{
							self.rooms().FillRooms(data);
						}
					},
					error: function(error)
					{
						if (error.responseText)
						{
							var obj = $.parseJSON(error.responseText);
							self.showErrorDialog("Error", obj.Message, function ()
							{
								self.loadSection("Login");
							}, "Login");
						}
						else
						{
							self.loadSection("Login");
						}
					}
				})
			}
		}
	};

	self.fillUserInfo = function ()
	{
		$.ajax({
			url: GetAuthenticationApiUrl("GetUserInfo"),
			success: function(data)
			{
				if(data)
				{
					self.loginInfo(data);
					if (data.IsAllowed)
					{
						self.loadSection("Rooms")
					}
					else
					{
						self.showErrorDialog("Access Denied", "You do not have access to this site.", function ()
						{
							self.loadSection("Login");
						}, "Login");
					}
				}
				else
				{
					self.loadSection("Login");
				}
			},
			error: function(error)
			{
				if (error.responseText)
				{
					var obj = $.parseJSON(error.responseText);
					self.showErrorDialog("Error", obj.Message, function ()
					{
						self.loadSection("Login");
					}, "Login");
				}
				else
				{
					self.loadSection("Login");
				}
			}
		});
	};

	self.showErrorDialog= function(title, body, action, actionText)
	{
		self.errorDialog.Title(title);
		self.errorDialog.Body(body);
		self.errorDialog.Action(action);
		self.errorDialog.ActionText(actionText);
		self.loadSection("Error");
	};
}

ko.bindingHandlers.cssClass = {
	/*init: function (element, valueAccessor, allBindings, viewModel, bindingContext)
	{

	},*/
	update: function (element, valueAccessor, allBindings, viewModel, bindingContext)
	{
		console.log(viewModel);
		var value = valueAccessor();

		element.className = value;
	}
};

var gvm = new GlobalViewModel();
var siteHub;

if (!String.prototype.trim)
{
	mainContainer.className = "notSupported";
}
else
{
	$(document).ready(function ()
	{
		gvm.loadSection("Login");
		ko.applyBindings(gvm);
		$(".dropdown").each(function ()
		{
			var dd = $(this);
			var selected = dd.find(".selected");
			var options = dd.find(".options");
			var hiddenField = $("#" + dd.attr("data-hidden-input"));
			selected.click(function ()
			{
				options.addClass("active");
			});

			hiddenField.change(function ()
			{
				var item = options.find("[data-value='" + hiddenField.val() + "']");
				if(item.length > 0)
				{
					selected.attr("data-value", hiddenField.val());
					selected.html(item.html());
				}
			});

			options.find("div").click(function ()
			{
				var $this = $(this);
				hiddenField.val($this.attr("data-value")).change();
				options.removeClass("active");
			});
		});
	});

	siteHub = $.connection.siteHub;
	siteHub.client.roomAdded = function (room)
	{
		/// <param name="room" type="server.RoomModel"></param>
		gvm.rooms().RoomUpdated(room);
	};

	$.connection.hub.start();
}