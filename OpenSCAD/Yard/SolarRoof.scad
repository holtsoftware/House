module solarPanel()
{
    translate([0,0,1.5]) color("blue") cube([51,51,4]);
    translate([4,4,0]) color("red") cube([43,43,5]);
    translate([0,21.5,0]) color("orange") cube([51,8,5]);
}

difference()
{
    cube([140,75,5]);
    translate([17,12.25,0]) solarPanel();
    translate([70,12.25,0]) solarPanel();
}