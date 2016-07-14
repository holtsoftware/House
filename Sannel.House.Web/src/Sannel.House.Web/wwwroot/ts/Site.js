/// <reference path="jquery.d.ts" />
/// <reference path="knockout.d.ts" />
var ServerDevice = (function () {
    function ServerDevice() {
    }
    return ServerDevice;
}());
var Device = (function () {
    function Device(sdevice) {
        if (sdevice === void 0) { sdevice = undefined; }
        this.Id = ko.observable(0);
        this.Name = ko.observable("");
        this.Description = ko.observable("");
        this.DisplayOrder = ko.observable(0);
        if (sdevice != undefined) {
            this.Id(sdevice.Id);
            this.Name(sdevice.Name);
            this.Description(sdevice.Description);
            this.DisplayOrder(sdevice.DisplayOrder);
        }
    }
    Device.prototype.AsServerDevice = function () {
        var sd = new ServerDevice();
        sd.Id = this.Id();
        sd.Name = this.Name();
        sd.Description = this.Description();
        sd.DisplayOrder = this.DisplayOrder();
        return sd;
    };
    return Device;
}());
var DevicesViewModel = (function () {
    function DevicesViewModel() {
        this.Devices = ko.observableArray([]);
        this.CurrentDevice = ko.observable(undefined);
        this._apiUrl = "/api/Devices";
    }
    DevicesViewModel.prototype._devicesReceived = function (data) {
        for (var i = 0; i < data.length; i++) {
            this.Devices.push(new Device(data[i]));
        }
    };
    DevicesViewModel.prototype.loadDevices = function () {
        var me = this;
        $.ajax({
            url: me._apiUrl,
            type: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                me._devicesReceived(data);
            }
        });
    };
    DevicesViewModel.prototype.loadDevice = function (id) {
        var me = this;
        $.ajax({
            url: me._apiUrl + "/" + id,
            type: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (device) {
                var found = false;
                for (var i = 0; i < me.Devices().length; i++) {
                    var d = me.Devices()[i];
                    if (d.Id() == device.Id) {
                        me.Devices.replace(d, new Device(device));
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    me.Devices.push(new Device(device));
                }
            }
        });
    };
    DevicesViewModel.prototype.AddNewDevice = function () {
        this.CurrentDevice(new Device());
    };
    DevicesViewModel.prototype.SaveNewDevice = function () {
        var cd = this.CurrentDevice();
        var errorMessage = "";
        if (cd.Name().length <= 0) {
            errorMessage = "Name is required.\n";
        }
        if (cd.Description().length <= 0) {
            errorMessage += "Description is required.\n";
        }
        if (errorMessage.length > 0) {
            alert(errorMessage);
        }
        else {
            var me = this;
            $.ajax({
                url: me._apiUrl,
                type: 'post',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(cd.AsServerDevice()),
                dataType: "json",
                success: function (id) {
                    me.loadDevice(id);
                }
            });
        }
    };
    return DevicesViewModel;
}());
