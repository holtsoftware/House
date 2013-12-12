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

function GetAuthenticationUrl(method)
{
	return "/Home/" + method;
}

function GetAuthenticationApiUrl(method)
{
	return "/api/Authentication/" + method;
}

// #region Login

function LoginIsValid(user)
{
	/// <param name="user" type="LoginViewModel" />
	var isValid = true;
	var login = $("#Login");
	var tmp = user.Username.trim();
	if(tmp.length < 3 || tmp.length > 256)
	{
		login.find("[data-field='Username']").addClass("hasError");
		isValid = false;
	}
	else
	{
		login.find("[data-field='Username'].hasError").removeClass("hasError");
	}

	return isValid;
}

function LoginViewModel()
{
	var self = this;
	self.Username = '';
	self.Password = '';
	self.IsLoading = ko.observable(false);
	this.LoginAction = function (item)
	{
		/// <param name="item" type="LoginViewModel" />
		if (item)
		{
			self.IsLoading(true);
			$.ajax({
				url: GetAuthenticationUrl("Login"),
				data:
					{
						"Username": item.Username,
						"Password": item.Password
					},
				method: "POST",
				success: function (data)
				{
					self.IsLoading(false);
					if (data === true)
					{
						gvm.fillUserInfo();
					}
					else
					{
						$("#Login [data-field='Username']").addClass("hasError");
					}
				},
				error: function (error)
				{
					gvm.showErrorDialog("Error", "Error Logging in. Please try again.", function ()
					{
						gvm.loadSection("Register");
					}, "Try Again");
					self.IsLoading(false);
				}
			});
		}

		return false;
	};

	this.RegisterAction = function(item)
	{
		gvm.loadSection("Register");
	}
}

// #endregion

// #region Register
function RegisterIsValid(user)
{
	/// <param name="user" type="RegisterViewModel"></param>
	var isValid = true;
	var registerUser = $("#RegisterUser");

	var tmp = user.Username().trim();

	if (tmp.length < 3 || tmp.length > 256)
	{
		registerUser.find("[data-field='Username']").addClass("hasError");
		isValid = false;
	}
	else
	{
		$.ajax({
			url: GetAuthenticationApiUrl("CheckUsername") + "/" + tmp,
			async: false,
			method: "POST",
			success: function (data)
			{
				if (data === true)
				{
					registerUser.find("[data-field='Username']").addClass("hasError2");
					isValid = false;
				}
				else
				{
					registerUser.find("[data-field='Username'].hasError2").removeClass("hasError2");
				}
			}
		});
		registerUser.find("[data-field='Username'].hasError").removeClass("hasError");
	}

	tmp = user.DisplayName;

	if (tmp.length < 3 || tmp.length > 256)
	{
		registerUser.find("[data-field='DisplayName']").addClass("hasError");
		isValid = false;
	}
	else
	{
		registerUser.find("[data-field='DisplayName'].hasError").removeClass("hasError");
	}

	tmp = user.EmailAddress;

	if (!/\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}\b/.test(tmp))
	{
		registerUser.find("[data-field='EmailAddress']").addClass("hasError");
		isValid = false;
	}
	else
	{
		registerUser.find("[data-field='EmailAddress'].hasError").removeClass("hasError");
	}

	tmp = user.Password;
	if (tmp.length < 4 || tmp.length > 500)
	{
		registerUser.find("[data-field='Password']").addClass("hasError");
		isValid = false;
	}
	else
	{
		registerUser.find("[data-field='Password'].hasError").removeClass("hasError");
	}

	if (user.Password != user.ConfirmPassword)
	{
		registerUser.find("[data-field='ConfirmPassword']").addClass("hasError");
		isValid = false;
	}
	else
	{
		registerUser.find("[data-field='ConfirmPassword'].hasError").removeClass("hasError");
	}

	return isValid;
}

function RegisterViewModel()
{
	var self = this;
	self.Username = ko.observable('');
	self.DisplayName = '';
	self.EmailAddress = '';
	self.Password = '';
	self.ConfirmPassword = '';
	self.IsLoading = ko.observable(false);

	self.Login = function ()
	{
		gvm.loadSection("Login");
	};

	self.AddUser = function (item)
	{
		/// <param name="item" type="RegisterViewModel"></param>

		if (!item)
		{
			return;
		}

		if (RegisterIsValid(item))
		{
			item.IsLoading(true);
			$.ajax({
				url: GetAuthenticationUrl("RegisterUser"),
				method: "POST",
				data: {
					'Username': item.Username(),
					'DisplayName': item.DisplayName,
					'EmailAddress': item.EmailAddress,
					'Password': item.Password
				},
				success: function(data)
				{
					if (data === true)
					{
						gvm.fillUserInfo();
						item.IsLoading(false);
					}
					else if(data.length > 0)
					{
						var message = "";
						for(var i=0;i<data.length;i++)
						{
							message += data[i] + "<br />";
						}

						gvm.showErrorDialog("Error", message, function ()
						{
							gvm.loadSection("Register");
						}, "Go Back");

						item.IsLoading(false);
					}
					else
					{
						item.IsLoading(false);
					}
				},
				error: function()
				{
					gvm.showErrorDialog("Error", "Error registering user. Please try again.", function ()
					{
						gvm.loadSection("Register");
					}, "Try Again");
					item.IsLoading(false);
				}
			})
		}
	};
}
// #endregion