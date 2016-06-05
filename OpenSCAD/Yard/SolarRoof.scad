module solarPanel()
{
    translate([0,0,1.5]) color("blue") cube([49.5,49.5,4]);
    translate([3.25,3.25,0]) color("red") cube([43,43,5]);
    translate([0,20.5,0]) color("orange") cube([49.5,8,5]);
}

difference()
{
    cube([140,75,5]);
    translate([18,12.25,0]) solarPanel();
    translate([73,12.25,0]) solarPanel();
}