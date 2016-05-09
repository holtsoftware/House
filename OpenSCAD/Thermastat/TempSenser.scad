
difference()
{
    cube([15,20,14]);
    translate([2,1,1]) cube([11,20,13.15]);
    color("blue") translate([2,7,0]) cube([11,4,13.15]);

color("blue") translate([3,-1,1]) cube([1,5,10]);
    color("blue") translate([5,-1,1]) cube([1,5,10]);
    color("blue") translate([7,-1,1]) cube([1,5,10]);
    color("blue") translate([9,-1,1]) cube([1,5,10]);
    color("blue") translate([11,-1,1]) cube([1,5,10]);
    color("orange") translate([4,1,0]) cube([3,2,3]);
}
color("red") cube([3,2,10]);
color("red") translate([1,4,0]) cube([2,2,10]);
color("red") translate([12,0,0]) cube([2,2,10]);
color("red") translate([12,4,0]) cube([2,2,10]);
translate([0,5.5,0]) cube([13,2,10]);


// Tall 13.15
// Width 10.47
// thick 1.67
