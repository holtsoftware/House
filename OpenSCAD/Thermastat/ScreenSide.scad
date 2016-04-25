$fn=300;
module piDisplayHoles()
{
cylinder(d=3,h=5);
translate([65.4,0,0]) cylinder(d=3,h=5);
translate([0,126.1,0]) cylinder(d=3,h=5);
translate([65.4,126.1,0]) cylinder(d=3,h=5);
}

difference()
{
    
cube([86,154,2]);
translate([10.3,13.95,0]) color("blue") piDisplayHoles();translate([10.5,19,0]) color("orange") cube([65,116,4]);
}



//65.4(5.6) 131.7 - 5.6(126.1)

//77 63.05

//43 32.7

// 77 58

// 43 32.5 