//Maya ASCII 2013 scene
//Name: bat_attack.ma
//Last modified: Sat, Jul 12, 2014 02:49:31 PM
//Codeset: 1252
requires maya "2013";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2013";
fileInfo "version" "2013 x64";
fileInfo "cutIdentifier" "201202220241-825136";
fileInfo "osv" "Microsoft Windows 7 Home Premium Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
createNode clipLibrary -n "clipLibrary1";
	setAttr -s 270 ".cel[0].cev";
	setAttr ".cd[0].cm" -type "characterMapping" 270 "left_paw_01.scaleZ" 0 
		1 "left_paw_01.scaleY" 0 2 "left_paw_01.scaleX" 0 3 "left_paw_01.rotateZ" 
		2 1 "left_paw_01.rotateY" 2 2 "left_paw_01.rotateX" 2 3 "left_paw_01.translateZ" 
		1 1 "left_paw_01.translateY" 1 2 "left_paw_01.translateX" 1 
		3 "right_paw_02.scaleZ" 0 4 "right_paw_02.scaleY" 0 5 "right_paw_02.scaleX" 
		0 6 "right_paw_02.rotateZ" 2 4 "right_paw_02.rotateY" 2 
		5 "right_paw_02.rotateX" 2 6 "right_paw_02.translateZ" 1 4 "right_paw_02.translateY" 
		1 5 "right_paw_02.translateX" 1 6 "right_paw_01.scaleZ" 0 
		7 "right_paw_01.scaleY" 0 8 "right_paw_01.scaleX" 0 9 "right_paw_01.rotateZ" 
		2 7 "right_paw_01.rotateY" 2 8 "right_paw_01.rotateX" 2 
		9 "right_paw_01.translateZ" 1 7 "right_paw_01.translateY" 1 8 "right_paw_01.translateX" 
		1 9 "back_wing_left_02.scaleZ" 0 10 "back_wing_left_02.scaleY" 
		0 11 "back_wing_left_02.scaleX" 0 12 "back_wing_left_02.rotateZ" 
		2 10 "back_wing_left_02.rotateY" 2 11 "back_wing_left_02.rotateX" 
		2 12 "back_wing_left_02.translateZ" 1 10 "back_wing_left_02.translateY" 
		1 11 "back_wing_left_02.translateX" 1 12 "back_wing_left_01.scaleZ" 
		0 13 "back_wing_left_01.scaleY" 0 14 "back_wing_left_01.scaleX" 
		0 15 "back_wing_left_01.rotateZ" 2 13 "back_wing_left_01.rotateY" 
		2 14 "back_wing_left_01.rotateX" 2 15 "back_wing_left_01.translateZ" 
		1 13 "back_wing_left_01.translateY" 1 14 "back_wing_left_01.translateX" 
		1 15 "tail_02.scaleZ" 0 16 "tail_02.scaleY" 0 17 "tail_02.scaleX" 
		0 18 "tail_02.rotateZ" 2 16 "tail_02.rotateY" 2 17 "tail_02.rotateX" 
		2 18 "tail_02.translateZ" 1 16 "tail_02.translateY" 1 17 "tail_02.translateX" 
		1 18 "tail_01.scaleZ" 0 19 "tail_01.scaleY" 0 20 "tail_01.scaleX" 
		0 21 "tail_01.rotateZ" 2 19 "tail_01.rotateY" 2 20 "tail_01.rotateX" 
		2 21 "tail_01.translateZ" 1 19 "tail_01.translateY" 1 20 "tail_01.translateX" 
		1 21 "back_wing_right_02.scaleZ" 0 22 "back_wing_right_02.scaleY" 
		0 23 "back_wing_right_02.scaleX" 0 24 "back_wing_right_02.rotateZ" 
		2 22 "back_wing_right_02.rotateY" 2 23 "back_wing_right_02.rotateX" 
		2 24 "back_wing_right_02.translateZ" 1 22 "back_wing_right_02.translateY" 
		1 23 "back_wing_right_02.translateX" 1 24 "back_wing_right_01.scaleZ" 
		0 25 "back_wing_right_01.scaleY" 0 26 "back_wing_right_01.scaleX" 
		0 27 "back_wing_right_01.rotateZ" 2 25 "back_wing_right_01.rotateY" 
		2 26 "back_wing_right_01.rotateX" 2 27 "back_wing_right_01.translateZ" 
		1 25 "back_wing_right_01.translateY" 1 26 "back_wing_right_01.translateX" 
		1 27 "jaw.scaleZ" 0 28 "jaw.scaleY" 0 29 "jaw.scaleX" 
		0 30 "jaw.rotateZ" 2 28 "jaw.rotateY" 2 29 "jaw.rotateX" 
		2 30 "jaw.translateZ" 1 28 "jaw.translateY" 1 29 "jaw.translateX" 
		1 30 "mouth_corner_left.scaleZ" 0 31 "mouth_corner_left.scaleY" 
		0 32 "mouth_corner_left.scaleX" 0 33 "mouth_corner_left.rotateZ" 
		2 31 "mouth_corner_left.rotateY" 2 32 "mouth_corner_left.rotateX" 
		2 33 "mouth_corner_left.translateZ" 1 31 "mouth_corner_left.translateY" 
		1 32 "mouth_corner_left.translateX" 1 33 "mouth_corner_right.scaleZ" 
		0 34 "mouth_corner_right.scaleY" 0 35 "mouth_corner_right.scaleX" 
		0 36 "mouth_corner_right.rotateZ" 2 34 "mouth_corner_right.rotateY" 
		2 35 "mouth_corner_right.rotateX" 2 36 "mouth_corner_right.translateZ" 
		1 34 "mouth_corner_right.translateY" 1 35 "mouth_corner_right.translateX" 
		1 36 "right_wing_02_bat.scaleZ" 0 37 "right_wing_02_bat.scaleY" 
		0 38 "right_wing_02_bat.scaleX" 0 39 "right_wing_02_bat.rotateZ" 
		2 37 "right_wing_02_bat.rotateY" 2 38 "right_wing_02_bat.rotateX" 
		2 39 "right_wing_02_bat.translateZ" 1 37 "right_wing_02_bat.translateY" 
		1 38 "right_wing_02_bat.translateX" 1 39 "right_wing_01_bat.scaleZ" 
		0 40 "right_wing_01_bat.scaleY" 0 41 "right_wing_01_bat.scaleX" 
		0 42 "right_wing_01_bat.rotateZ" 2 40 "right_wing_01_bat.rotateY" 
		2 41 "right_wing_01_bat.rotateX" 2 42 "right_wing_01_bat.translateZ" 
		1 40 "right_wing_01_bat.translateY" 1 41 "right_wing_01_bat.translateX" 
		1 42 "right_shoulder_bat.scaleZ" 0 43 "right_shoulder_bat.scaleY" 
		0 44 "right_shoulder_bat.scaleX" 0 45 "right_shoulder_bat.rotateZ" 
		2 43 "right_shoulder_bat.rotateY" 2 44 "right_shoulder_bat.rotateX" 
		2 45 "right_shoulder_bat.translateZ" 1 43 "right_shoulder_bat.translateY" 
		1 44 "right_shoulder_bat.translateX" 1 45 "left_wing_02_bat.scaleZ" 
		0 46 "left_wing_02_bat.scaleY" 0 47 "left_wing_02_bat.scaleX" 0 
		48 "left_wing_02_bat.rotateZ" 2 46 "left_wing_02_bat.rotateY" 2 
		47 "left_wing_02_bat.rotateX" 2 48 "left_wing_02_bat.translateZ" 1 
		46 "left_wing_02_bat.translateY" 1 47 "left_wing_02_bat.translateX" 
		1 48 "left_wing_01_bat.scaleZ" 0 49 "left_wing_01_bat.scaleY" 0 
		50 "left_wing_01_bat.scaleX" 0 51 "left_wing_01_bat.rotateZ" 2 
		49 "left_wing_01_bat.rotateY" 2 50 "left_wing_01_bat.rotateX" 2 
		51 "left_wing_01_bat.translateZ" 1 49 "left_wing_01_bat.translateY" 
		1 50 "left_wing_01_bat.translateX" 1 51 "left_shoulder_bat.scaleZ" 
		0 52 "left_shoulder_bat.scaleY" 0 53 "left_shoulder_bat.scaleX" 
		0 54 "left_shoulder_bat.rotateZ" 2 52 "left_shoulder_bat.rotateY" 
		2 53 "left_shoulder_bat.rotateX" 2 54 "left_shoulder_bat.translateZ" 
		1 52 "left_shoulder_bat.translateY" 1 53 "left_shoulder_bat.translateX" 
		1 54 "ear_left_02.scaleZ" 0 55 "ear_left_02.scaleY" 0 56 "ear_left_02.scaleX" 
		0 57 "ear_left_02.rotateZ" 2 55 "ear_left_02.rotateY" 2 56 "ear_left_02.rotateX" 
		2 57 "ear_left_02.translateZ" 1 55 "ear_left_02.translateY" 1 
		56 "ear_left_02.translateX" 1 57 "ear_left_01.scaleZ" 0 58 "ear_left_01.scaleY" 
		0 59 "ear_left_01.scaleX" 0 60 "ear_left_01.rotateZ" 2 58 "ear_left_01.rotateY" 
		2 59 "ear_left_01.rotateX" 2 60 "ear_left_01.translateZ" 1 
		58 "ear_left_01.translateY" 1 59 "ear_left_01.translateX" 1 60 "ear_right_02.scaleZ" 
		0 61 "ear_right_02.scaleY" 0 62 "ear_right_02.scaleX" 0 63 "ear_right_02.rotateZ" 
		2 61 "ear_right_02.rotateY" 2 62 "ear_right_02.rotateX" 2 
		63 "ear_right_02.translateZ" 1 61 "ear_right_02.translateY" 1 62 "ear_right_02.translateX" 
		1 63 "ear_right_01.scaleZ" 0 64 "ear_right_01.scaleY" 0 65 "ear_right_01.scaleX" 
		0 66 "ear_right_01.rotateZ" 2 64 "ear_right_01.rotateY" 2 
		65 "ear_right_01.rotateX" 2 66 "ear_right_01.translateZ" 1 64 "ear_right_01.translateY" 
		1 65 "ear_right_01.translateX" 1 66 "eye_l_bat.scaleZ" 0 67 "eye_l_bat.scaleY" 
		0 68 "eye_l_bat.scaleX" 0 69 "eye_l_bat.rotateZ" 2 67 "eye_l_bat.rotateY" 
		2 68 "eye_l_bat.rotateX" 2 69 "eye_l_bat.translateZ" 1 67 "eye_l_bat.translateY" 
		1 68 "eye_l_bat.translateX" 1 69 "eye_r_bat.scaleZ" 0 70 "eye_r_bat.scaleY" 
		0 71 "eye_r_bat.scaleX" 0 72 "eye_r_bat.rotateZ" 2 70 "eye_r_bat.rotateY" 
		2 71 "eye_r_bat.rotateX" 2 72 "eye_r_bat.translateZ" 1 70 "eye_r_bat.translateY" 
		1 71 "eye_r_bat.translateX" 1 72 "face_bat.scaleZ" 0 73 "face_bat.scaleY" 
		0 74 "face_bat.scaleX" 0 75 "face_bat.rotateZ" 2 73 "face_bat.rotateY" 
		2 74 "face_bat.rotateX" 2 75 "face_bat.translateZ" 1 73 "face_bat.translateY" 
		1 74 "face_bat.translateX" 1 75 "head_bat.scaleZ" 0 76 "head_bat.scaleY" 
		0 77 "head_bat.scaleX" 0 78 "head_bat.rotateZ" 2 76 "head_bat.rotateY" 
		2 77 "head_bat.rotateX" 2 78 "head_bat.translateZ" 1 76 "head_bat.translateY" 
		1 77 "head_bat.translateX" 1 78 "body_bat.scaleZ" 0 79 "body_bat.scaleY" 
		0 80 "body_bat.scaleX" 0 81 "body_bat.rotateZ" 2 79 "body_bat.rotateY" 
		2 80 "body_bat.rotateX" 2 81 "body_bat.translateZ" 1 79 "body_bat.translateY" 
		1 80 "body_bat.translateX" 1 81 "butt_bat.scaleZ" 0 82 "butt_bat.scaleY" 
		0 83 "butt_bat.scaleX" 0 84 "butt_bat.rotateZ" 2 82 "butt_bat.rotateY" 
		2 83 "butt_bat.rotateX" 2 84 "butt_bat.translateZ" 1 82 "butt_bat.translateY" 
		1 83 "butt_bat.translateX" 1 84 "root_bat.scaleZ" 0 85 "root_bat.scaleY" 
		0 86 "root_bat.scaleX" 0 87 "root_bat.rotateZ" 2 85 "root_bat.rotateY" 
		2 86 "root_bat.rotateX" 2 87 "root_bat.translateZ" 1 85 "root_bat.translateY" 
		1 86 "root_bat.translateX" 1 87 "left_paw_02.scaleZ" 0 88 "left_paw_02.scaleY" 
		0 89 "left_paw_02.scaleX" 0 90 "left_paw_02.rotateZ" 2 88 "left_paw_02.rotateY" 
		2 89 "left_paw_02.rotateX" 2 90 "left_paw_02.translateZ" 1 
		88 "left_paw_02.translateY" 1 89 "left_paw_02.translateX" 1 90  ;
	setAttr ".cd[0].cim" -type "Int32Array" 270 0 1 2 3 4
		 5 6 7 8 9 10 11 12 13 14 15 16
		 17 18 19 20 21 22 23 24 25 26 27 28
		 29 30 31 32 33 34 35 36 37 38 39 40
		 41 42 43 44 45 46 47 48 49 50 51 52
		 53 54 55 56 57 58 59 60 61 62 63 64
		 65 66 67 68 69 70 71 72 73 74 75 76
		 77 78 79 80 81 82 83 84 85 86 87 88
		 89 90 91 92 93 94 95 96 97 98 99 100
		 101 102 103 104 105 106 107 108 109 110 111 112
		 113 114 115 116 117 118 119 120 121 122 123 124
		 125 126 127 128 129 130 131 132 133 134 135 136
		 137 138 139 140 141 142 143 144 145 146 147 148
		 149 150 151 152 153 154 155 156 157 158 159 160
		 161 162 163 164 165 166 167 168 169 170 171 172
		 173 174 175 176 177 178 179 180 181 182 183 184
		 185 186 187 188 189 190 191 192 193 194 195 196
		 197 198 199 200 201 202 203 204 205 206 207 208
		 209 210 211 212 213 214 215 216 217 218 219 220
		 221 222 223 224 225 226 227 228 229 230 231 232
		 233 234 235 236 237 238 239 240 241 242 243 244
		 245 246 247 248 249 250 251 252 253 254 255 256
		 257 258 259 260 261 262 263 264 265 266 267 268
		 269 ;
