module solarPanel()
{
    translate([0,0,1.75]) color("blue") cube([49,49,3.25]);
    translate([3,3,0]) color("red") cube([43,43,5]);
    translate([0,20.5,0]) color("orange") cube([49,8,5]);
}

difference()
{
    cube([140,75,5]);
    translate([19,12.25,0]) solarPanel();
    translate([70,12.25,0]) solarPanel();
}