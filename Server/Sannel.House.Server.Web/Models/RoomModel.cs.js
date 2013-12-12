var server = server || {};
server.RoomModel = function()  {
	/// <field name="RoomId" type="Object">The RoomId property as defined in Sannel.House.Server.Web.Models.RoomModel</field>
	this.RoomId = new Object();
	/// <field name="Name" type="String">The Name property as defined in Sannel.House.Server.Web.Models.RoomModel</field>
	this.Name = new String();
	/// <field name="Description" type="String">The Description property as defined in Sannel.House.Server.Web.Models.RoomModel</field>
	this.Description = new String();
	/// <field name="Color" type="String">The Color property as defined in Sannel.House.Server.Web.Models.RoomModel</field>
	this.Color = new String();
	/// <field name="Order" type="Number">The Order property as defined in Sannel.House.Server.Web.Models.RoomModel</field>
	this.Order = new Number();
	this.CircitCount = new Number();
	/// <field name="Circuits" type="Array">The Circuits property as defined in Sannel.House.Server.Web.Models.RoomModel</field>
	this.Circuits = new Array();
};