createNode animClip -n "attackSource";
	setAttr ".ihi" 0;
	setAttr -s 270 ".ac[0:269]" yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes;
	setAttr ".ss" 151;
	setAttr ".se" 170;
	setAttr ".ci" no;
createNode animCurveTU -n "animCurveTU1981";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1982";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1983";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1981";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 153 1.1756051778793335 157 10.647705078125
		 161 18.226779937744141 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.8025544285774231 0.74595993757247925 
		0.94587999582290649 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.59657889604568481 0.66599082946777344 
		-0.32451671361923218 0;
	setAttr -s 5 ".kox[0:4]"  1 0.8025544285774231 0.74595993757247925 
		0.94587999582290649 1;
	setAttr -s 5 ".koy[0:4]"  0 0.59657889604568481 0.66599082946777344 
		-0.32451671361923218 0;
createNode animCurveTA -n "animCurveTA1982";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 153 8.5887165069580078 157 -5.2819881439208984
		 161 18.92840576171875 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.93824231624603271 0.87939584255218506 
		0.9858243465423584 1;
	setAttr -s 5 ".kiy[0:4]"  0 -0.34597894549369812 0.47609138488769531 
		0.16778068244457245 0;
	setAttr -s 5 ".kox[0:4]"  1 0.93824231624603271 0.87939584255218506 
		0.9858243465423584 1;
	setAttr -s 5 ".koy[0:4]"  0 -0.34597894549369812 0.47609138488769531 
		0.16778068244457245 0;
createNode animCurveTA -n "animCurveTA1983";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 153 25.011196136474609 157 -29.146938323974613
		 161 -11.054597854614258 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.44105643033981323 0.46798232197761536 
		0.72893446683883667 1;
	setAttr -s 5 ".kiy[0:4]"  0 -0.89747941493988037 -0.88373786211013794 
		0.68458348512649536 0;
	setAttr -s 5 ".kox[0:4]"  1 0.44105643033981323 0.46798232197761536 
		0.72893446683883667 1;
	setAttr -s 5 ".koy[0:4]"  0 -0.89747941493988037 -0.88373786211013794 
		0.68458348512649536 0;
createNode animCurveTL -n "animCurveTL1981";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  151 -5.7247552871704102 161 2.3277366161346436
		 170 -5.7247552871704102;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1982";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  151 12.644636154174805 161 14.671804428100586
		 170 12.644636154174805;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1983";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 43.253993988037109 170 43.253993988037109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1984";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1985";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1986";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1984";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1985";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1986";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1984";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -1.9167585372924805 170 -1.9167585372924805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1985";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -5.0555992126464844 170 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1986";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 28.262805938720703 170 28.262805938720703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1987";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1988";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1989";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1987";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 153 14.552690505981444 157 9.3637275695800781
		 161 17.123651504516602 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.83702123165130615 0.99106073379516602 
		0.95737373828887939 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.54717040061950684 0.13341177999973297 
		-0.28885200619697571 0;
	setAttr -s 5 ".kox[0:4]"  1 0.83702123165130615 0.99106073379516602 
		0.95737373828887939 1;
	setAttr -s 5 ".koy[0:4]"  0 0.54717040061950684 0.13341177999973297 
		-0.28885200619697571 0;
createNode animCurveTA -n "animCurveTA1988";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 153 -15.798990249633791 157 -8.1717729568481445
		 161 -22.709739685058594 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.86859136819839478 0.94033300876617432 
		0.96703922748565674 1;
	setAttr -s 5 ".kiy[0:4]"  0 -0.49552902579307556 -0.3402554988861084 
		0.25462755560874939 0;
	setAttr -s 5 ".kox[0:4]"  1 0.86859136819839478 0.94033300876617432 
		0.96703922748565674 1;
	setAttr -s 5 ".koy[0:4]"  0 -0.49552902579307556 -0.3402554988861084 
		0.25462755560874939 0;
createNode animCurveTA -n "animCurveTA1989";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 153 -44.818260192871094 157 25.893665313720703
		 161 19.369712829589844 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.48405590653419495 0.28518566489219666 
		0.76784431934356689 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.87503707408905029 0.95847231149673462 
		-0.64063644409179688 0;
	setAttr -s 5 ".kox[0:4]"  1 0.48405590653419495 0.28518566489219666 
		0.76784431934356689 1;
	setAttr -s 5 ".koy[0:4]"  0 0.87503707408905029 0.95847231149673462 
		-0.64063644409179688 0;
createNode animCurveTL -n "animCurveTL1987";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  151 -5.7247552871704102 161 2.3277366161346436
		 170 -5.7247552871704102;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1988";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  151 12.644636154174805 161 14.671804428100586
		 170 12.644636154174805;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1989";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -43.253993988037109 170 -43.253993988037109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1990";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1991";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1992";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1990";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 0.0048254411667585373 152 0 153 0 156 -13.62432861328125
		 163 0.038236241787672043 170 0.0048254411667585373;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.99999946355819702 0.57395666837692261 
		0.99999874830245972 0.92597061395645142 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.0010106356348842382 -0.8188856840133667 
		0.0016016346635296941 0.37759533524513245 0;
	setAttr -s 6 ".kox[0:5]"  1 0.99999946355819702 0.57395666837692261 
		0.99999874830245972 0.92597061395645142 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.0010106356348842382 -0.8188856840133667 
		0.0016016346635296941 0.37759533524513245 0;
createNode animCurveTA -n "animCurveTA1991";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 1.5292341709136963 152 0 153 0 156 15.032671928405762
		 163 13.691681861877441 170 1.5292341709136963;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.9523463249206543 0.53619754314422607 
		0.86746203899383545 0.9271852970123291 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.30501881241798401 0.84409254789352417 
		0.49750334024429321 -0.37460300326347351 0;
	setAttr -s 6 ".kox[0:5]"  1 0.9523463249206543 0.53619754314422607 
		0.86746203899383545 0.9271852970123291 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.30501881241798401 0.84409254789352417 
		0.49750334024429321 -0.37460300326347351 0;
createNode animCurveTA -n "animCurveTA1992";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 1.0246820449829102 152 0 153 0 155 -28.553337097167969
		 156 -45.951541900634766 163 8.1194639205932617 170 1.0246820449829102;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.9777376651763916 0.2432914525270462 
		0.15399987995624542 0.46189945936203003 0.57972222566604614 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.20983083546161652 -0.96995323896408081 
		-0.98807084560394287 0.88693231344223022 0.81481415033340454 0;
	setAttr -s 7 ".kox[0:6]"  1 0.9777376651763916 0.2432914525270462 
		0.15399987995624542 0.46189945936203003 0.57972222566604614 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.20983083546161652 -0.96995323896408081 
		-0.98807084560394287 0.88693231344223022 0.81481415033340454 0;
createNode animCurveTL -n "animCurveTL1990";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -0.72905689477920532 170 -0.72905689477920532;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1991";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -19.141372680664063 170 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1992";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 23.549764633178711 170 23.549764633178711;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1993";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1994";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1995";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1993";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 152 -13.62432861328125 159 0.038236241787672043
		 168 0 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes yes;
	setAttr -s 5 ".kix[0:4]"  1 0.99999797344207764 0.94187867641448975 
		0.99999892711639404 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.0020020401570945978 0.33595314621925354 
		-0.0014560307608917356 0;
	setAttr -s 5 ".kox[0:4]"  1 0.99999797344207764 0.94187867641448975 
		0.99999892711639404 1;
	setAttr -s 5 ".koy[0:4]"  0 0.0020020401570945978 0.33595314621925354 
		-0.0014560307608917356 0;
createNode animCurveTA -n "animCurveTA1994";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 152 15.032671928405762 159 13.691681861877441
		 168 0 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes yes;
	setAttr -s 5 ".kix[0:4]"  1 0.81272941827774048 0.93053048849105835 
		0.88671618700027466 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.58264130353927612 -0.36621448397636414 
		-0.4623141884803772 0;
	setAttr -s 5 ".kox[0:4]"  1 0.81272941827774048 0.93053048849105835 
		0.88671618700027466 1;
	setAttr -s 5 ".koy[0:4]"  0 0.58264130353927612 -0.36621448397636414 
		-0.4623141884803772 0;
createNode animCurveTA -n "animCurveTA1995";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 12.527528762817383 152 -45.951541900634766
		 159 8.1194639205932617 168 0 169 0 170 12.527528762817383;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.97438341379165649 0.63923794031143188 
		0.94674175977706909 0.35614293813705444 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.22489312291145325 0.76900899410247803 
		-0.32199382781982422 0.93443143367767334 0;
	setAttr -s 6 ".kox[0:5]"  1 0.97438341379165649 0.63923794031143188 
		0.94674175977706909 0.35614293813705444 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.22489312291145325 0.76900899410247803 
		-0.32199382781982422 0.93443143367767334 0;
createNode animCurveTL -n "animCurveTL1993";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -36.1805419921875 170 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1994";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 7.3658723831176758 170 7.3658723831176758;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1995";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 41.597393035888672 170 41.597393035888672;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1996";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1997";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1998";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1996";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 0.0048254411667585373 152 0 153 0 156 -13.62432861328125
		 163 0.038236241787672043 170 0.0048254411667585373;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.99999946355819702 0.57395666837692261 
		0.99999874830245972 0.92597061395645142 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.0010106356348842382 -0.8188856840133667 
		0.0016016346635296941 0.37759533524513245 0;
	setAttr -s 6 ".kox[0:5]"  1 0.99999946355819702 0.57395666837692261 
		0.99999874830245972 0.92597061395645142 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.0010106356348842382 -0.8188856840133667 
		0.0016016346635296941 0.37759533524513245 0;
createNode animCurveTA -n "animCurveTA1997";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 1.5292341709136963 152 0 153 0 156 15.032671928405762
		 163 13.691681861877441 170 1.5292341709136963;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.9523463249206543 0.53619754314422607 
		0.86746203899383545 0.9271852970123291 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.30501881241798401 0.84409254789352417 
		0.49750334024429321 -0.37460300326347351 0;
	setAttr -s 6 ".kox[0:5]"  1 0.9523463249206543 0.53619754314422607 
		0.86746203899383545 0.9271852970123291 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.30501881241798401 0.84409254789352417 
		0.49750334024429321 -0.37460300326347351 0;
