/// <reference path="jquery-3.0.0.js" />
/// <reference path="knockout-3.4.0.js" />

function Device(){
    this.Id = 0;
    this.Name = "";
    this.Description = "";
}

function DevicesViewModel() {
    this.ApiUrl = "/api/devices";
    this.Devices = ko.observableArray([]);
}

DevicesViewModel.prototype.LoadDevices = function () {
    $.ajax({
        url: this.ApiUrl,
        type: 'get',
        success: function (data) {
            console.log(data);
        }
    })
}