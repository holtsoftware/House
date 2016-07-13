/// <reference path="jquery.d.ts" />
/// <reference path="knockout.d.ts" />
var DevicesViewModel = (function () {
    function DevicesViewModel() {
        this.Devices = ko.observableArray([]);
        this._apiUrl = "/api/Devices";
    }
    DevicesViewModel.prototype._devicesReceived = function (data) {
        console.log(data);
        for (var i = 0; i < data.length; i++) {
            this.Devices.push(data[i]);
        }
    };
    DevicesViewModel.prototype.loadDevices = function () {
        var me = this;
        console.log(me._apiUrl);
        $.ajax({
            url: me._apiUrl,
            type: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                me._devicesReceived(data);
            }
        });
    };
    return DevicesViewModel;
}());