createNode animCurveTA -n "animCurveTA1998";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 1.0246820449829102 152 0 153 0 155 -28.553337097167969
		 156 -45.951541900634766 163 8.1194639205932617 170 1.0246820449829102;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.9777376651763916 0.2432914525270462 
		0.15399987995624542 0.46189945936203003 0.57972222566604614 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.20983083546161652 -0.96995323896408081 
		-0.98807084560394287 0.88693231344223022 0.81481415033340454 0;
	setAttr -s 7 ".kox[0:6]"  1 0.9777376651763916 0.2432914525270462 
		0.15399987995624542 0.46189945936203003 0.57972222566604614 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.20983083546161652 -0.96995323896408081 
		-0.98807084560394287 0.88693231344223022 0.81481415033340454 0;
createNode animCurveTL -n "animCurveTL1996";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -0.11375267058610916 170 -0.11375267058610916;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1997";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -0.067464433610439301 170 -0.067464433610439301;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1998";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 41.135360717773437 170 41.135360717773437;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1999";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2000";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2001";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1999";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 152 -13.62432861328125 159 0.038236241787672043
		 168 0 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes yes;
	setAttr -s 5 ".kix[0:4]"  1 0.99999797344207764 0.94187867641448975 
		0.99999892711639404 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.0020020401570945978 0.33595314621925354 
		-0.0014560307608917356 0;
	setAttr -s 5 ".kox[0:4]"  1 0.99999797344207764 0.94187867641448975 
		0.99999892711639404 1;
	setAttr -s 5 ".koy[0:4]"  0 0.0020020401570945978 0.33595314621925354 
		-0.0014560307608917356 0;
createNode animCurveTA -n "animCurveTA2000";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 152 15.032671928405762 159 13.691681861877441
		 168 0 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes yes;
	setAttr -s 5 ".kix[0:4]"  1 0.81272941827774048 0.93053048849105835 
		0.88671618700027466 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.58264130353927612 -0.36621448397636414 
		-0.4623141884803772 0;
	setAttr -s 5 ".kox[0:4]"  1 0.81272941827774048 0.93053048849105835 
		0.88671618700027466 1;
	setAttr -s 5 ".koy[0:4]"  0 0.58264130353927612 -0.36621448397636414 
		-0.4623141884803772 0;
createNode animCurveTA -n "animCurveTA2001";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 12.527528762817383 152 -45.951541900634766
		 159 8.1194639205932617 168 0 169 0 170 12.527528762817383;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.97438341379165649 0.63923794031143188 
		0.94674175977706909 0.35614293813705444 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.22489312291145325 0.76900899410247803 
		-0.32199382781982422 0.93443143367767334 0;
	setAttr -s 6 ".kox[0:5]"  1 0.97438341379165649 0.63923794031143188 
		0.94674175977706909 0.35614293813705444 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.22489312291145325 0.76900899410247803 
		-0.32199382781982422 0.93443143367767334 0;
createNode animCurveTL -n "animCurveTL1999";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -54.695327758789062 170 -54.695327758789062;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2000";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 3.2521772384643555 170 3.2521772384643555;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2001";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2002";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2003";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2004";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2002";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 0.0048254411667585373 152 0 153 0 156 -13.62432861328125
		 163 0.038236241787672043 170 0.0048254411667585373;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.99999946355819702 0.57395666837692261 
		0.99999874830245972 0.92597061395645142 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.0010106356348842382 -0.8188856840133667 
		0.0016016346635296941 0.37759533524513245 0;
	setAttr -s 6 ".kox[0:5]"  1 0.99999946355819702 0.57395666837692261 
		0.99999874830245972 0.92597061395645142 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.0010106356348842382 -0.8188856840133667 
		0.0016016346635296941 0.37759533524513245 0;
createNode animCurveTA -n "animCurveTA2003";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 1.5292341709136963 152 0 153 0 156 15.032671928405762
		 163 13.691681861877441 170 1.5292341709136963;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.9523463249206543 0.53619754314422607 
		0.86746203899383545 0.9271852970123291 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.30501881241798401 0.84409254789352417 
		0.49750334024429321 -0.37460300326347351 0;
	setAttr -s 6 ".kox[0:5]"  1 0.9523463249206543 0.53619754314422607 
		0.86746203899383545 0.9271852970123291 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.30501881241798401 0.84409254789352417 
		0.49750334024429321 -0.37460300326347351 0;
createNode animCurveTA -n "animCurveTA2004";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 1.0246820449829102 152 0 153 0 155 -28.553337097167969
		 156 -45.951541900634766 163 8.1194639205932617 170 1.0246820449829102;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.9777376651763916 0.2432914525270462 
		0.15399987995624542 0.46189945936203003 0.57972222566604614 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.20983083546161652 -0.96995323896408081 
		-0.98807084560394287 0.88693231344223022 0.81481415033340454 0;
	setAttr -s 7 ".kox[0:6]"  1 0.9777376651763916 0.2432914525270462 
		0.15399987995624542 0.46189945936203003 0.57972222566604614 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.20983083546161652 -0.96995323896408081 
		-0.98807084560394287 0.88693231344223022 0.81481415033340454 0;
createNode animCurveTL -n "animCurveTL2002";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -2.6052179336547852 170 -2.6052179336547852;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2003";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -19.141372680664063 170 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2004";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 23.227632522583008 170 23.227632522583008;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2005";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2006";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2007";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2005";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 152 -13.62432861328125 159 0.038236241787672043
		 168 0 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes yes;
	setAttr -s 5 ".kix[0:4]"  1 0.99999797344207764 0.94187867641448975 
		0.99999892711639404 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.0020020401570945978 0.33595314621925354 
		-0.0014560307608917356 0;
	setAttr -s 5 ".kox[0:4]"  1 0.99999797344207764 0.94187867641448975 
		0.99999892711639404 1;
	setAttr -s 5 ".koy[0:4]"  0 0.0020020401570945978 0.33595314621925354 
		-0.0014560307608917356 0;
createNode animCurveTA -n "animCurveTA2006";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 152 15.032671928405762 159 13.691681861877441
		 168 0 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes yes;
	setAttr -s 5 ".kix[0:4]"  1 0.81272941827774048 0.93053048849105835 
		0.88671618700027466 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.58264130353927612 -0.36621448397636414 
		-0.4623141884803772 0;
	setAttr -s 5 ".kox[0:4]"  1 0.81272941827774048 0.93053048849105835 
		0.88671618700027466 1;
	setAttr -s 5 ".koy[0:4]"  0 0.58264130353927612 -0.36621448397636414 
		-0.4623141884803772 0;
createNode animCurveTA -n "animCurveTA2007";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 12.527528762817383 152 -45.951541900634766
		 159 8.1194639205932617 168 0 169 0 170 12.527528762817383;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.97438341379165649 0.63923794031143188 
		0.94674175977706909 0.35614293813705444 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.22489312291145325 0.76900899410247803 
		-0.32199382781982422 0.93443143367767334 0;
	setAttr -s 6 ".kox[0:5]"  1 0.97438341379165649 0.63923794031143188 
		0.94674175977706909 0.35614293813705444 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.22489312291145325 0.76900899410247803 
		-0.32199382781982422 0.93443143367767334 0;
createNode animCurveTL -n "animCurveTL2005";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -36.1805419921875 170 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2006";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 7.3658723831176758 170 7.3658723831176758;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2007";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -41.399761199951172 170 -41.399761199951172;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2008";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2009";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2010";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2008";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  151 0 159 -13.500383377075195 170 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA2009";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  151 0 159 -9.9905214309692383 170 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA2010";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 153 49.124191284179688 157 20.721958160400391
		 159 33.330280303955078 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.5686187744140625 0.6717953085899353 
		0.831656813621521 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.82260113954544067 -0.74073684215545654 
		-0.55528998374938965 0;
	setAttr -s 5 ".kox[0:4]"  1 0.5686187744140625 0.6717953085899353 
		0.831656813621521 1;
	setAttr -s 5 ".koy[0:4]"  0 0.82260113954544067 -0.74073684215545654 
		-0.55528998374938965 0;
createNode animCurveTL -n "animCurveTL2008";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 22.400806427001953 170 22.400806427001953;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2009";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 10.647112846374512 170 10.647112846374512;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2010";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2011";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2012";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2013";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2011";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2012";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2013";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2011";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 35.083248138427734 170 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2012";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 30.643020629882813 170 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2013";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 36.804916381835937 170 36.804916381835937;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2014";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2015";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2016";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2014";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2015";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2016";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2014";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 35.083248138427734 170 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2015";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 30.643020629882813 170 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2016";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -36.361770629882813 170 -36.361770629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2017";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2018";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2019";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2017";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2018";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2019";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2017";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -5.8221402168273926 170 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2018";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -10.433219909667969 170 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2019";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -28.427871704101563 170 -28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2020";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2021";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2022";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2020";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  151 0 153 28.22575569152832 158 -1.1023023128509521
		 160 25.252054214477539 161 25.252054214477539 163 -1.1023023128509521 164 -3.3237776756286621
		 166 25.252054214477539 167 25.252054214477539 170 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.99783164262771606 0.98453390598297119 
		0.26224538683891296 0.26224538683891296 0.24311104416847229 0.26224538683891296 0.24311104416847229 
		0.35371339321136475 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.065818518400192261 -0.17519392073154449 
		0.96500122547149658 -0.96500122547149658 -0.96999847888946533 0.96500122547149658 
		0.96999847888946533 -0.93535387516021729 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99783164262771606 0.98453390598297119 
		0.26224538683891296 0.26224538683891296 0.24311104416847229 0.26224538683891296 0.24311104416847229 
		0.35371339321136475 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.065818518400192261 -0.17519392073154449 
		0.96500122547149658 -0.96500122547149658 -0.96999847888946533 0.96500122547149658 
		0.96999847888946533 -0.93535387516021729 0;
createNode animCurveTA -n "animCurveTA2021";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  151 0 153 8.816075325012207 158 -3.5812747478485107
		 160 -5.8259954452514648 161 -5.8259954452514648 163 -3.5812747478485107 164 -4.1266965866088867
		 166 -5.8259954452514648 167 -5.8259954452514648 170 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.9777989387512207 0.75213664770126343 
		0.95422917604446411 0.95422917604446411 0.97298753261566162 0.95422917604446411 0.97298753261566162 
		0.85366725921630859 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.20954498648643494 -0.65900713205337524 
		-0.29907655715942383 0.29907655715942383 0.23085765540599823 -0.29907655715942383 
		-0.23085765540599823 0.52081865072250366 0;
	setAttr -s 10 ".kox[0:9]"  1 0.9777989387512207 0.75213664770126343 
		0.95422917604446411 0.95422917604446411 0.97298753261566162 0.95422917604446411 0.97298753261566162 
		0.85366725921630859 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.20954498648643494 -0.65900713205337524 
		-0.29907655715942383 0.29907655715942383 0.23085765540599823 -0.29907655715942383 
		-0.23085765540599823 0.52081865072250366 0;
createNode animCurveTA -n "animCurveTA2022";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  151 0 153 0.12880556285381317 158 21.756893157958984
		 160 22.431192398071289 161 22.431192398071289 163 21.756893157958984 164 20.740800857543945
		 166 22.431192398071289 167 22.431192398071289 170 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.6091429591178894 0.5996432900428772 
		0.995597243309021 0.995597243309021 0.97325867414474487 0.995597243309021 0.97325867414474487 
		0.39169853925704956 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.79306042194366455 0.80026739835739136 
		0.093735277652740479 -0.093735277652740479 -0.2297116219997406 0.093735277652740479 
		0.2297116219997406 -0.92009353637695313 0;
	setAttr -s 10 ".kox[0:9]"  1 0.6091429591178894 0.5996432900428772 
		0.995597243309021 0.995597243309021 0.97325867414474487 0.995597243309021 0.97325867414474487 
		0.39169853925704956 1;
	setAttr -s 10 ".koy[0:9]"  0 0.79306042194366455 0.80026739835739136 
		0.093735277652740479 -0.093735277652740479 -0.2297116219997406 0.093735277652740479 
		0.2297116219997406 -0.92009353637695313 0;
