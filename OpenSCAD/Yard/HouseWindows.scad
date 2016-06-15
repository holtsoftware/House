module doorWindow()
{
translate([1.5,1.5,0]) cube([20,20,4]);
cube([23,23,2]);
}

module window()
{
translate([1.5,1.5,0]) cube([35,20,4]);
cube([38,23,2]);
}

window();

translate([0, 30,0]) doorWindow();