createNode animCurveTL -n "animCurveTL2020";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 11.41090202331543 170 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2021";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -0.91886520385742188 170 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2022";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -13.740226745605469 170 -13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2023";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2024";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2025";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2023";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  151 0 152 28.22575569152832 157 -1.1023023128509521
		 159 25.252054214477539 160 25.252054214477539 162 -1.1023023128509521 163 -3.3237776756286621
		 165 25.252054214477539 166 25.252054214477539 169 0 170 0;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes yes;
	setAttr -s 11 ".kix[0:10]"  1 0.99705201387405396 0.98453390598297119 
		0.26224538683891296 0.26224538683891296 0.24311104416847229 0.26224538683891296 0.24311104416847229 
		0.35371243953704834 0.35371339321136475 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.076728343963623047 -0.17519392073154449 
		0.96500122547149658 -0.96500122547149658 -0.96999847888946533 0.96500122547149658 
		0.96999847888946533 -0.93535417318344116 -0.93535387516021729 0;
	setAttr -s 11 ".kox[0:10]"  1 0.99705201387405396 0.98453390598297119 
		0.26224538683891296 0.26224538683891296 0.24311104416847229 0.26224538683891296 0.24311104416847229 
		0.35371243953704834 0.35371339321136475 1;
	setAttr -s 11 ".koy[0:10]"  0 -0.076728343963623047 -0.17519392073154449 
		0.96500122547149658 -0.96500122547149658 -0.96999847888946533 0.96500122547149658 
		0.96999847888946533 -0.93535417318344116 -0.93535387516021729 0;
createNode animCurveTA -n "animCurveTA2024";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  151 0 152 8.816075325012207 157 -3.5812747478485107
		 159 -5.8259954452514648 160 -5.8259954452514648 162 -3.5812747478485107 163 -4.1266965866088867
		 165 -5.8259954452514648 166 -5.8259954452514648 169 0 170 0;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes yes;
	setAttr -s 11 ".kix[0:10]"  1 0.97013789415359497 0.75213664770126343 
		0.95422917604446411 0.95422917604446411 0.97298753261566162 0.95422917604446411 0.97298753261566162 
		0.85366666316986084 0.85366725921630859 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.24255403876304626 -0.65900713205337524 
		-0.29907655715942383 0.29907655715942383 0.23085765540599823 -0.29907655715942383 
		-0.23085765540599823 0.52081978321075439 0.52081865072250366 0;
	setAttr -s 11 ".kox[0:10]"  1 0.97013789415359497 0.75213664770126343 
		0.95422917604446411 0.95422917604446411 0.97298753261566162 0.95422917604446411 0.97298753261566162 
		0.85366666316986084 0.85366725921630859 1;
	setAttr -s 11 ".koy[0:10]"  0 -0.24255403876304626 -0.65900713205337524 
		-0.29907655715942383 0.29907655715942383 0.23085765540599823 -0.29907655715942383 
		-0.23085765540599823 0.52081978321075439 0.52081865072250366 0;
createNode animCurveTA -n "animCurveTA2025";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  151 0 152 0.12880556285381317 157 21.756893157958984
		 159 22.431192398071289 160 22.431192398071289 162 21.756893157958984 163 20.740800857543945
		 165 22.431192398071289 166 22.431192398071289 169 0 170 0;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes yes;
	setAttr -s 11 ".kix[0:10]"  1 0.54988986253738403 0.5996432900428772 
		0.995597243309021 0.995597243309021 0.97325867414474487 0.995597243309021 0.97325867414474487 
		0.39169761538505554 0.39169853925704956 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.83523726463317871 0.80026739835739136 
		0.093735277652740479 -0.093735277652740479 -0.2297116219997406 0.093735277652740479 
		0.2297116219997406 -0.92009401321411133 -0.92009353637695313 0;
	setAttr -s 11 ".kox[0:10]"  1 0.54988986253738403 0.5996432900428772 
		0.995597243309021 0.995597243309021 0.97325867414474487 0.995597243309021 0.97325867414474487 
		0.39169761538505554 0.39169853925704956 1;
	setAttr -s 11 ".koy[0:10]"  0 0.83523726463317871 0.80026739835739136 
		0.093735277652740479 -0.093735277652740479 -0.2297116219997406 0.093735277652740479 
		0.2297116219997406 -0.92009401321411133 -0.92009353637695313 0;
createNode animCurveTL -n "animCurveTL2023";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0.057151313871145248 170 0.057151313871145248;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2024";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 23.729547500610352 170 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2025";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -53.338920593261719 170 -53.338920593261719;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2026";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2027";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2028";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2026";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2027";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2028";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2026";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -5.8221402168273926 170 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2027";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -10.433219909667969 170 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2028";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 28.427871704101563 170 28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2029";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2030";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2031";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2029";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  151 0 153 -26.414230346679688 158 2.6579129695892334
		 160 -29.270986557006836 161 -31.193754196166992 163 2.6579129695892334 164 4.8451347351074219
		 166 -29.270986557006836 167 -31.193754196166992 170 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.98758667707443237 0.98570102453231812 
		0.20698745548725128 0.21887150406837463 0.19491720199584961 0.21887150406837463 0.19491720199584961 
		0.31015050411224365 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.15707466006278992 -0.16850356757640839 
		-0.97834354639053345 0.97575366497039795 0.98081964254379272 -0.97575366497039795 
		-0.98081964254379272 0.9506874680519104 0;
	setAttr -s 10 ".kox[0:9]"  1 0.98758667707443237 0.98570102453231812 
		0.20698745548725128 0.21887150406837463 0.19491720199584961 0.21887150406837463 0.19491720199584961 
		0.31015050411224365 1;
	setAttr -s 10 ".koy[0:9]"  0 0.15707466006278992 -0.16850356757640839 
		-0.97834354639053345 0.97575366497039795 0.98081964254379272 -0.97575366497039795 
		-0.98081964254379272 0.9506874680519104 0;
createNode animCurveTA -n "animCurveTA2030";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  151 0 153 8.8314275741577148 158 7.6049304008483896
		 160 -6.1879010200500488 161 -5.7512798309326172 163 7.6049304008483896 164 5.7738285064697266
		 166 -6.1879010200500488 167 -5.7512798309326172 170 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.91018402576446533 0.74375444650650024 
		0.47257307171821594 0.46083089709281921 0.52781271934509277 0.46083089709281921 0.52781271934509277 
		0.83921188116073608 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.41420421004295349 -0.6684529185295105 
		-0.88129144906997681 0.88748800754547119 0.84936082363128662 -0.88748800754547119 
		-0.84936082363128662 0.54380452632904053 0;
	setAttr -s 10 ".kox[0:9]"  1 0.91018402576446533 0.74375444650650024 
		0.47257307171821594 0.46083089709281921 0.52781271934509277 0.46083089709281921 0.52781271934509277 
		0.83921188116073608 1;
	setAttr -s 10 ".koy[0:9]"  0 0.41420421004295349 -0.6684529185295105 
		-0.88129144906997681 0.88748800754547119 0.84936082363128662 -0.88748800754547119 
		-0.84936082363128662 0.54380452632904053 0;
createNode animCurveTA -n "animCurveTA2031";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  151 0 153 0.87423610687255859 158 26.148763656616211
		 160 16.412778854370117 161 16.382246017456055 163 26.148763656616211 164 25.77452278137207
		 166 16.412778854370117 167 16.382246017456055 170 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.53850662708282471 0.73233562707901001 
		0.59135615825653076 0.59255999326705933 0.606361985206604 0.59255999326705933 0.606361985206604 
		0.50289607048034668 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.84262126684188843 0.68094378709793091 
		-0.80641049146652222 0.80552631616592407 0.79518872499465942 -0.80552631616592407 
		-0.79518872499465942 -0.86434686183929443 0;
	setAttr -s 10 ".kox[0:9]"  1 0.53850662708282471 0.73233562707901001 
		0.59135615825653076 0.59255999326705933 0.606361985206604 0.59255999326705933 0.606361985206604 
		0.50289607048034668 1;
	setAttr -s 10 ".koy[0:9]"  0 0.84262126684188843 0.68094378709793091 
		-0.80641049146652222 0.80552631616592407 0.79518872499465942 -0.80552631616592407 
		-0.79518872499465942 -0.86434686183929443 0;
createNode animCurveTL -n "animCurveTL2029";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 11.41090202331543 170 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2030";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -0.91886520385742188 170 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2031";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 13.740226745605469 170 13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2032";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2033";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2034";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2032";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  151 0 152 -26.414230346679688 157 2.6579129695892334
		 159 -29.270986557006836 160 -31.193754196166992 162 2.6579129695892334 163 4.8451347351074219
		 165 -29.270986557006836 166 -31.193754196166992 169 0 170 0;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes yes;
	setAttr -s 11 ".kix[0:10]"  1 0.98321646451950073 0.98570102453231812 
		0.20698745548725128 0.21887150406837463 0.19491720199584961 0.21887150406837463 0.19491720199584961 
		0.31014978885650635 0.29272007942199707 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.1824430376291275 -0.16850356757640839 
		-0.97834354639053345 0.97575366497039795 0.98081964254379272 -0.97575366497039795 
		-0.98081964254379272 0.9506877064704895 0.95619815587997437 0;
	setAttr -s 11 ".kox[0:10]"  1 0.98321646451950073 0.98570102453231812 
		0.20698745548725128 0.21887150406837463 0.19491720199584961 0.21887150406837463 0.19491720199584961 
		0.31014978885650635 0.29272007942199707 1;
	setAttr -s 11 ".koy[0:10]"  0 0.1824430376291275 -0.16850356757640839 
		-0.97834354639053345 0.97575366497039795 0.98081964254379272 -0.97575366497039795 
		-0.98081964254379272 0.9506877064704895 0.95619815587997437 0;
createNode animCurveTA -n "animCurveTA2033";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  151 0 152 8.8314275741577148 157 7.6049304008483896
		 159 -6.1879010200500488 160 -5.7512798309326172 162 7.6049304008483896 163 5.7738285064697266
		 165 -6.1879010200500488 166 -5.7512798309326172 169 0 170 0;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes yes;
	setAttr -s 11 ".kix[0:10]"  1 0.88323485851287842 0.74375444650650024 
		0.47257307171821594 0.46083089709281921 0.52781271934509277 0.46083089709281921 0.52781271934509277 
		0.83921116590499878 0.85663336515426636 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.46893081068992615 -0.6684529185295105 
		-0.88129144906997681 0.88748800754547119 0.84936082363128662 -0.88748800754547119 
		-0.84936082363128662 0.54380565881729126 0.51592576503753662 0;
	setAttr -s 11 ".kox[0:10]"  1 0.88323485851287842 0.74375444650650024 
		0.47257307171821594 0.46083089709281921 0.52781271934509277 0.46083089709281921 0.52781271934509277 
		0.83921116590499878 0.85663336515426636 1;
	setAttr -s 11 ".koy[0:10]"  0 0.46893081068992615 -0.6684529185295105 
		-0.88129144906997681 0.88748800754547119 0.84936082363128662 -0.88748800754547119 
		-0.84936082363128662 0.54380565881729126 0.51592576503753662 0;
createNode animCurveTA -n "animCurveTA2034";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  151 0 152 0.87423610687255859 157 26.148763656616211
		 159 16.412778854370117 160 16.382246017456055 162 26.148763656616211 163 25.77452278137207
		 165 16.412778854370117 166 16.382246017456055 169 0 170 0;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes yes;
	setAttr -s 11 ".kix[0:10]"  1 0.48042783141136169 0.73233562707901001 
		0.59135615825653076 0.59255999326705933 0.606361985206604 0.59255999326705933 0.606361985206604 
		0.50289493799209595 0.50359582901000977 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.87703430652618408 0.68094378709793091 
		-0.80641049146652222 0.80552631616592407 0.79518872499465942 -0.80552631616592407 
		-0.79518872499465942 -0.86434751749038696 -0.86393940448760986 0;
	setAttr -s 11 ".kox[0:10]"  1 0.48042783141136169 0.73233562707901001 
		0.59135615825653076 0.59255999326705933 0.606361985206604 0.59255999326705933 0.606361985206604 
		0.50289493799209595 0.50359582901000977 1;
	setAttr -s 11 ".koy[0:10]"  0 0.87703430652618408 0.68094378709793091 
		-0.80641049146652222 0.80552631616592407 0.79518872499465942 -0.80552631616592407 
		-0.79518872499465942 -0.86434751749038696 -0.86393940448760986 0;
createNode animCurveTL -n "animCurveTL2032";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0.057151321321725845 170 0.057151321321725845;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2033";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 23.729547500610352 170 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2034";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 53.782066345214844 170 53.782066345214844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2035";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2036";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2037";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTA -n "animCurveTA2035";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 13.462885856628418 154 10.880314826965332
		 156 -25.320859909057617 159 -53.851543426513672 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99115669727325439 0.30324450135231018 
		0.10776612907648087 0.9995686411857605 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.13269627094268799 -0.95291274785995483 
		-0.99417632818222046 -0.029367480427026749 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.99999934434890747 0.2853797972202301 
		0.10876189917325974 0.99903106689453125 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.0011078969109803438 -0.95841443538665771 
		-0.99406784772872925 0.044010166078805923 0 0 0;
createNode animCurveTA -n "animCurveTA2036";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 -7.6762561798095703 154 -2.2783734798431396
		 156 6.8871521949768066 159 30.705024719238281 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99709910154342651 0.4183732271194458 
		0.35928943753242493 0.99697369337081909 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.076114274561405182 0.90827524662017822 
		0.93322616815567017 0.077739126980304718 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.9892733097076416 0.43423688411712646 
		0.35045963525772095 0.99968463182449341 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 0.14607690274715424 0.90079867839813232 
		0.93657779693603516 -0.025110090151429176 0 0 0;
createNode animCurveTA -n "animCurveTA2037";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 2.8692567348480225 154 -17.685451507568359
		 156 -29.566032409667969 159 -11.47702693939209 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99959313869476318 0.12711592018604279 
		0.99999982118606567 0.43048083782196045 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.028521399945020676 -0.99188792705535889 
		-0.00063663657056167722 0.90259969234466553 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.86592668294906616 0.13484755158424377 
		0.99829345941543579 0.43828576803207397 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.50017106533050537 -0.99086636304855347 
		0.058396782726049423 0.89883571863174438 0 0 0;
createNode animCurveTL -n "animCurveTL2035";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 -1.1630247831344604 153 -1.1630247831344604
		 166 -1.1630247831344604 167 -1.1630247831344604 170 -1.1630247831344604;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2036";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1.228269100189209 153 1.228269100189209
		 166 1.228269100189209 167 1.228269100189209 170 1.228269100189209;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2037";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 27.684015274047852 153 27.684015274047852
		 166 27.684015274047852 167 27.684015274047852 170 27.684015274047852;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2038";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2039";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2040";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTA -n "animCurveTA2038";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 7.2983245849609366 154 2.9370958805084229
		 156 -22.637157440185547 159 -29.193298339843746 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99737662076950073 0.18518489599227905 
		0.33349177241325378 1 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.072387002408504486 -0.98270368576049805 
		-0.94275301694869995 0 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.99999827146530151 0.17828251421451569 
		0.34541860222816467 0.99971497058868408 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.0018709249561652541 -0.98397928476333618 
		-0.93844866752624512 0.02387455478310585 0 0 0;
createNode animCurveTA -n "animCurveTA2039";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 -8.1124191284179687 154 13.293895721435547
		 156 40.734600067138672 159 32.449676513671875 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99676167964935303 0.084082484245300293 
		0.99615675210952759 0.27964851260185242 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.080411829054355621 0.99645876884460449 
		0.087588667869567871 -0.96010243892669678 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.90207690000534058 0.085503756999969482 
		1 0.27728205919265747 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 0.43157529830932617 0.99633783102035522 
		0 -0.9607885479927063 0 0 0;
createNode animCurveTA -n "animCurveTA2040";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 -8.5171375274658203 154 -12.218343734741211
		 156 -9.534092903137207 159 34.068550109863281 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.35400888323783875 0.99796861410140991 
		0.51610279083251953 0.98492836952209473 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.93524205684661865 -0.06370776891708374 
		0.85652667284011841 0.17296287417411804 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.35654982924461365 1 0.47670018672943115 
		0.99961185455322266 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.934276282787323 0 0.87906593084335327 
		-0.02785869687795639 0 0 0;
createNode animCurveTL -n "animCurveTL2038";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 4.9883952140808105 153 4.9883952140808105
		 166 4.9883952140808105 167 4.9883952140808105 170 4.9883952140808105;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2039";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 41.4617919921875 153 41.4617919921875
		 166 41.4617919921875 167 41.4617919921875 170 41.4617919921875;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2040";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 38.623714447021484 153 38.623714447021484
		 166 38.623714447021484 167 38.623714447021484 170 38.623714447021484;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2041";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2042";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2043";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTA -n "animCurveTA2041";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 -16.175403594970703 154 -13.401227951049805
		 156 31.383676528930664 159 64.701614379882813 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.98730868101119995 0.28404736518859863 
		0.08865385502576828 0.99956232309341431 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.15881307423114777 0.95881026983261108 
		0.9960625171661377 0.029584396630525589 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.9999992847442627 0.26453015208244324 
		0.0896419957280159 0.99860215187072754 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 0.0011900976533070207 0.96437740325927734 
		0.99597406387329102 -0.052854679524898529 0 0 0;
createNode animCurveTA -n "animCurveTA2042";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 6.2203903198242187 154 -4.2842168807983398
		 156 -12.706972122192383 159 -24.881561279296875 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99809223413467407 0.25580430030822754 
		0.50611549615859985 0.99936234951019287 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.061739984899759293 -0.96672862768173218 
		-0.86246567964553833 -0.035704471170902252 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.95727425813674927 0.27215060591697693 
		0.49633005261421204 0.99979293346405029 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.28918167948722839 -0.96225470304489136 
		-0.86813384294509888 0.020349957048892975 0 0 0;
createNode animCurveTA -n "animCurveTA2043";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 2.5884246826171875 154 -15.947980880737303
		 156 -28.974962234497067 159 -10.35369873046875 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99966883659362793 0.11823382973670959 
		0.99999970197677612 0.46541664004325867 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.025731788948178291 -0.99298584461212158 
		-0.00069806532701477408 0.88509172201156616 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.90296715497970581 0.12316914647817612 
		0.99802225828170776 0.47550225257873535 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.42970949411392212 -0.99238568544387817 
		0.06286071240901947 0.8797144889831543 0 0 0;
createNode animCurveTL -n "animCurveTL2041";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1.1630247831344604 153 1.1630247831344604
		 166 1.1630247831344604 167 1.1630247831344604 170 1.1630247831344604;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2042";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 2.0187394618988037 153 2.0187394618988037
		 166 2.0187394618988037 167 2.0187394618988037 170 2.0187394618988037;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2043";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 27.637619018554688 153 27.637619018554688
		 166 27.637619018554688 167 27.637619018554688 170 27.637619018554688;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2044";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2045";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2046";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 1 153 1 166 1 167 1 170 1;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTA -n "animCurveTA2044";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 9.655735969543457 154 7.1078367233276367
		 156 -22.907220840454102 159 -38.622943878173828 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.9954216480255127 0.30698448419570923 
		0.14932645857334137 1 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.095580808818340302 -0.95171451568603516 
		-0.98878800868988037 -0.0002496098168194294 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.99999946355819702 0.29033005237579346 
		0.1517709493637085 0.99950122833251953 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.0010930185671895742 -0.95692658424377441 
		-0.98841571807861328 0.031579442322254181 0 0 0;
createNode animCurveTA -n "animCurveTA2045";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 9.6782770156860352 154 -13.420051574707031
		 156 -47.395206451416016 159 -38.713108062744141 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99540042877197266 0.074051022529602051 
		0.99204748868942261 0.26779326796531677 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.095801882445812225 -0.99725443124771118 
		-0.1258644312620163 0.96347635984420776 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.89664655923843384 0.074867747724056244 
		1 0.26524996757507324 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.44274711608886719 -0.99719351530075073 
		0 0.9641796350479126 0 0 0;
createNode animCurveTA -n "animCurveTA2046";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  151 0 153 8.7283201217651367 154 7.5561332702636719
		 156 1.8036541938781738 159 -34.913280487060547 166 0 167 0 170 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes no yes yes;
	setAttr -s 8 ".kix[0:7]"  1 0.99625420570373535 0.76548850536346436 
		0.3099096417427063 0.99166738986968994 1 1 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.086472727358341217 -0.64344954490661621 
		-0.95076602697372437 -0.12882427871227264 0 0 0;
	setAttr -s 8 ".kox[0:7]"  1 0.99980276823043823 0.76976317167282104 
		0.29660657048225403 0.99959242343902588 1 1 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.019859744235873222 -0.63832956552505493 
		-0.95499974489212036 0.028548901900649071 0 0 0;
createNode animCurveTL -n "animCurveTL2044";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 4.9883952140808105 153 4.9883952140808105
		 166 4.9883952140808105 167 4.9883952140808105 170 4.9883952140808105;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2045";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 41.4617919921875 153 41.4617919921875
		 166 41.4617919921875 167 41.4617919921875 170 41.4617919921875;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTL -n "animCurveTL2046";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 -38.180568695068359 153 -38.180568695068359
		 166 -38.180568695068359 167 -38.180568695068359 170 -38.180568695068359;
	setAttr -s 5 ".kix[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".kiy[0:4]"  0 0 0 0 0;
	setAttr -s 5 ".kox[0:4]"  1 1 1 1 1;
	setAttr -s 5 ".koy[0:4]"  0 0 0 0 0;
createNode animCurveTU -n "animCurveTU2047";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2048";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2049";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2047";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 -9.5584049224853516 152 -8.4336709976196289
		 154 -6.8514342308044434 156 -6.8897223472595215 170 -9.5584049224853516;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.93541437387466431 0.98718023300170898 
		0.99749821424484253 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.35355332493782043 0.15960939228534698 
		-0.070690974593162537 0;
	setAttr -s 5 ".kox[0:4]"  1 0.93541437387466431 0.98718023300170898 
		0.99749821424484253 1;
	setAttr -s 5 ".koy[0:4]"  0 0.35355332493782043 0.15960939228534698 
		-0.070690974593162537 0;
createNode animCurveTA -n "animCurveTA2048";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 -14.087939262390137 152 -12.858281135559082
		 154 -13.290823936462402 156 -13.977996826171875 170 -14.087939262390137;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.99386328458786011 0.99319553375244141 
		0.99978232383728027 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.11061523109674454 -0.11645859479904175 
		-0.020863868296146393 0;
	setAttr -s 5 ".kox[0:4]"  1 0.99386328458786011 0.99319553375244141 
		0.99978232383728027 1;
	setAttr -s 5 ".koy[0:4]"  0 0.11061523109674454 -0.11645859479904175 
		-0.020863868296146393 0;
createNode animCurveTA -n "animCurveTA2049";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 -2.2710940837860107 152 5.3273873329162598
		 154 2.1826486587524414 156 -10.402770042419434 170 -2.2710940837860107;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.84919464588165283 0.51893174648284912 
		0.9932708740234375 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.52807998657226563 -0.85481560230255127 
		-0.11581403762102127 0;
	setAttr -s 5 ".kox[0:4]"  1 0.84919464588165283 0.51893174648284912 
		0.9932708740234375 1;
	setAttr -s 5 ".koy[0:4]"  0 0.52807998657226563 -0.85481560230255127 
		-0.11581403762102127 0;
createNode animCurveTL -n "animCurveTL2047";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 32.845657348632812 170 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2048";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 17.186578750610352 170 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2049";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 11.930496215820313 170 11.930496215820313;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2050";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2051";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2052";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2050";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 -0.89352136850357056 152 0.2841261625289917
		 154 1.833038926124573 156 1.7483696937561035 170 -0.89352136850357056;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.93456625938415527 0.98844748735427856 
		0.99746209383010864 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.35578903555870056 0.15156397223472595 
		-0.071199990808963776 0;
	setAttr -s 5 ".kox[0:4]"  1 0.93456625938415527 0.98844748735427856 
		0.99746209383010864 1;
	setAttr -s 5 ".koy[0:4]"  0 0.35578903555870056 0.15156397223472595 
		-0.071199990808963776 0;
createNode animCurveTA -n "animCurveTA2051";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 11.041102409362793 152 12.21494197845459
		 154 11.687926292419434 156 11.006577491760254 170 11.041102409362793;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.99594652652740479 0.99208873510360718 
		0.99985665082931519 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.08994758129119873 -0.12553872168064117 
		-0.016931381076574326 0;
	setAttr -s 5 ".kox[0:4]"  1 0.99594652652740479 0.99208873510360718 
		0.99985665082931519 1;
	setAttr -s 5 ".koy[0:4]"  0 0.08994758129119873 -0.12553872168064117 
		-0.016931381076574326 0;
createNode animCurveTA -n "animCurveTA2052";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0.32489952445030212 152 8.4228382110595703
		 154 5.9565691947937012 156 -6.6542701721191406 170 0.32489952445030212;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.78608334064483643 0.53507012128829956 
		0.98930525779724121 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.61812049150466919 -0.84480762481689453 
		-0.14585989713668823 0;
	setAttr -s 5 ".kox[0:4]"  1 0.78608334064483643 0.53507012128829956 
		0.98930525779724121 1;
	setAttr -s 5 ".koy[0:4]"  0 0.61812049150466919 -0.84480762481689453 
		-0.14585989713668823 0;
createNode animCurveTL -n "animCurveTL2050";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 32.845657348632812 170 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2051";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 17.186578750610352 170 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2052";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -11.48735237121582 170 -11.48735237121582;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2053";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2054";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2055";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2053";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2054";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2055";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2053";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 47.368160247802734 170 47.368160247802734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2054";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 26.913848876953125 153 47.675891876220703
		 155 5.897913932800293 163 9.6382045745849609 170 26.913848876953125;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.0079302527010440826 0.010953388176858425 
		0.029726199805736542 1;
	setAttr -s 5 ".kiy[0:4]"  0 -0.99996858835220337 -0.99993997812271118 
		0.99955809116363525 0;
	setAttr -s 5 ".kox[0:4]"  1 0.0079302527010440826 0.010953388176858425 
		0.029726199805736542 1;
	setAttr -s 5 ".koy[0:4]"  0 -0.99996858835220337 -0.99993997812271118 
		0.99955809116363525 0;
createNode animCurveTL -n "animCurveTL2055";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0.22157172858715057 170 0.22157172858715057;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2056";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2057";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2058";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2056";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 0 153 -6.0033698081970215 154 -7.4241185188293466
		 156 -5.6832795143127441 159 -3.4084749221801758 170 0;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.69428634643554688 0.99900269508361816 
		0.94780385494232178 0.98584878444671631 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.71969890594482422 0.044648464769124985 
		0.31885397434234619 0.16763694584369659 0;
	setAttr -s 6 ".kox[0:5]"  1 0.69428634643554688 0.99900269508361816 
		0.94780385494232178 0.98584878444671631 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.71969890594482422 0.044648464769124985 
		0.31885397434234619 0.16763694584369659 0;
createNode animCurveTA -n "animCurveTA2057";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 0 153 0.72100627422332764 154 0.064429111778736115
		 156 -2.1434977054595947 159 -2.9215860366821289 170 0;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.99995952844619751 0.92848938703536987 
		0.97010689973831177 0.99794983863830566 1;
	setAttr -s 6 ".kiy[0:5]"  0 0.0089956382289528847 -0.37135878205299377 
		-0.24267768859863281 0.064001798629760742 0;
	setAttr -s 6 ".kox[0:5]"  1 0.99995952844619751 0.92848938703536987 
		0.97010689973831177 0.99794983863830566 1;
	setAttr -s 6 ".koy[0:5]"  0 0.0089956382289528847 -0.37135878205299377 
		-0.24267768859863281 0.064001798629760742 0;
createNode animCurveTA -n "animCurveTA2058";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  151 0 153 -28.952939987182614 154 -26.441411972045898
		 156 4.3605389595031738 159 5.801365852355957 170 0;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.26144105195999146 0.21018482744693756 
		0.34718284010887146 0.99159634113311768 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.96521943807601929 0.97766172885894775 
		0.93779754638671875 -0.12937057018280029 0;
	setAttr -s 6 ".kox[0:5]"  1 0.26144105195999146 0.21018482744693756 
		0.34718284010887146 0.99159634113311768 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.96521943807601929 0.97766172885894775 
		0.93779754638671875 -0.12937057018280029 0;
createNode animCurveTL -n "animCurveTL2056";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 0.55634701251983643 153 10.706847190856934
		 154 7.5712356567382812 155 14.348981857299805 156 11.461584091186523 159 -1.6391463279724121
		 170 0.55634701251983643;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.017816411331295967 0.022874411195516586 
		0.021415656432509422 0.010423825122416019 0.053414773195981979 1;
	setAttr -s 7 ".kiy[0:6]"  0 0.99984127283096313 0.99973839521408081 
		0.9997706413269043 -0.99994570016860962 -0.99857240915298462 0;
	setAttr -s 7 ".kox[0:6]"  1 0.017816411331295967 0.022874411195516586 
		0.021415656432509422 0.010423825122416019 0.053414773195981979 1;
	setAttr -s 7 ".koy[0:6]"  0 0.99984127283096313 0.99973839521408081 
		0.9997706413269043 -0.99994570016860962 -0.99857240915298462 0;
createNode animCurveTL -n "animCurveTL2057";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 28.874954223632813 153 33.004104614257813
		 154 32.135452270507812 155 35.834911346435547 156 34.049121856689453 159 27.881868362426758
		 170 28.874954223632813;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.038309544324874878 0.029425330460071564 
		0.04350527748465538 0.02095172181725502 0.11202991008758545 1;
	setAttr -s 7 ".kiy[0:6]"  0 0.99926590919494629 0.99956697225570679 
		0.99905318021774292 -0.99978047609329224 -0.99370485544204712 0;
	setAttr -s 7 ".kox[0:6]"  1 0.038309544324874878 0.029425330460071564 
		0.04350527748465538 0.02095172181725502 0.11202991008758545 1;
	setAttr -s 7 ".koy[0:6]"  0 0.99926590919494629 0.99956697225570679 
		0.99905318021774292 -0.99978047609329224 -0.99370485544204712 0;
createNode animCurveTL -n "animCurveTL2058";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 0 153 1.8275718688964844 154 1.616051197052002
		 155 3.2285187244415283 156 2.6150286197662354 159 -0.5034019947052002 170 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.077118687331676483 0.059378735721111298 
		0.083130039274692535 0.044615227729082108 0.21771855652332306 1;
	setAttr -s 7 ".kiy[0:6]"  0 0.99702197313308716 0.99823552370071411 
		0.99653869867324829 -0.99900424480438232 -0.97601157426834106 0;
	setAttr -s 7 ".kox[0:6]"  1 0.077118687331676483 0.059378735721111298 
		0.083130039274692535 0.044615227729082108 0.21771855652332306 1;
	setAttr -s 7 ".koy[0:6]"  0 0.99702197313308716 0.99823552370071411 
		0.99653869867324829 -0.99900424480438232 -0.97601157426834106 0;
createNode animCurveTU -n "animCurveTU2059";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2060";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2061";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2059";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2060";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2061";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2059";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -1.4725730419158936 170 -1.4725730419158936;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2060";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 25.007797241210938 170 25.007797241210938;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2061";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2062";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2063";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2064";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2062";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2063";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2064";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2062";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -0.28501001000404358 170 -0.28501001000404358;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2063";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2064";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2065";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2066";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2067";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2065";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2066";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2067";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 0 152 -6.7621951103210449 153 -0.10713867843151093
		 154 24.928863525390625 157 29.138395309448242 164 2.4281995296478271 170 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.9997483491897583 0.14898033440113068 
		0.31039384007453918 0.72771733999252319 0.72903460264205933 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.022433377802371979 0.98884022235870361 
		0.9506080150604248 -0.68587714433670044 -0.68447685241699219 0;
	setAttr -s 7 ".kox[0:6]"  1 0.9997483491897583 0.14898033440113068 
		0.31039384007453918 0.72771733999252319 0.72903460264205933 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.022433377802371979 0.98884022235870361 
		0.9506080150604248 -0.68587714433670044 -0.68447685241699219 0;
createNode animCurveTL -n "animCurveTL2065";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  151 0 154 31.808847427368164 157 37.231517791748047
		 164 2.70853590965271 170 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.0067145870998501778 0.014316831715404987 
		0.01454707607626915 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.9999774694442749 -0.9998975396156311 
		-0.99989420175552368 0;
	setAttr -s 5 ".kox[0:4]"  1 0.0067145870998501778 0.014316831715404987 
		0.01454707607626915 1;
	setAttr -s 5 ".koy[0:4]"  0 0.9999774694442749 -0.9998975396156311 
		-0.99989420175552368 0;
createNode animCurveTL -n "animCurveTL2066";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  151 0 152 15.668669700622559 153 26.189048767089844
		 154 27.974813461303711 161 -4.2606906890869141 164 -2.3389010429382324 170 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.0031819811556488276 0.0067715030163526535 
		0.010946349240839481 0.013743868097662926 0.087674945592880249 1;
	setAttr -s 7 ".kiy[0:6]"  0 0.99999493360519409 0.99997705221176147 
		-0.99994009733200073 -0.99990552663803101 0.99614906311035156 0;
	setAttr -s 7 ".kox[0:6]"  1 0.0031819811556488276 0.0067715030163526535 
		0.010946349240839481 0.013743868097662926 0.087674945592880249 1;
	setAttr -s 7 ".koy[0:6]"  0 0.99999493360519409 0.99997705221176147 
		-0.99994009733200073 -0.99990552663803101 0.99614906311035156 0;
createNode animCurveTL -n "animCurveTL2067";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2068";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2069";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU2070";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 1 170 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2068";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2069";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA2070";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 0 170 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2068";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 2.0856802463531494 170 2.0856802463531494;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2069";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 -5.0555992126464844 170 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL2070";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  151 28.250843048095703 170 28.250843048095703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
select -ne :time1;
	setAttr ".o" 240;
	setAttr ".unw" 240;
select -ne :renderPartition;
	setAttr -s 4 ".st";
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :defaultTextureList1;
	setAttr -s 2 ".tx";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 2 ".u";
select -ne :defaultRenderingList1;
select -ne :renderGlobalsList1;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :characterPartition;
connectAttr "attackSource.cl" "clipLibrary1.sc[0]";
connectAttr "animCurveTU1981.a" "clipLibrary1.cel[0].cev[0].cevr";
connectAttr "animCurveTU1982.a" "clipLibrary1.cel[0].cev[1].cevr";
connectAttr "animCurveTU1983.a" "clipLibrary1.cel[0].cev[2].cevr";
connectAttr "animCurveTA1981.a" "clipLibrary1.cel[0].cev[3].cevr";
connectAttr "animCurveTA1982.a" "clipLibrary1.cel[0].cev[4].cevr";
connectAttr "animCurveTA1983.a" "clipLibrary1.cel[0].cev[5].cevr";
connectAttr "animCurveTL1981.a" "clipLibrary1.cel[0].cev[6].cevr";
connectAttr "animCurveTL1982.a" "clipLibrary1.cel[0].cev[7].cevr";
connectAttr "animCurveTL1983.a" "clipLibrary1.cel[0].cev[8].cevr";
connectAttr "animCurveTU1984.a" "clipLibrary1.cel[0].cev[9].cevr";
connectAttr "animCurveTU1985.a" "clipLibrary1.cel[0].cev[10].cevr";
connectAttr "animCurveTU1986.a" "clipLibrary1.cel[0].cev[11].cevr";
connectAttr "animCurveTA1984.a" "clipLibrary1.cel[0].cev[12].cevr";
connectAttr "animCurveTA1985.a" "clipLibrary1.cel[0].cev[13].cevr";
connectAttr "animCurveTA1986.a" "clipLibrary1.cel[0].cev[14].cevr";
connectAttr "animCurveTL1984.a" "clipLibrary1.cel[0].cev[15].cevr";
connectAttr "animCurveTL1985.a" "clipLibrary1.cel[0].cev[16].cevr";
connectAttr "animCurveTL1986.a" "clipLibrary1.cel[0].cev[17].cevr";
connectAttr "animCurveTU1987.a" "clipLibrary1.cel[0].cev[18].cevr";
connectAttr "animCurveTU1988.a" "clipLibrary1.cel[0].cev[19].cevr";
connectAttr "animCurveTU1989.a" "clipLibrary1.cel[0].cev[20].cevr";
connectAttr "animCurveTA1987.a" "clipLibrary1.cel[0].cev[21].cevr";
connectAttr "animCurveTA1988.a" "clipLibrary1.cel[0].cev[22].cevr";
connectAttr "animCurveTA1989.a" "clipLibrary1.cel[0].cev[23].cevr";
connectAttr "animCurveTL1987.a" "clipLibrary1.cel[0].cev[24].cevr";
connectAttr "animCurveTL1988.a" "clipLibrary1.cel[0].cev[25].cevr";
connectAttr "animCurveTL1989.a" "clipLibrary1.cel[0].cev[26].cevr";
connectAttr "animCurveTU1990.a" "clipLibrary1.cel[0].cev[27].cevr";
connectAttr "animCurveTU1991.a" "clipLibrary1.cel[0].cev[28].cevr";
connectAttr "animCurveTU1992.a" "clipLibrary1.cel[0].cev[29].cevr";
connectAttr "animCurveTA1990.a" "clipLibrary1.cel[0].cev[30].cevr";
connectAttr "animCurveTA1991.a" "clipLibrary1.cel[0].cev[31].cevr";
connectAttr "animCurveTA1992.a" "clipLibrary1.cel[0].cev[32].cevr";
connectAttr "animCurveTL1990.a" "clipLibrary1.cel[0].cev[33].cevr";
connectAttr "animCurveTL1991.a" "clipLibrary1.cel[0].cev[34].cevr";
connectAttr "animCurveTL1992.a" "clipLibrary1.cel[0].cev[35].cevr";
connectAttr "animCurveTU1993.a" "clipLibrary1.cel[0].cev[36].cevr";
connectAttr "animCurveTU1994.a" "clipLibrary1.cel[0].cev[37].cevr";
connectAttr "animCurveTU1995.a" "clipLibrary1.cel[0].cev[38].cevr";
connectAttr "animCurveTA1993.a" "clipLibrary1.cel[0].cev[39].cevr";
connectAttr "animCurveTA1994.a" "clipLibrary1.cel[0].cev[40].cevr";
connectAttr "animCurveTA1995.a" "clipLibrary1.cel[0].cev[41].cevr";
connectAttr "animCurveTL1993.a" "clipLibrary1.cel[0].cev[42].cevr";
connectAttr "animCurveTL1994.a" "clipLibrary1.cel[0].cev[43].cevr";
connectAttr "animCurveTL1995.a" "clipLibrary1.cel[0].cev[44].cevr";
connectAttr "animCurveTU1996.a" "clipLibrary1.cel[0].cev[45].cevr";
connectAttr "animCurveTU1997.a" "clipLibrary1.cel[0].cev[46].cevr";
connectAttr "animCurveTU1998.a" "clipLibrary1.cel[0].cev[47].cevr";
connectAttr "animCurveTA1996.a" "clipLibrary1.cel[0].cev[48].cevr";
connectAttr "animCurveTA1997.a" "clipLibrary1.cel[0].cev[49].cevr";
connectAttr "animCurveTA1998.a" "clipLibrary1.cel[0].cev[50].cevr";
connectAttr "animCurveTL1996.a" "clipLibrary1.cel[0].cev[51].cevr";
connectAttr "animCurveTL1997.a" "clipLibrary1.cel[0].cev[52].cevr";
connectAttr "animCurveTL1998.a" "clipLibrary1.cel[0].cev[53].cevr";
connectAttr "animCurveTU1999.a" "clipLibrary1.cel[0].cev[54].cevr";
connectAttr "animCurveTU2000.a" "clipLibrary1.cel[0].cev[55].cevr";
connectAttr "animCurveTU2001.a" "clipLibrary1.cel[0].cev[56].cevr";
connectAttr "animCurveTA1999.a" "clipLibrary1.cel[0].cev[57].cevr";
connectAttr "animCurveTA2000.a" "clipLibrary1.cel[0].cev[58].cevr";
connectAttr "animCurveTA2001.a" "clipLibrary1.cel[0].cev[59].cevr";
connectAttr "animCurveTL1999.a" "clipLibrary1.cel[0].cev[60].cevr";
connectAttr "animCurveTL2000.a" "clipLibrary1.cel[0].cev[61].cevr";
connectAttr "animCurveTL2001.a" "clipLibrary1.cel[0].cev[62].cevr";
connectAttr "animCurveTU2002.a" "clipLibrary1.cel[0].cev[63].cevr";
connectAttr "animCurveTU2003.a" "clipLibrary1.cel[0].cev[64].cevr";
connectAttr "animCurveTU2004.a" "clipLibrary1.cel[0].cev[65].cevr";
connectAttr "animCurveTA2002.a" "clipLibrary1.cel[0].cev[66].cevr";
connectAttr "animCurveTA2003.a" "clipLibrary1.cel[0].cev[67].cevr";
connectAttr "animCurveTA2004.a" "clipLibrary1.cel[0].cev[68].cevr";
connectAttr "animCurveTL2002.a" "clipLibrary1.cel[0].cev[69].cevr";
connectAttr "animCurveTL2003.a" "clipLibrary1.cel[0].cev[70].cevr";
connectAttr "animCurveTL2004.a" "clipLibrary1.cel[0].cev[71].cevr";
connectAttr "animCurveTU2005.a" "clipLibrary1.cel[0].cev[72].cevr";
connectAttr "animCurveTU2006.a" "clipLibrary1.cel[0].cev[73].cevr";
connectAttr "animCurveTU2007.a" "clipLibrary1.cel[0].cev[74].cevr";
connectAttr "animCurveTA2005.a" "clipLibrary1.cel[0].cev[75].cevr";
connectAttr "animCurveTA2006.a" "clipLibrary1.cel[0].cev[76].cevr";
connectAttr "animCurveTA2007.a" "clipLibrary1.cel[0].cev[77].cevr";
connectAttr "animCurveTL2005.a" "clipLibrary1.cel[0].cev[78].cevr";
connectAttr "animCurveTL2006.a" "clipLibrary1.cel[0].cev[79].cevr";
connectAttr "animCurveTL2007.a" "clipLibrary1.cel[0].cev[80].cevr";
connectAttr "animCurveTU2008.a" "clipLibrary1.cel[0].cev[81].cevr";
connectAttr "animCurveTU2009.a" "clipLibrary1.cel[0].cev[82].cevr";
connectAttr "animCurveTU2010.a" "clipLibrary1.cel[0].cev[83].cevr";
connectAttr "animCurveTA2008.a" "clipLibrary1.cel[0].cev[84].cevr";
connectAttr "animCurveTA2009.a" "clipLibrary1.cel[0].cev[85].cevr";
connectAttr "animCurveTA2010.a" "clipLibrary1.cel[0].cev[86].cevr";
connectAttr "animCurveTL2008.a" "clipLibrary1.cel[0].cev[87].cevr";
connectAttr "animCurveTL2009.a" "clipLibrary1.cel[0].cev[88].cevr";
connectAttr "animCurveTL2010.a" "clipLibrary1.cel[0].cev[89].cevr";
connectAttr "animCurveTU2011.a" "clipLibrary1.cel[0].cev[90].cevr";
connectAttr "animCurveTU2012.a" "clipLibrary1.cel[0].cev[91].cevr";
connectAttr "animCurveTU2013.a" "clipLibrary1.cel[0].cev[92].cevr";
connectAttr "animCurveTA2011.a" "clipLibrary1.cel[0].cev[93].cevr";
connectAttr "animCurveTA2012.a" "clipLibrary1.cel[0].cev[94].cevr";
connectAttr "animCurveTA2013.a" "clipLibrary1.cel[0].cev[95].cevr";
connectAttr "animCurveTL2011.a" "clipLibrary1.cel[0].cev[96].cevr";
connectAttr "animCurveTL2012.a" "clipLibrary1.cel[0].cev[97].cevr";
connectAttr "animCurveTL2013.a" "clipLibrary1.cel[0].cev[98].cevr";
connectAttr "animCurveTU2014.a" "clipLibrary1.cel[0].cev[99].cevr";
connectAttr "animCurveTU2015.a" "clipLibrary1.cel[0].cev[100].cevr";
connectAttr "animCurveTU2016.a" "clipLibrary1.cel[0].cev[101].cevr";
connectAttr "animCurveTA2014.a" "clipLibrary1.cel[0].cev[102].cevr";
connectAttr "animCurveTA2015.a" "clipLibrary1.cel[0].cev[103].cevr";
connectAttr "animCurveTA2016.a" "clipLibrary1.cel[0].cev[104].cevr";
connectAttr "animCurveTL2014.a" "clipLibrary1.cel[0].cev[105].cevr";
connectAttr "animCurveTL2015.a" "clipLibrary1.cel[0].cev[106].cevr";
connectAttr "animCurveTL2016.a" "clipLibrary1.cel[0].cev[107].cevr";
connectAttr "animCurveTU2017.a" "clipLibrary1.cel[0].cev[108].cevr";
connectAttr "animCurveTU2018.a" "clipLibrary1.cel[0].cev[109].cevr";
connectAttr "animCurveTU2019.a" "clipLibrary1.cel[0].cev[110].cevr";
connectAttr "animCurveTA2017.a" "clipLibrary1.cel[0].cev[111].cevr";
connectAttr "animCurveTA2018.a" "clipLibrary1.cel[0].cev[112].cevr";
connectAttr "animCurveTA2019.a" "clipLibrary1.cel[0].cev[113].cevr";
connectAttr "animCurveTL2017.a" "clipLibrary1.cel[0].cev[114].cevr";
connectAttr "animCurveTL2018.a" "clipLibrary1.cel[0].cev[115].cevr";
connectAttr "animCurveTL2019.a" "clipLibrary1.cel[0].cev[116].cevr";
connectAttr "animCurveTU2020.a" "clipLibrary1.cel[0].cev[117].cevr";
connectAttr "animCurveTU2021.a" "clipLibrary1.cel[0].cev[118].cevr";
connectAttr "animCurveTU2022.a" "clipLibrary1.cel[0].cev[119].cevr";
connectAttr "animCurveTA2020.a" "clipLibrary1.cel[0].cev[120].cevr";
connectAttr "animCurveTA2021.a" "clipLibrary1.cel[0].cev[121].cevr";
connectAttr "animCurveTA2022.a" "clipLibrary1.cel[0].cev[122].cevr";
connectAttr "animCurveTL2020.a" "clipLibrary1.cel[0].cev[123].cevr";
connectAttr "animCurveTL2021.a" "clipLibrary1.cel[0].cev[124].cevr";
connectAttr "animCurveTL2022.a" "clipLibrary1.cel[0].cev[125].cevr";
connectAttr "animCurveTU2023.a" "clipLibrary1.cel[0].cev[126].cevr";
connectAttr "animCurveTU2024.a" "clipLibrary1.cel[0].cev[127].cevr";
connectAttr "animCurveTU2025.a" "clipLibrary1.cel[0].cev[128].cevr";
connectAttr "animCurveTA2023.a" "clipLibrary1.cel[0].cev[129].cevr";
connectAttr "animCurveTA2024.a" "clipLibrary1.cel[0].cev[130].cevr";
connectAttr "animCurveTA2025.a" "clipLibrary1.cel[0].cev[131].cevr";
connectAttr "animCurveTL2023.a" "clipLibrary1.cel[0].cev[132].cevr";
connectAttr "animCurveTL2024.a" "clipLibrary1.cel[0].cev[133].cevr";
connectAttr "animCurveTL2025.a" "clipLibrary1.cel[0].cev[134].cevr";
connectAttr "animCurveTU2026.a" "clipLibrary1.cel[0].cev[135].cevr";
connectAttr "animCurveTU2027.a" "clipLibrary1.cel[0].cev[136].cevr";
connectAttr "animCurveTU2028.a" "clipLibrary1.cel[0].cev[137].cevr";
connectAttr "animCurveTA2026.a" "clipLibrary1.cel[0].cev[138].cevr";
connectAttr "animCurveTA2027.a" "clipLibrary1.cel[0].cev[139].cevr";
connectAttr "animCurveTA2028.a" "clipLibrary1.cel[0].cev[140].cevr";
connectAttr "animCurveTL2026.a" "clipLibrary1.cel[0].cev[141].cevr";
connectAttr "animCurveTL2027.a" "clipLibrary1.cel[0].cev[142].cevr";
connectAttr "animCurveTL2028.a" "clipLibrary1.cel[0].cev[143].cevr";
connectAttr "animCurveTU2029.a" "clipLibrary1.cel[0].cev[144].cevr";
connectAttr "animCurveTU2030.a" "clipLibrary1.cel[0].cev[145].cevr";
connectAttr "animCurveTU2031.a" "clipLibrary1.cel[0].cev[146].cevr";
connectAttr "animCurveTA2029.a" "clipLibrary1.cel[0].cev[147].cevr";
connectAttr "animCurveTA2030.a" "clipLibrary1.cel[0].cev[148].cevr";
connectAttr "animCurveTA2031.a" "clipLibrary1.cel[0].cev[149].cevr";
connectAttr "animCurveTL2029.a" "clipLibrary1.cel[0].cev[150].cevr";
connectAttr "animCurveTL2030.a" "clipLibrary1.cel[0].cev[151].cevr";
connectAttr "animCurveTL2031.a" "clipLibrary1.cel[0].cev[152].cevr";
connectAttr "animCurveTU2032.a" "clipLibrary1.cel[0].cev[153].cevr";
connectAttr "animCurveTU2033.a" "clipLibrary1.cel[0].cev[154].cevr";
connectAttr "animCurveTU2034.a" "clipLibrary1.cel[0].cev[155].cevr";
connectAttr "animCurveTA2032.a" "clipLibrary1.cel[0].cev[156].cevr";
connectAttr "animCurveTA2033.a" "clipLibrary1.cel[0].cev[157].cevr";
connectAttr "animCurveTA2034.a" "clipLibrary1.cel[0].cev[158].cevr";
connectAttr "animCurveTL2032.a" "clipLibrary1.cel[0].cev[159].cevr";
connectAttr "animCurveTL2033.a" "clipLibrary1.cel[0].cev[160].cevr";
connectAttr "animCurveTL2034.a" "clipLibrary1.cel[0].cev[161].cevr";
connectAttr "animCurveTU2035.a" "clipLibrary1.cel[0].cev[162].cevr";
connectAttr "animCurveTU2036.a" "clipLibrary1.cel[0].cev[163].cevr";
connectAttr "animCurveTU2037.a" "clipLibrary1.cel[0].cev[164].cevr";
connectAttr "animCurveTA2035.a" "clipLibrary1.cel[0].cev[165].cevr";
connectAttr "animCurveTA2036.a" "clipLibrary1.cel[0].cev[166].cevr";
connectAttr "animCurveTA2037.a" "clipLibrary1.cel[0].cev[167].cevr";
connectAttr "animCurveTL2035.a" "clipLibrary1.cel[0].cev[168].cevr";
connectAttr "animCurveTL2036.a" "clipLibrary1.cel[0].cev[169].cevr";
connectAttr "animCurveTL2037.a" "clipLibrary1.cel[0].cev[170].cevr";
connectAttr "animCurveTU2038.a" "clipLibrary1.cel[0].cev[171].cevr";
connectAttr "animCurveTU2039.a" "clipLibrary1.cel[0].cev[172].cevr";
connectAttr "animCurveTU2040.a" "clipLibrary1.cel[0].cev[173].cevr";
connectAttr "animCurveTA2038.a" "clipLibrary1.cel[0].cev[174].cevr";
connectAttr "animCurveTA2039.a" "clipLibrary1.cel[0].cev[175].cevr";
connectAttr "animCurveTA2040.a" "clipLibrary1.cel[0].cev[176].cevr";
connectAttr "animCurveTL2038.a" "clipLibrary1.cel[0].cev[177].cevr";
connectAttr "animCurveTL2039.a" "clipLibrary1.cel[0].cev[178].cevr";
connectAttr "animCurveTL2040.a" "clipLibrary1.cel[0].cev[179].cevr";
connectAttr "animCurveTU2041.a" "clipLibrary1.cel[0].cev[180].cevr";
connectAttr "animCurveTU2042.a" "clipLibrary1.cel[0].cev[181].cevr";
connectAttr "animCurveTU2043.a" "clipLibrary1.cel[0].cev[182].cevr";
connectAttr "animCurveTA2041.a" "clipLibrary1.cel[0].cev[183].cevr";
connectAttr "animCurveTA2042.a" "clipLibrary1.cel[0].cev[184].cevr";
connectAttr "animCurveTA2043.a" "clipLibrary1.cel[0].cev[185].cevr";
connectAttr "animCurveTL2041.a" "clipLibrary1.cel[0].cev[186].cevr";
connectAttr "animCurveTL2042.a" "clipLibrary1.cel[0].cev[187].cevr";
connectAttr "animCurveTL2043.a" "clipLibrary1.cel[0].cev[188].cevr";
connectAttr "animCurveTU2044.a" "clipLibrary1.cel[0].cev[189].cevr";
connectAttr "animCurveTU2045.a" "clipLibrary1.cel[0].cev[190].cevr";
connectAttr "animCurveTU2046.a" "clipLibrary1.cel[0].cev[191].cevr";
connectAttr "animCurveTA2044.a" "clipLibrary1.cel[0].cev[192].cevr";
connectAttr "animCurveTA2045.a" "clipLibrary1.cel[0].cev[193].cevr";
connectAttr "animCurveTA2046.a" "clipLibrary1.cel[0].cev[194].cevr";
connectAttr "animCurveTL2044.a" "clipLibrary1.cel[0].cev[195].cevr";
connectAttr "animCurveTL2045.a" "clipLibrary1.cel[0].cev[196].cevr";
connectAttr "animCurveTL2046.a" "clipLibrary1.cel[0].cev[197].cevr";
connectAttr "animCurveTU2047.a" "clipLibrary1.cel[0].cev[198].cevr";
connectAttr "animCurveTU2048.a" "clipLibrary1.cel[0].cev[199].cevr";
connectAttr "animCurveTU2049.a" "clipLibrary1.cel[0].cev[200].cevr";
connectAttr "animCurveTA2047.a" "clipLibrary1.cel[0].cev[201].cevr";
connectAttr "animCurveTA2048.a" "clipLibrary1.cel[0].cev[202].cevr";
connectAttr "animCurveTA2049.a" "clipLibrary1.cel[0].cev[203].cevr";
connectAttr "animCurveTL2047.a" "clipLibrary1.cel[0].cev[204].cevr";
connectAttr "animCurveTL2048.a" "clipLibrary1.cel[0].cev[205].cevr";
connectAttr "animCurveTL2049.a" "clipLibrary1.cel[0].cev[206].cevr";
connectAttr "animCurveTU2050.a" "clipLibrary1.cel[0].cev[207].cevr";
connectAttr "animCurveTU2051.a" "clipLibrary1.cel[0].cev[208].cevr";
connectAttr "animCurveTU2052.a" "clipLibrary1.cel[0].cev[209].cevr";
connectAttr "animCurveTA2050.a" "clipLibrary1.cel[0].cev[210].cevr";
connectAttr "animCurveTA2051.a" "clipLibrary1.cel[0].cev[211].cevr";
connectAttr "animCurveTA2052.a" "clipLibrary1.cel[0].cev[212].cevr";
connectAttr "animCurveTL2050.a" "clipLibrary1.cel[0].cev[213].cevr";
connectAttr "animCurveTL2051.a" "clipLibrary1.cel[0].cev[214].cevr";
connectAttr "animCurveTL2052.a" "clipLibrary1.cel[0].cev[215].cevr";
connectAttr "animCurveTU2053.a" "clipLibrary1.cel[0].cev[216].cevr";
connectAttr "animCurveTU2054.a" "clipLibrary1.cel[0].cev[217].cevr";
connectAttr "animCurveTU2055.a" "clipLibrary1.cel[0].cev[218].cevr";
connectAttr "animCurveTA2053.a" "clipLibrary1.cel[0].cev[219].cevr";
connectAttr "animCurveTA2054.a" "clipLibrary1.cel[0].cev[220].cevr";
connectAttr "animCurveTA2055.a" "clipLibrary1.cel[0].cev[221].cevr";
connectAttr "animCurveTL2053.a" "clipLibrary1.cel[0].cev[222].cevr";
connectAttr "animCurveTL2054.a" "clipLibrary1.cel[0].cev[223].cevr";
connectAttr "animCurveTL2055.a" "clipLibrary1.cel[0].cev[224].cevr";
connectAttr "animCurveTU2056.a" "clipLibrary1.cel[0].cev[225].cevr";
connectAttr "animCurveTU2057.a" "clipLibrary1.cel[0].cev[226].cevr";
connectAttr "animCurveTU2058.a" "clipLibrary1.cel[0].cev[227].cevr";
connectAttr "animCurveTA2056.a" "clipLibrary1.cel[0].cev[228].cevr";
connectAttr "animCurveTA2057.a" "clipLibrary1.cel[0].cev[229].cevr";
connectAttr "animCurveTA2058.a" "clipLibrary1.cel[0].cev[230].cevr";
connectAttr "animCurveTL2056.a" "clipLibrary1.cel[0].cev[231].cevr";
connectAttr "animCurveTL2057.a" "clipLibrary1.cel[0].cev[232].cevr";
connectAttr "animCurveTL2058.a" "clipLibrary1.cel[0].cev[233].cevr";
connectAttr "animCurveTU2059.a" "clipLibrary1.cel[0].cev[234].cevr";
connectAttr "animCurveTU2060.a" "clipLibrary1.cel[0].cev[235].cevr";
connectAttr "animCurveTU2061.a" "clipLibrary1.cel[0].cev[236].cevr";
connectAttr "animCurveTA2059.a" "clipLibrary1.cel[0].cev[237].cevr";
connectAttr "animCurveTA2060.a" "clipLibrary1.cel[0].cev[238].cevr";
connectAttr "animCurveTA2061.a" "clipLibrary1.cel[0].cev[239].cevr";
connectAttr "animCurveTL2059.a" "clipLibrary1.cel[0].cev[240].cevr";
connectAttr "animCurveTL2060.a" "clipLibrary1.cel[0].cev[241].cevr";
connectAttr "animCurveTL2061.a" "clipLibrary1.cel[0].cev[242].cevr";
connectAttr "animCurveTU2062.a" "clipLibrary1.cel[0].cev[243].cevr";
connectAttr "animCurveTU2063.a" "clipLibrary1.cel[0].cev[244].cevr";
connectAttr "animCurveTU2064.a" "clipLibrary1.cel[0].cev[245].cevr";
connectAttr "animCurveTA2062.a" "clipLibrary1.cel[0].cev[246].cevr";
connectAttr "animCurveTA2063.a" "clipLibrary1.cel[0].cev[247].cevr";
connectAttr "animCurveTA2064.a" "clipLibrary1.cel[0].cev[248].cevr";
connectAttr "animCurveTL2062.a" "clipLibrary1.cel[0].cev[249].cevr";
connectAttr "animCurveTL2063.a" "clipLibrary1.cel[0].cev[250].cevr";
connectAttr "animCurveTL2064.a" "clipLibrary1.cel[0].cev[251].cevr";
connectAttr "animCurveTU2065.a" "clipLibrary1.cel[0].cev[252].cevr";
connectAttr "animCurveTU2066.a" "clipLibrary1.cel[0].cev[253].cevr";
connectAttr "animCurveTU2067.a" "clipLibrary1.cel[0].cev[254].cevr";
connectAttr "animCurveTA2065.a" "clipLibrary1.cel[0].cev[255].cevr";
connectAttr "animCurveTA2066.a" "clipLibrary1.cel[0].cev[256].cevr";
connectAttr "animCurveTA2067.a" "clipLibrary1.cel[0].cev[257].cevr";
connectAttr "animCurveTL2065.a" "clipLibrary1.cel[0].cev[258].cevr";
connectAttr "animCurveTL2066.a" "clipLibrary1.cel[0].cev[259].cevr";
connectAttr "animCurveTL2067.a" "clipLibrary1.cel[0].cev[260].cevr";
connectAttr "animCurveTU2068.a" "clipLibrary1.cel[0].cev[261].cevr";
connectAttr "animCurveTU2069.a" "clipLibrary1.cel[0].cev[262].cevr";
connectAttr "animCurveTU2070.a" "clipLibrary1.cel[0].cev[263].cevr";
connectAttr "animCurveTA2068.a" "clipLibrary1.cel[0].cev[264].cevr";
connectAttr "animCurveTA2069.a" "clipLibrary1.cel[0].cev[265].cevr";
connectAttr "animCurveTA2070.a" "clipLibrary1.cel[0].cev[266].cevr";
connectAttr "animCurveTL2068.a" "clipLibrary1.cel[0].cev[267].cevr";
connectAttr "animCurveTL2069.a" "clipLibrary1.cel[0].cev[268].cevr";
connectAttr "animCurveTL2070.a" "clipLibrary1.cel[0].cev[269].cevr";
// End of bat_attack.ma
