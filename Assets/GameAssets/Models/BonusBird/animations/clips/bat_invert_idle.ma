//Maya ASCII 2013 scene
//Name: bat_invert_idle.ma
//Last modified: Sat, Jul 12, 2014 02:57:16 PM
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
createNode animClip -n "invert_idleSource";
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
	setAttr ".ss" 610;
	setAttr ".se" 672;
	setAttr ".ci" no;
createNode animCurveTU -n "animCurveTU4501";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4502";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4503";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4501";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -58.651325225830085 672 -58.651325225830085;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -5.4373394959839061e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -5.4373394959839061e-005;
createNode animCurveTA -n "animCurveTA4502";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 6.7915472984313965 672 6.7915472984313965;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -1.5425623132614419e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -1.5425623132614419e-005;
createNode animCurveTA -n "animCurveTA4503";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -14.573970794677733 672 -14.573970794677733;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4501";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -6.0815443992614746 672 -6.0815443992614746;
	setAttr -s 2 ".kix[0:1]"  1 0.99999797344207764;
	setAttr -s 2 ".kiy[0:1]"  0 -0.002005469985306263;
	setAttr -s 2 ".kox[0:1]"  1 0.99999797344207764;
	setAttr -s 2 ".koy[0:1]"  0 -0.002005469985306263;
createNode animCurveTL -n "animCurveTL4502";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 3.834813117980957 672 3.834813117980957;
	setAttr -s 2 ".kix[0:1]"  1 0.99999994039535522;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00033661563065834343;
	setAttr -s 2 ".kox[0:1]"  1 0.99999994039535522;
	setAttr -s 2 ".koy[0:1]"  0 -0.00033661563065834343;
createNode animCurveTL -n "animCurveTL4503";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 14.421337127685547 672 14.421337127685547;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4504";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4505";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4506";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4504";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -9.0899629592895508 672 -9.0899629592895508;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -5.9699901612475514e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -5.9699901612475514e-005;
createNode animCurveTA -n "animCurveTA4505";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -10.204167366027832 672 -10.204167366027832;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -6.7017637775279582e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -6.7017637775279582e-005;
createNode animCurveTA -n "animCurveTA4506";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 60.836032867431641 672 60.836032867431641;
	setAttr -s 2 ".kix[0:1]"  1 0.99999964237213135;
	setAttr -s 2 ".kiy[0:1]"  0 0.00083445594646036625;
	setAttr -s 2 ".kox[0:1]"  1 0.99999964237213135;
	setAttr -s 2 ".koy[0:1]"  0 0.00083445594646036625;
createNode animCurveTL -n "animCurveTL4504";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -1.9167585372924805 672 -1.9167585372924805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4505";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -5.0555992126464844 672 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4506";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 28.250843048095703 672 28.250843048095703;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4507";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4508";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4509";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4507";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -75.192237854003906 672 -75.192237854003906;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -6.7428678448777646e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -6.7428678448777646e-005;
createNode animCurveTA -n "animCurveTA4508";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -2.4867546558380127 672 -2.4867546558380127;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.0068722733412869e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.0068722733412869e-005;
createNode animCurveTA -n "animCurveTA4509";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 13.345452308654785 672 13.345452308654785;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4507";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 3.2893540859222412 672 3.2893540859222412;
	setAttr -s 2 ".kix[0:1]"  1 0.99999839067459106;
	setAttr -s 2 ".kiy[0:1]"  0 -0.0017889202572405338;
	setAttr -s 2 ".kox[0:1]"  1 0.99999839067459106;
	setAttr -s 2 ".koy[0:1]"  0 -0.0017889202572405338;
createNode animCurveTL -n "animCurveTL4508";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 6.1589546203613281 672 6.1589546203613281;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.0001922167866723612;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.0001922167866723612;
createNode animCurveTL -n "animCurveTL4509";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -13.953570365905762 672 -13.953570365905762;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4510";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4511";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4512";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4510";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0.00017411152657587081;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0.00017411152657587081;
createNode animCurveTA -n "animCurveTA4511";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -3.843261583824642e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -3.843261583824642e-005;
createNode animCurveTA -n "animCurveTA4512";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0.00010116675548488274;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0.00010116675548488274;
createNode animCurveTL -n "animCurveTL4510";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.85381954908370972 672 -0.85381954908370972;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 6.7083667090628296e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 6.7083667090628296e-005;
createNode animCurveTL -n "animCurveTL4511";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -19.288660049438477 672 -19.288660049438477;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.4025865059229545e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.4025865059229545e-005;
createNode animCurveTL -n "animCurveTL4512";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 23.612241744995117 672 23.612241744995117;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 1.3434194443107117e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 1.3434194443107117e-005;
createNode animCurveTU -n "animCurveTU4513";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4514";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4515";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4513";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -58.762336730957031 672 -58.762336730957031;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00017152463260572404;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00017152463260572404;
createNode animCurveTA -n "animCurveTA4514";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 8.9236783981323242 672 8.9236783981323242;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.6047817300423048e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.6047817300423048e-005;
createNode animCurveTA -n "animCurveTA4515";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -6.6316461563110352 672 -6.6316461563110352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -1.9357476048753597e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -1.9357476048753597e-005;
createNode animCurveTL -n "animCurveTL4513";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -2.8015997409820557 672 -2.8015997409820557;
	setAttr -s 2 ".kix[0:1]"  1 0.99998444318771362;
	setAttr -s 2 ".kiy[0:1]"  0 0.0055823349393904209;
	setAttr -s 2 ".kox[0:1]"  1 0.99998444318771362;
	setAttr -s 2 ".koy[0:1]"  0 0.0055823349393904209;
createNode animCurveTL -n "animCurveTL4514";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -11.839803695678711 672 -11.839803695678711;
	setAttr -s 2 ".kix[0:1]"  1 0.99999481439590454;
	setAttr -s 2 ".kiy[0:1]"  0 -0.0032120142132043839;
	setAttr -s 2 ".kox[0:1]"  1 0.99999481439590454;
	setAttr -s 2 ".koy[0:1]"  0 -0.0032120142132043839;
createNode animCurveTL -n "animCurveTL4515";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 59.802238464355469 672 59.802238464355469;
	setAttr -s 2 ".kix[0:1]"  1 0.99999535083770752;
	setAttr -s 2 ".kiy[0:1]"  0 0.0030446334276348352;
	setAttr -s 2 ".kox[0:1]"  1 0.99999535083770752;
	setAttr -s 2 ".koy[0:1]"  0 0.0030446334276348352;
createNode animCurveTU -n "animCurveTU4516";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4517";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4518";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4516";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -4.4797706604003906 672 -4.4797706604003906;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4517";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 6.5180630683898926 672 6.5180630683898926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.5889115931931883e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.5889115931931883e-005;
createNode animCurveTA -n "animCurveTA4518";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -24.785079956054688 672 -24.785079956054688;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0.00026968622114509344;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0.00026968622114509344;
createNode animCurveTL -n "animCurveTL4516";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.23851531744003296 672 -0.23851531744003296;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 6.7083659814670682e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 6.7083659814670682e-005;
createNode animCurveTL -n "animCurveTL4517";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.21475188434123993 672 -0.21475188434123993;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.4025870516197756e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.4025870516197756e-005;
createNode animCurveTL -n "animCurveTL4518";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 41.197837829589844 672 41.197837829589844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 1.3434191714623012e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 1.3434191714623012e-005;
createNode animCurveTU -n "animCurveTU4519";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4520";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4521";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4519";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -60.676845550537102 672 -60.676845550537102;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4520";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -4.1696195602416992 672 -4.1696195602416992;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -1.643254108785186e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -1.643254108785186e-005;
createNode animCurveTA -n "animCurveTA4521";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -17.598331451416016 672 -17.598331451416016;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -5.6464068620698527e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -5.6464068620698527e-005;
createNode animCurveTL -n "animCurveTL4519";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -54.695327758789062 672 -54.695327758789062;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4520";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 3.2521772384643555 672 3.2521772384643555;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4521";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4522";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4523";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4524";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4522";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00016932022117543966;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00016932022117543966;
createNode animCurveTA -n "animCurveTA4523";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -5.7848505093716085e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -5.7848505093716085e-005;
createNode animCurveTA -n "animCurveTA4524";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0.00010617350199026987;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0.00010617350199026987;
createNode animCurveTL -n "animCurveTL4522";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -2.72998046875 672 -2.72998046875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 6.7083659814670682e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 6.7083659814670682e-005;
createNode animCurveTL -n "animCurveTL4523";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -19.288660049438477 672 -19.288660049438477;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.4025870516197756e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.4025870516197756e-005;
createNode animCurveTL -n "animCurveTL4524";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 23.290107727050781 672 23.290107727050781;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 1.3434205357043538e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 1.3434205357043538e-005;
createNode animCurveTU -n "animCurveTU4525";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4526";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4527";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4525";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -59.375091552734375 672 -59.375091552734375;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00017331322305835783;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00017331322305835783;
createNode animCurveTA -n "animCurveTA4526";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 10.813644409179687 672 10.813644409179687;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 3.1564533855998889e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 3.1564533855998889e-005;
createNode animCurveTA -n "animCurveTA4527";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -33.885326385498047 672 -33.885326385498047;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -9.8909746157005429e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -9.8909746157005429e-005;
createNode animCurveTL -n "animCurveTL4525";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -1.5581932067871094 672 -1.5581932067871094;
	setAttr -s 2 ".kix[0:1]"  1 0.99998331069946289;
	setAttr -s 2 ".kiy[0:1]"  0 0.0057902778498828411;
	setAttr -s 2 ".kox[0:1]"  1 0.99998331069946289;
	setAttr -s 2 ".koy[0:1]"  0 0.0057902778498828411;
createNode animCurveTL -n "animCurveTL4526";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -8.538996696472168 672 -8.538996696472168;
	setAttr -s 2 ".kix[0:1]"  1 0.99999642372131348;
	setAttr -s 2 ".kiy[0:1]"  0 -0.0026599813718348742;
	setAttr -s 2 ".kox[0:1]"  1 0.99999642372131348;
	setAttr -s 2 ".koy[0:1]"  0 -0.0026599813718348742;
createNode animCurveTL -n "animCurveTL4527";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -59.455486297607422 672 -59.455486297607422;
	setAttr -s 2 ".kix[0:1]"  1 0.99999547004699707;
	setAttr -s 2 ".kiy[0:1]"  0 -0.0030196942389011383;
	setAttr -s 2 ".kox[0:1]"  1 0.99999547004699707;
	setAttr -s 2 ".koy[0:1]"  0 -0.0030196942389011383;
createNode animCurveTU -n "animCurveTU4528";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4529";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4530";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4528";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 11.135740280151367 672 11.135740280151367;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4529";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -15.820825576782228 672 -15.820825576782228;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4530";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 51.690383911132813 672 51.690383911132813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00012607290409505367;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00012607290409505367;
createNode animCurveTL -n "animCurveTL4528";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 28.942703247070313 672 28.942703247070313;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4529";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1.8306970596313477 672 1.8306970596313477;
	setAttr -s 2 ".kix[0:1]"  1 0.99999445676803589;
	setAttr -s 2 ".kiy[0:1]"  0 0.0033388403244316578;
	setAttr -s 2 ".kox[0:1]"  1 0.99999445676803589;
	setAttr -s 2 ".koy[0:1]"  0 0.0033388403244316578;
createNode animCurveTL -n "animCurveTL4530";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.14556299149990082 672 -0.14556299149990082;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4531";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4532";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4533";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4531";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4532";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4533";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4531";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 35.083248138427734 672 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4532";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 30.643020629882813 672 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4533";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 36.804916381835937 672 36.804916381835937;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4534";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4535";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4536";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4534";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4535";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4536";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4534";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 35.083248138427734 672 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4535";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 30.643020629882813 672 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4536";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -36.361770629882813 672 -36.361770629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4537";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4538";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4539";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4537";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 14.535603523254393 672 14.535603523254393;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.0364917872939259e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.0364917872939259e-005;
createNode animCurveTA -n "animCurveTA4538";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -6.2114448547363281 672 -6.2114448547363281;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -2.1253139493637718e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -2.1253139493637718e-005;
createNode animCurveTA -n "animCurveTA4539";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -23.420516967773438 672 -23.420516967773438;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 1.730045914882794e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 1.730045914882794e-005;
createNode animCurveTL -n "animCurveTL4537";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -5.8221402168273926 672 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4538";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -10.433219909667969 672 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4539";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -28.427871704101563 672 -28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4540";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4541";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4542";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4540";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 55.218418121337891 672 55.218418121337891;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0.00011314201401546597;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0.00011314201401546597;
createNode animCurveTA -n "animCurveTA4541";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 40.382923126220703 672 40.382923126220703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 7.4196468631271273e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 7.4196468631271273e-005;
createNode animCurveTA -n "animCurveTA4542";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 56.378120422363281 672 56.378120422363281;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0.00023828331904951483;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0.00023828331904951483;
createNode animCurveTL -n "animCurveTL4540";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 11.41090202331543 672 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4541";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.91886520385742188 672 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4542";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -13.740226745605469 672 -13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4543";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4544";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4545";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4543";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 12.706744194030762 672 12.706744194030762;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 5.1620216254377738e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 5.1620216254377738e-005;
createNode animCurveTA -n "animCurveTA4544";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 82.587974548339844 672 82.587974548339844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0.00019013055134564638;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0.00019013055134564638;
createNode animCurveTA -n "animCurveTA4545";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -45.309745788574219 672 -45.309745788574219;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00017182860756292939;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00017182860756292939;
createNode animCurveTL -n "animCurveTL4543";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 24.969743728637695 672 24.969743728637695;
	setAttr -s 2 ".kix[0:1]"  1 0.9999929666519165;
	setAttr -s 2 ".kiy[0:1]"  0 0.0037497722078114748;
	setAttr -s 2 ".kox[0:1]"  1 0.9999929666519165;
	setAttr -s 2 ".koy[0:1]"  0 0.0037497722078114748;
createNode animCurveTL -n "animCurveTL4544";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 35.848468780517578 672 35.848468780517578;
	setAttr -s 2 ".kix[0:1]"  1 0.99999833106994629;
	setAttr -s 2 ".kiy[0:1]"  0 0.0018241155194118619;
	setAttr -s 2 ".kox[0:1]"  1 0.99999833106994629;
	setAttr -s 2 ".koy[0:1]"  0 0.0018241155194118619;
createNode animCurveTL -n "animCurveTL4545";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -48.402027130126953 672 -48.402027130126953;
	setAttr -s 2 ".kix[0:1]"  1 0.9999997615814209;
	setAttr -s 2 ".kiy[0:1]"  0 0.00074309192132204771;
	setAttr -s 2 ".kox[0:1]"  1 0.9999997615814209;
	setAttr -s 2 ".koy[0:1]"  0 0.00074309192132204771;
createNode animCurveTU -n "animCurveTU4546";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4547";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4548";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4546";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -12.352696418762207 672 -12.352696418762207;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.4683933588676155e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.4683933588676155e-005;
createNode animCurveTA -n "animCurveTA4547";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 5.9298720359802246 672 5.9298720359802246;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 3.7057769077364355e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 3.7057769077364355e-005;
createNode animCurveTA -n "animCurveTA4548";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -24.585111618041992 672 -24.585111618041992;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4546";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -5.8221402168273926 672 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4547";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -10.433219909667969 672 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4548";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 28.427871704101563 672 28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4549";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4550";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4551";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4549";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -30.54871940612793 672 -30.54871940612793;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -6.1423517763614655e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -6.1423517763614655e-005;
createNode animCurveTA -n "animCurveTA4550";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -16.072597503662109 672 -16.072597503662109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -2.5186896891682409e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -2.5186896891682409e-005;
createNode animCurveTA -n "animCurveTA4551";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 35.002620697021484 672 35.002620697021484;
	setAttr -s 2 ".kix[0:1]"  1 0.99999988079071045;
	setAttr -s 2 ".kiy[0:1]"  0 0.00022108478879090399;
	setAttr -s 2 ".kox[0:1]"  1 0.99999988079071045;
	setAttr -s 2 ".koy[0:1]"  0 0.00022108478879090399;
createNode animCurveTL -n "animCurveTL4549";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 11.41090202331543 672 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4550";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.91886520385742188 672 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4551";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 13.740226745605469 672 13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4552";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4553";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4554";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4552";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -31.644380569458004 672 -31.644380569458004;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00010745342297013849;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00010745342297013849;
createNode animCurveTA -n "animCurveTA4553";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -120.66969299316405 672 -120.66969299316405;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.0002964846498798579;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.0002964846498798579;
createNode animCurveTA -n "animCurveTA4554";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -28.072965621948242 672 -28.072965621948242;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00014230384840629995;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00014230384840629995;
createNode animCurveTL -n "animCurveTL4552";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 36.474536895751953 672 36.474536895751953;
	setAttr -s 2 ".kix[0:1]"  1 0.9999849796295166;
	setAttr -s 2 ".kiy[0:1]"  0 0.0054813981987535954;
	setAttr -s 2 ".kox[0:1]"  1 0.9999849796295166;
	setAttr -s 2 ".koy[0:1]"  0 0.0054813981987535954;
createNode animCurveTL -n "animCurveTL4553";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 36.577865600585937 672 36.577865600585937;
	setAttr -s 2 ".kix[0:1]"  1 0.99999815225601196;
	setAttr -s 2 ".kiy[0:1]"  0 0.0019339023856446147;
	setAttr -s 2 ".kox[0:1]"  1 0.99999815225601196;
	setAttr -s 2 ".koy[0:1]"  0 0.0019339023856446147;
createNode animCurveTL -n "animCurveTL4554";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 49.282497406005859 672 49.282497406005859;
	setAttr -s 2 ".kix[0:1]"  1 0.9999997615814209;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00067726703127846122;
	setAttr -s 2 ".kox[0:1]"  1 0.9999997615814209;
	setAttr -s 2 ".koy[0:1]"  0 -0.00067726703127846122;
createNode animCurveTU -n "animCurveTU4555";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 622 1 630 1 639 1 645 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4556";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 622 1 630 1 639 1 645 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4557";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 622 1 630 1 639 1 645 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA4555";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 622 0 624 5.1744508743286133 626 -2.6380045413970947
		 628 -1.8125016689300537 630 0 639 0 640 2.7334904670715332 642 0.63091939687728882
		 645 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.98822671175003052 0.96389687061309814 
		0.80704283714294434 0.96389615535736084 0.99762660264968872 0.99350857734680176 0.99614220857620239 
		0.97476768493652344 0.99996119737625122 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.15299630165100098 -0.26627561450004578 
		-0.590492844581604 0.26627859473228455 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.0088089564815163612 0;
	setAttr -s 11 ".kox[0:10]"  0.99999988079071045 0.98822671175003052 
		0.96389687061309814 0.80704283714294434 0.96389615535736084 0.99762660264968872 0.99350857734680176 
		0.99614220857620239 0.97476768493652344 0.99996119737625122 1;
	setAttr -s 11 ".koy[0:10]"  -0.00041169009637087584 0.15299630165100098 
		-0.26627561450004578 -0.590492844581604 0.26627859473228455 0.068856008350849152 
		0.11375708878040314 0.087753117084503174 -0.22322149574756622 -0.0088089564815163612 
		0;
createNode animCurveTA -n "animCurveTA4556";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 622 0 624 -4.8541984558105469 626 12.202020645141602
		 628 3.8002567291259761 630 0 639 0 640 0.74843138456344604 642 10.108014106750488
		 645 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.98961704969406128 0.6163068413734436 
		0.74097001552581787 0.61630237102508545 0.98969072103500366 0.99950891733169556 0.57813185453414917 
		0.99804013967514038 0.99018692970275879 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.14372915029525757 0.787506103515625 
		0.67153811454772949 -0.78750962018966675 -0.14322136342525482 0.031334873288869858 
		0.81594341993331909 -0.062577374279499054 -0.13974952697753906 0;
	setAttr -s 11 ".kox[0:10]"  0.99999988079071045 0.98961704969406128 
		0.6163068413734436 0.74097001552581787 0.61630237102508545 0.98969072103500366 0.99950891733169556 
		0.57813185453414917 0.99804013967514038 0.99018692970275879 1;
	setAttr -s 11 ".koy[0:10]"  0.00038621027488261461 -0.14372915029525757 
		0.787506103515625 0.67153811454772949 -0.78750962018966675 -0.14322136342525482 0.031334873288869858 
		0.81594341993331909 -0.062577374279499054 -0.13974952697753906 0;
createNode animCurveTA -n "animCurveTA4557";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 622 0 624 7.0496621131896973 626 -7.5172376632690421
		 628 -4.8886275291442871 630 0 639 0 640 -3.6848833560943608 642 5.9696779251098633
		 645 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.97847098112106323 0.78575193881988525 
		0.62464034557342529 0.78574848175048828 0.98311024904251099 0.98829632997512817 0.76814913749694824 
		0.95550709962844849 0.99654418230056763 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.20638419687747955 -0.61854183673858643 
		-0.78091257810592651 0.61854606866836548 0.18301410973072052 -0.15254579484462738 
		0.6402708888053894 0.29496803879737854 -0.083064369857311249 0;
	setAttr -s 11 ".kox[0:10]"  0.99999982118606567 0.97847098112106323 
		0.78575193881988525 0.62464034557342529 0.78574848175048828 0.98311024904251099 0.98829632997512817 
		0.76814913749694824 0.95550709962844849 0.99654418230056763 1;
	setAttr -s 11 ".koy[0:10]"  -0.00056088593555614352 0.20638419687747955 
		-0.61854183673858643 -0.78091257810592651 0.61854606866836548 0.18301410973072052 
		-0.15254579484462738 0.6402708888053894 0.29496803879737854 -0.083064369857311249 
		0;
createNode animCurveTL -n "animCurveTL4555";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 -1.1630247831344604 622 -1.1630247831344604
		 630 -1.1630247831344604 639 -1.1630247831344604 645 -1.1630247831344604 672 -1.1630247831344604;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL4556";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1.2282689809799194 622 1.2282689809799194
		 630 1.2282689809799194 639 1.2282689809799194 645 1.2282689809799194 672 1.2282689809799194;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL4557";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 27.684015274047852 628 27.684015274047852
		 672 27.684015274047852;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU4558";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 620 1 628 1 637 1 643 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4559";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 620 1 628 1 637 1 643 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4560";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 620 1 628 1 637 1 643 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA4558";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 620 0 622 5.1744508743286133 624 -2.6380045413970947
		 626 -1.8125016689300537 628 0 637 0 638 2.7334904670715332 640 0.63091939687728882
		 643 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.98407632112503052 0.96389615535736084 
		0.80704605579376221 0.96389615535736084 0.99762660264968872 0.99350863695144653 0.99614220857620239 
		0.97476732730865479 0.9999658465385437 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.1777462363243103 -0.26627859473228455 
		-0.5904884934425354 0.26627859473228455 0.068856269121170044 0.11375657469034195 
		0.087753124535083771 -0.22322343289852142 -0.0082584312185645103 0;
	setAttr -s 11 ".kox[0:10]"  0.99999982118606567 0.98407632112503052 
		0.96389615535736084 0.80704605579376221 0.96389615535736084 0.99762660264968872 0.99350863695144653 
		0.99614220857620239 0.97476732730865479 0.9999658465385437 1;
	setAttr -s 11 ".koy[0:10]"  -0.0005760568892583251 0.1777462363243103 
		-0.26627859473228455 -0.5904884934425354 0.26627859473228455 0.068856269121170044 
		0.11375657469034195 0.087753124535083771 -0.22322343289852142 -0.0082584312185645103 
		0;
createNode animCurveTA -n "animCurveTA4559";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 -6.0245368693756518e-009 620 -6.0245368693756518e-009
		 622 -4.8541984558105469 624 12.202020645141602 626 3.8002567291259761 628 -6.0245368693756518e-009
		 637 -6.0245368693756518e-009 638 0.74843138456344604 640 10.108014106750488 643 -6.0245368693756518e-009
		 672 -6.0245368693756518e-009;
	setAttr -s 11 ".kix[0:10]"  1 0.98594635725021362 0.61630237102508545 
		0.7409738302230835 0.61630237102508545 0.98969054222106934 0.99950891733169556 0.57813185453414917 
		0.99804008007049561 0.9913598895072937 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.16706220805644989 0.78750962018966675 
		0.67153394222259521 -0.78750962018966675 -0.14322192966938019 0.031334724277257919 
		0.81594341993331909 -0.062577933073043823 -0.13117031753063202 0;
	setAttr -s 11 ".kox[0:10]"  0.99999988079071045 0.98594635725021362 
		0.61630237102508545 0.7409738302230835 0.61630237102508545 0.98969054222106934 0.99950891733169556 
		0.57813185453414917 0.99804008007049561 0.9913598895072937 1;
	setAttr -s 11 ".koy[0:10]"  0.00054040423128753901 -0.16706220805644989 
		0.78750962018966675 0.67153394222259521 -0.78750962018966675 -0.14322192966938019 
		0.031334724277257919 0.81594341993331909 -0.062577933073043823 -0.13117031753063202 
		0;
createNode animCurveTA -n "animCurveTA4560";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 4.9320249217998935e-008 620 4.9320249217998935e-008
		 622 7.0496621131896973 624 -7.5172376632690421 626 -4.8886275291442871 628 4.9320249217998935e-008
		 637 4.9320249217998935e-008 638 -3.6848833560943608 640 5.9696779251098633 643 4.9320249217998935e-008
		 672 4.9320249217998935e-008;
	setAttr -s 11 ".kix[0:10]"  1 0.97103166580200195 0.78574848175048828 
		0.62464475631713867 0.78574848175048828 0.98311012983322144 0.9882965087890625 0.76814913749694824 
		0.95550632476806641 0.99696075916290283 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.23895108699798584 -0.61854606866836548 
		-0.78090900182723999 0.61854606866836548 0.18301482498645782 -0.15254507958889008 
		0.6402708888053894 0.29497048258781433 -0.077905371785163879 0;
	setAttr -s 11 ".kox[0:10]"  0.99999970197677612 0.97103166580200195 
		0.78574848175048828 0.62464475631713867 0.78574848175048828 0.98311012983322144 0.9882965087890625 
		0.76814913749694824 0.95550632476806641 0.99696075916290283 1;
	setAttr -s 11 ".koy[0:10]"  -0.0007848188397474587 0.23895108699798584 
		-0.61854606866836548 -0.78090900182723999 0.61854606866836548 0.18301482498645782 
		-0.15254507958889008 0.6402708888053894 0.29497048258781433 -0.077905371785163879 
		0;
createNode animCurveTL -n "animCurveTL4558";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 4.9883952140808105 620 4.9883952140808105
		 628 4.9883952140808105 637 4.9883952140808105 643 4.9883952140808105 672 4.9883952140808105;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL4559";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 41.4617919921875 628 41.4617919921875
		 672 41.4617919921875;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL4560";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 38.623714447021484 628 38.623714447021484
		 672 38.623714447021484;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU4561";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 624 1 632 1 641 1 647 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4562";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 624 1 632 1 641 1 647 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4563";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 624 1 632 1 641 1 647 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA4561";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 624 0 626 5.1744508743286133 628 -2.6380045413970947
		 630 -1.8125016689300537 632 0 641 0 642 2.7334904670715332 644 0.63091939687728882
		 647 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.99094879627227783 0.96389615535736084 
		0.80704283714294434 0.96389687061309814 0.99762660264968872 0.99350857734680176 0.99614220857620239 
		0.97476768493652344 0.99995547533035278 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.13424040377140045 -0.26627859473228455 
		-0.590492844581604 0.26627561450004578 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.0094381161034107208 0;
	setAttr -s 11 ".kox[0:10]"  1 0.99094879627227783 0.96389615535736084 
		0.80704283714294434 0.96389687061309814 0.99762660264968872 0.99350857734680176 0.99614220857620239 
		0.97476768493652344 0.99995547533035278 1;
	setAttr -s 11 ".koy[0:10]"  -0.00030888503533788025 0.13424040377140045 
		-0.26627859473228455 -0.590492844581604 0.26627561450004578 0.068856008350849152 
		0.11375708878040314 0.087753117084503174 -0.22322149574756622 -0.0094381161034107208 
		0;
createNode animCurveTA -n "animCurveTA4562";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 624 0 626 -4.8541984558105469 628 12.202020645141602
		 630 3.8002567291259761 632 0 641 0 642 0.74843138456344604 644 10.108014106750488
		 647 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.99202162027359009 0.61630237102508545 
		0.74097001552581787 0.6163068413734436 0.98969072103500366 0.99950891733169556 0.57813185453414917 
		0.99804013967514038 0.98875939846038818 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.12606845796108246 0.78750962018966675 
		0.67153811454772949 -0.787506103515625 -0.14322136342525482 0.031334873288869858 
		0.81594341993331909 -0.062577374279499054 -0.14951585233211517 0;
	setAttr -s 11 ".kox[0:10]"  1 0.99202162027359009 0.61630237102508545 
		0.74097001552581787 0.6163068413734436 0.98969072103500366 0.99950891733169556 0.57813185453414917 
		0.99804013967514038 0.98875939846038818 1;
	setAttr -s 11 ".koy[0:10]"  0.00028976780595257878 -0.12606845796108246 
		0.78750962018966675 0.67153811454772949 -0.787506103515625 -0.14322136342525482 0.031334873288869858 
		0.81594341993331909 -0.062577374279499054 -0.14951585233211517 0;
createNode animCurveTA -n "animCurveTA4563";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 624 0 626 7.0496621131896973 628 -7.5172376632690421
		 630 -4.8886275291442871 632 0 641 0 642 -3.6848833560943608 644 5.9696779251098633
		 647 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.98339205980300903 0.78574848175048828 
		0.62464034557342529 0.78575193881988525 0.98311024904251099 0.98829632997512817 0.76814913749694824 
		0.95550709962844849 0.99603593349456787 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.18149420619010925 -0.61854606866836548 
		-0.78091257810592651 0.61854183673858643 0.18301410973072052 -0.15254579484462738 
		0.6402708888053894 0.29496803879737854 -0.088952183723449707 0;
	setAttr -s 11 ".kox[0:10]"  0.99999988079071045 0.98339205980300903 
		0.78574848175048828 0.62464034557342529 0.78575193881988525 0.98311024904251099 0.98829632997512817 
		0.76814913749694824 0.95550709962844849 0.99603593349456787 1;
	setAttr -s 11 ".koy[0:10]"  -0.00042082450818270445 0.18149420619010925 
		-0.61854606866836548 -0.78091257810592651 0.61854183673858643 0.18301410973072052 
		-0.15254579484462738 0.6402708888053894 0.29496803879737854 -0.088952183723449707 
		0;
createNode animCurveTL -n "animCurveTL4561";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1.1630247831344604 624 1.1630247831344604
		 632 1.1630247831344604 641 1.1630247831344604 647 1.1630247831344604 672 1.1630247831344604;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL4562";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 2.0187394618988037 624 2.0187394618988037
		 632 2.0187394618988037 641 2.0187394618988037 647 2.0187394618988037 672 2.0187394618988037;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL4563";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 27.637619018554688 628 27.637619018554688
		 672 27.637619018554688;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU4564";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 622 1 630 1 639 1 645 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4565";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 622 1 630 1 639 1 645 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU4566";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 1 622 1 630 1 639 1 645 1 672 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA4564";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 2.9530831113788736e-008 622 2.9530831113788736e-008
		 624 5.1744508743286133 626 -2.6380045413970947 628 -1.8125016689300537 630 2.9530831113788736e-008
		 639 2.9530831113788736e-008 640 2.7334904670715332 642 0.63091939687728882 645 2.9530831113788736e-008
		 672 2.9530831113788736e-008;
	setAttr -s 11 ".kix[0:10]"  1 0.98822671175003052 0.96389687061309814 
		0.80704283714294434 0.96389615535736084 0.99762660264968872 0.99350857734680176 0.99614220857620239 
		0.97476768493652344 0.99996119737625122 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.15299630165100098 -0.26627561450004578 
		-0.590492844581604 0.26627859473228455 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.0088089564815163612 0;
	setAttr -s 11 ".kox[0:10]"  0.99999988079071045 0.98822671175003052 
		0.96389687061309814 0.80704283714294434 0.96389615535736084 0.99762660264968872 0.99350857734680176 
		0.99614220857620239 0.97476768493652344 0.99996119737625122 1;
	setAttr -s 11 ".koy[0:10]"  -0.00041169009637087584 0.15299630165100098 
		-0.26627561450004578 -0.590492844581604 0.26627859473228455 0.068856008350849152 
		0.11375708878040314 0.087753117084503174 -0.22322149574756622 -0.0088089564815163612 
		0;
createNode animCurveTA -n "animCurveTA4565";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 622 0 624 -4.8541984558105469 626 12.202020645141602
		 628 3.8002567291259761 630 0 639 0 640 0.74843138456344604 642 10.108014106750488
		 645 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.98961704969406128 0.6163068413734436 
		0.74097001552581787 0.61630237102508545 0.98969072103500366 0.99950891733169556 0.57813185453414917 
		0.99804013967514038 0.99018692970275879 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.14372915029525757 0.787506103515625 
		0.67153811454772949 -0.78750962018966675 -0.14322136342525482 0.031334873288869858 
		0.81594341993331909 -0.062577374279499054 -0.13974952697753906 0;
	setAttr -s 11 ".kox[0:10]"  0.99999988079071045 0.98961704969406128 
		0.6163068413734436 0.74097001552581787 0.61630237102508545 0.98969072103500366 0.99950891733169556 
		0.57813185453414917 0.99804013967514038 0.99018692970275879 1;
	setAttr -s 11 ".koy[0:10]"  0.00038621027488261461 -0.14372915029525757 
		0.787506103515625 0.67153811454772949 -0.78750962018966675 -0.14322136342525482 0.031334873288869858 
		0.81594341993331909 -0.062577374279499054 -0.13974952697753906 0;
createNode animCurveTA -n "animCurveTA4566";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  610 0 622 0 624 7.0496621131896973 626 -7.5172376632690421
		 628 -4.8886275291442871 630 0 639 0 640 -3.6848833560943608 642 5.9696779251098633
		 645 0 672 0;
	setAttr -s 11 ".kix[0:10]"  1 0.97847098112106323 0.78575193881988525 
		0.62464034557342529 0.78574848175048828 0.98311024904251099 0.98829632997512817 0.76814913749694824 
		0.95550709962844849 0.99654418230056763 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.20638419687747955 -0.61854183673858643 
		-0.78091257810592651 0.61854606866836548 0.18301410973072052 -0.15254579484462738 
		0.6402708888053894 0.29496803879737854 -0.083064369857311249 0;
	setAttr -s 11 ".kox[0:10]"  0.99999982118606567 0.97847098112106323 
		0.78575193881988525 0.62464034557342529 0.78574848175048828 0.98311024904251099 0.98829632997512817 
		0.76814913749694824 0.95550709962844849 0.99654418230056763 1;
	setAttr -s 11 ".koy[0:10]"  -0.00056088593555614352 0.20638419687747955 
		-0.61854183673858643 -0.78091257810592651 0.61854606866836548 0.18301410973072052 
		-0.15254579484462738 0.6402708888053894 0.29496803879737854 -0.083064369857311249 
		0;
createNode animCurveTL -n "animCurveTL4564";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  610 4.9883952140808105 622 4.9883952140808105
		 630 4.9883952140808105 639 4.9883952140808105 645 4.9883952140808105 672 4.9883952140808105;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL4565";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 41.4617919921875 628 41.4617919921875
		 672 41.4617919921875;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL4566";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 -38.180568695068359 628 -38.180568695068359
		 672 -38.180568695068359;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU4567";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4568";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4569";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4567";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -12.353965759277344 672 -12.353965759277344;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4568";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -11.531641960144043 672 -11.531641960144043;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4569";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 21.029420852661133 672 21.029420852661133;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4567";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 33.670879364013672 672 33.670879364013672;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00010261979332426563;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00010261979332426563;
createNode animCurveTL -n "animCurveTL4568";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 17.186578750610352 672 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4569";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 11.930496215820313 672 11.930496215820313;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4570";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4571";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4572";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4570";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 2.0917305946350098 672 2.0917305946350098;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4571";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 10.772274971008301 672 10.772274971008301;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4572";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 24.319551467895508 672 24.319551467895508;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4570";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 33.670879364013672 672 33.670879364013672;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 -0.00010261979332426563;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 -0.00010261979332426563;
createNode animCurveTL -n "animCurveTL4571";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 17.186578750610352 672 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4572";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -11.48735237121582 672 -11.48735237121582;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4573";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4574";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4575";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4573";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4574";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4575";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4573";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 47.368160247802734 672 47.368160247802734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4574";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 26.913848876953125 672 26.913848876953125;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4575";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0.22157172858715057 672 0.22157172858715057;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4576";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4577";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4578";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4576";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 4.9733572006225586 640 -3.4853804111480713
		 672 4.9733572006225586;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99999988079071045 0.99999988079071045;
	setAttr -s 3 ".kiy[0:2]"  0 -0.00037761649582535028 0.00033190401154570282;
	setAttr -s 3 ".kox[0:2]"  0.99999988079071045 0.99999988079071045 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.00037761649582535028 0.00033190401154570282 
		0;
createNode animCurveTA -n "animCurveTA4577";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  610 -6.7001924514770508 642 -0.70953458547592163
		 672 -6.7001924514770508;
	setAttr -s 3 ".ktl[0:2]" no yes yes;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.00023506143770646304 -0.00026743602938950062;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0.00023506143770646304 -0.00026743602938950062 
		0;
createNode animCurveTA -n "animCurveTA4578";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  610 0.75206440687179565 627 8.5348806381225586
		 664 -1.5297247171401978 672 0.75206440687179565;
	setAttr -s 4 ".kix[0:3]"  0.97697842121124268 0.99999982118606567 
		1 0.97366106510162354;
	setAttr -s 4 ".kiy[0:3]"  0.21333838999271393 0.00064359896350651979 
		-0.00029542008996941149 0.22800038754940033;
	setAttr -s 4 ".kox[0:3]"  0.97385978698730469 1 0.99999988079071045 
		0.97694045305252075;
	setAttr -s 4 ".koy[0:3]"  0.22714988887310028 -0.00029542008996941149 
		0.00049503176705911756 0.21351182460784912;
createNode animCurveTL -n "animCurveTL4576";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0.55634701251983643 672 0.55634701251983643;
	setAttr -s 2 ".kix[0:1]"  1 0.99997925758361816;
	setAttr -s 2 ".kiy[0:1]"  0 -0.006440579891204834;
	setAttr -s 2 ".kox[0:1]"  1 0.99997925758361816;
	setAttr -s 2 ".koy[0:1]"  0 -0.006440579891204834;
createNode animCurveTL -n "animCurveTL4577";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 28.874954223632813 672 28.874954223632813;
	setAttr -s 2 ".kix[0:1]"  1 0.99999839067459106;
	setAttr -s 2 ".kiy[0:1]"  0 -0.0017761762719601393;
	setAttr -s 2 ".kox[0:1]"  1 0.99999839067459106;
	setAttr -s 2 ".koy[0:1]"  0 -0.0017761762719601393;
createNode animCurveTL -n "animCurveTL4578";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4579";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4580";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4581";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4579";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0.03537445142865181 672 0.03537445142865181;
	setAttr -s 2 ".kix[0:1]"  0.99803000688552856 0.99758881330490112;
	setAttr -s 2 ".kiy[0:1]"  -0.062738791108131409 -0.069400690495967865;
	setAttr -s 2 ".kox[0:1]"  0.9977642297744751 0.99787473678588867;
	setAttr -s 2 ".koy[0:1]"  -0.066832222044467926 -0.065162003040313721;
createNode animCurveTA -n "animCurveTA4580";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.053693518042564392 672 -0.053693518042564392;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4581";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.076654709875583649 672 -0.076654709875583649;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4579";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -1.4725730419158936 672 -1.4725730419158936;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4580";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 25.007797241210938 672 25.007797241210938;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4581";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4582";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4583";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4584";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4582";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -0.010299474000930786 672 -0.010299474000930786;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4583";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0.0079834824427962303 672 0.0079834824427962303;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4584";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -179.95187377929687 672 -179.95187377929687;
	setAttr -s 2 ".kix[0:1]"  0.99152070283889771 0.99022215604782104;
	setAttr -s 2 ".kiy[0:1]"  0.12994891405105591 0.13949936628341675;
	setAttr -s 2 ".kox[0:1]"  0.99038910865783691 0.99137771129608154;
	setAttr -s 2 ".koy[0:1]"  0.13830865919589996 0.13103511929512024;
createNode animCurveTL -n "animCurveTL4582";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0.31663277745246887 672 0.31663277745246887;
	setAttr -s 2 ".kix[0:1]"  1 0.99999940395355225;
	setAttr -s 2 ".kiy[0:1]"  0 0.0011197157436981797;
	setAttr -s 2 ".kox[0:1]"  1 0.99999940395355225;
	setAttr -s 2 ".koy[0:1]"  0 0.0011197157436981797;
createNode animCurveTL -n "animCurveTL4583";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 377.28610229492187 672 377.28610229492187;
	setAttr -s 2 ".kix[0:1]"  1 0.99976205825805664;
	setAttr -s 2 ".kiy[0:1]"  0 0.021811472252011299;
	setAttr -s 2 ".kox[0:1]"  1 0.99976205825805664;
	setAttr -s 2 ".koy[0:1]"  0 0.021811472252011299;
createNode animCurveTL -n "animCurveTL4584";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0.067520372569561005 672 0.067520372569561005;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 2.6933326807920821e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 2.6933326807920821e-005;
createNode animCurveTU -n "animCurveTU4585";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4586";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4587";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4585";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4586";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4587";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4585";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4586";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4587";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 0 672 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4588";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4589";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU4590";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 1 672 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA4588";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 13.42143726348877 672 13.42143726348877;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 8.8147622591350228e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 8.8147622591350228e-005;
createNode animCurveTA -n "animCurveTA4589";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 9.3653659820556641 672 9.3653659820556641;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 6.1508661019615829e-005;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 6.1508661019615829e-005;
createNode animCurveTA -n "animCurveTA4590";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 60.512813568115234 672 60.512813568115234;
	setAttr -s 2 ".kix[0:1]"  1 0.99999964237213135;
	setAttr -s 2 ".kiy[0:1]"  0 0.00083233334589749575;
	setAttr -s 2 ".kox[0:1]"  1 0.99999964237213135;
	setAttr -s 2 ".koy[0:1]"  0 0.00083233334589749575;
createNode animCurveTL -n "animCurveTL4588";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 2.0856802463531494 672 2.0856802463531494;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4589";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 -5.0555992126464844 672 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL4590";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  610 28.262805938720703 672 28.262805938720703;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
select -ne :time1;
	setAttr ".o" 672;
	setAttr ".unw" 672;
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
connectAttr "invert_idleSource.cl" "clipLibrary1.sc[0]";
connectAttr "animCurveTU4501.a" "clipLibrary1.cel[0].cev[0].cevr";
connectAttr "animCurveTU4502.a" "clipLibrary1.cel[0].cev[1].cevr";
connectAttr "animCurveTU4503.a" "clipLibrary1.cel[0].cev[2].cevr";
connectAttr "animCurveTA4501.a" "clipLibrary1.cel[0].cev[3].cevr";
connectAttr "animCurveTA4502.a" "clipLibrary1.cel[0].cev[4].cevr";
connectAttr "animCurveTA4503.a" "clipLibrary1.cel[0].cev[5].cevr";
connectAttr "animCurveTL4501.a" "clipLibrary1.cel[0].cev[6].cevr";
connectAttr "animCurveTL4502.a" "clipLibrary1.cel[0].cev[7].cevr";
connectAttr "animCurveTL4503.a" "clipLibrary1.cel[0].cev[8].cevr";
connectAttr "animCurveTU4504.a" "clipLibrary1.cel[0].cev[9].cevr";
connectAttr "animCurveTU4505.a" "clipLibrary1.cel[0].cev[10].cevr";
connectAttr "animCurveTU4506.a" "clipLibrary1.cel[0].cev[11].cevr";
connectAttr "animCurveTA4504.a" "clipLibrary1.cel[0].cev[12].cevr";
connectAttr "animCurveTA4505.a" "clipLibrary1.cel[0].cev[13].cevr";
connectAttr "animCurveTA4506.a" "clipLibrary1.cel[0].cev[14].cevr";
connectAttr "animCurveTL4504.a" "clipLibrary1.cel[0].cev[15].cevr";
connectAttr "animCurveTL4505.a" "clipLibrary1.cel[0].cev[16].cevr";
connectAttr "animCurveTL4506.a" "clipLibrary1.cel[0].cev[17].cevr";
connectAttr "animCurveTU4507.a" "clipLibrary1.cel[0].cev[18].cevr";
connectAttr "animCurveTU4508.a" "clipLibrary1.cel[0].cev[19].cevr";
connectAttr "animCurveTU4509.a" "clipLibrary1.cel[0].cev[20].cevr";
connectAttr "animCurveTA4507.a" "clipLibrary1.cel[0].cev[21].cevr";
connectAttr "animCurveTA4508.a" "clipLibrary1.cel[0].cev[22].cevr";
connectAttr "animCurveTA4509.a" "clipLibrary1.cel[0].cev[23].cevr";
connectAttr "animCurveTL4507.a" "clipLibrary1.cel[0].cev[24].cevr";
connectAttr "animCurveTL4508.a" "clipLibrary1.cel[0].cev[25].cevr";
connectAttr "animCurveTL4509.a" "clipLibrary1.cel[0].cev[26].cevr";
connectAttr "animCurveTU4510.a" "clipLibrary1.cel[0].cev[27].cevr";
connectAttr "animCurveTU4511.a" "clipLibrary1.cel[0].cev[28].cevr";
connectAttr "animCurveTU4512.a" "clipLibrary1.cel[0].cev[29].cevr";
connectAttr "animCurveTA4510.a" "clipLibrary1.cel[0].cev[30].cevr";
connectAttr "animCurveTA4511.a" "clipLibrary1.cel[0].cev[31].cevr";
connectAttr "animCurveTA4512.a" "clipLibrary1.cel[0].cev[32].cevr";
connectAttr "animCurveTL4510.a" "clipLibrary1.cel[0].cev[33].cevr";
connectAttr "animCurveTL4511.a" "clipLibrary1.cel[0].cev[34].cevr";
connectAttr "animCurveTL4512.a" "clipLibrary1.cel[0].cev[35].cevr";
connectAttr "animCurveTU4513.a" "clipLibrary1.cel[0].cev[36].cevr";
connectAttr "animCurveTU4514.a" "clipLibrary1.cel[0].cev[37].cevr";
connectAttr "animCurveTU4515.a" "clipLibrary1.cel[0].cev[38].cevr";
connectAttr "animCurveTA4513.a" "clipLibrary1.cel[0].cev[39].cevr";
connectAttr "animCurveTA4514.a" "clipLibrary1.cel[0].cev[40].cevr";
connectAttr "animCurveTA4515.a" "clipLibrary1.cel[0].cev[41].cevr";
connectAttr "animCurveTL4513.a" "clipLibrary1.cel[0].cev[42].cevr";
connectAttr "animCurveTL4514.a" "clipLibrary1.cel[0].cev[43].cevr";
connectAttr "animCurveTL4515.a" "clipLibrary1.cel[0].cev[44].cevr";
connectAttr "animCurveTU4516.a" "clipLibrary1.cel[0].cev[45].cevr";
connectAttr "animCurveTU4517.a" "clipLibrary1.cel[0].cev[46].cevr";
connectAttr "animCurveTU4518.a" "clipLibrary1.cel[0].cev[47].cevr";
connectAttr "animCurveTA4516.a" "clipLibrary1.cel[0].cev[48].cevr";
connectAttr "animCurveTA4517.a" "clipLibrary1.cel[0].cev[49].cevr";
connectAttr "animCurveTA4518.a" "clipLibrary1.cel[0].cev[50].cevr";
connectAttr "animCurveTL4516.a" "clipLibrary1.cel[0].cev[51].cevr";
connectAttr "animCurveTL4517.a" "clipLibrary1.cel[0].cev[52].cevr";
connectAttr "animCurveTL4518.a" "clipLibrary1.cel[0].cev[53].cevr";
connectAttr "animCurveTU4519.a" "clipLibrary1.cel[0].cev[54].cevr";
connectAttr "animCurveTU4520.a" "clipLibrary1.cel[0].cev[55].cevr";
connectAttr "animCurveTU4521.a" "clipLibrary1.cel[0].cev[56].cevr";
connectAttr "animCurveTA4519.a" "clipLibrary1.cel[0].cev[57].cevr";
connectAttr "animCurveTA4520.a" "clipLibrary1.cel[0].cev[58].cevr";
connectAttr "animCurveTA4521.a" "clipLibrary1.cel[0].cev[59].cevr";
connectAttr "animCurveTL4519.a" "clipLibrary1.cel[0].cev[60].cevr";
connectAttr "animCurveTL4520.a" "clipLibrary1.cel[0].cev[61].cevr";
connectAttr "animCurveTL4521.a" "clipLibrary1.cel[0].cev[62].cevr";
connectAttr "animCurveTU4522.a" "clipLibrary1.cel[0].cev[63].cevr";
connectAttr "animCurveTU4523.a" "clipLibrary1.cel[0].cev[64].cevr";
connectAttr "animCurveTU4524.a" "clipLibrary1.cel[0].cev[65].cevr";
connectAttr "animCurveTA4522.a" "clipLibrary1.cel[0].cev[66].cevr";
connectAttr "animCurveTA4523.a" "clipLibrary1.cel[0].cev[67].cevr";
connectAttr "animCurveTA4524.a" "clipLibrary1.cel[0].cev[68].cevr";
connectAttr "animCurveTL4522.a" "clipLibrary1.cel[0].cev[69].cevr";
connectAttr "animCurveTL4523.a" "clipLibrary1.cel[0].cev[70].cevr";
connectAttr "animCurveTL4524.a" "clipLibrary1.cel[0].cev[71].cevr";
connectAttr "animCurveTU4525.a" "clipLibrary1.cel[0].cev[72].cevr";
connectAttr "animCurveTU4526.a" "clipLibrary1.cel[0].cev[73].cevr";
connectAttr "animCurveTU4527.a" "clipLibrary1.cel[0].cev[74].cevr";
connectAttr "animCurveTA4525.a" "clipLibrary1.cel[0].cev[75].cevr";
connectAttr "animCurveTA4526.a" "clipLibrary1.cel[0].cev[76].cevr";
connectAttr "animCurveTA4527.a" "clipLibrary1.cel[0].cev[77].cevr";
connectAttr "animCurveTL4525.a" "clipLibrary1.cel[0].cev[78].cevr";
connectAttr "animCurveTL4526.a" "clipLibrary1.cel[0].cev[79].cevr";
connectAttr "animCurveTL4527.a" "clipLibrary1.cel[0].cev[80].cevr";
connectAttr "animCurveTU4528.a" "clipLibrary1.cel[0].cev[81].cevr";
connectAttr "animCurveTU4529.a" "clipLibrary1.cel[0].cev[82].cevr";
connectAttr "animCurveTU4530.a" "clipLibrary1.cel[0].cev[83].cevr";
connectAttr "animCurveTA4528.a" "clipLibrary1.cel[0].cev[84].cevr";
connectAttr "animCurveTA4529.a" "clipLibrary1.cel[0].cev[85].cevr";
connectAttr "animCurveTA4530.a" "clipLibrary1.cel[0].cev[86].cevr";
connectAttr "animCurveTL4528.a" "clipLibrary1.cel[0].cev[87].cevr";
connectAttr "animCurveTL4529.a" "clipLibrary1.cel[0].cev[88].cevr";
connectAttr "animCurveTL4530.a" "clipLibrary1.cel[0].cev[89].cevr";
connectAttr "animCurveTU4531.a" "clipLibrary1.cel[0].cev[90].cevr";
connectAttr "animCurveTU4532.a" "clipLibrary1.cel[0].cev[91].cevr";
connectAttr "animCurveTU4533.a" "clipLibrary1.cel[0].cev[92].cevr";
connectAttr "animCurveTA4531.a" "clipLibrary1.cel[0].cev[93].cevr";
connectAttr "animCurveTA4532.a" "clipLibrary1.cel[0].cev[94].cevr";
connectAttr "animCurveTA4533.a" "clipLibrary1.cel[0].cev[95].cevr";
connectAttr "animCurveTL4531.a" "clipLibrary1.cel[0].cev[96].cevr";
connectAttr "animCurveTL4532.a" "clipLibrary1.cel[0].cev[97].cevr";
connectAttr "animCurveTL4533.a" "clipLibrary1.cel[0].cev[98].cevr";
connectAttr "animCurveTU4534.a" "clipLibrary1.cel[0].cev[99].cevr";
connectAttr "animCurveTU4535.a" "clipLibrary1.cel[0].cev[100].cevr";
connectAttr "animCurveTU4536.a" "clipLibrary1.cel[0].cev[101].cevr";
connectAttr "animCurveTA4534.a" "clipLibrary1.cel[0].cev[102].cevr";
connectAttr "animCurveTA4535.a" "clipLibrary1.cel[0].cev[103].cevr";
connectAttr "animCurveTA4536.a" "clipLibrary1.cel[0].cev[104].cevr";
connectAttr "animCurveTL4534.a" "clipLibrary1.cel[0].cev[105].cevr";
connectAttr "animCurveTL4535.a" "clipLibrary1.cel[0].cev[106].cevr";
connectAttr "animCurveTL4536.a" "clipLibrary1.cel[0].cev[107].cevr";
connectAttr "animCurveTU4537.a" "clipLibrary1.cel[0].cev[108].cevr";
connectAttr "animCurveTU4538.a" "clipLibrary1.cel[0].cev[109].cevr";
connectAttr "animCurveTU4539.a" "clipLibrary1.cel[0].cev[110].cevr";
connectAttr "animCurveTA4537.a" "clipLibrary1.cel[0].cev[111].cevr";
connectAttr "animCurveTA4538.a" "clipLibrary1.cel[0].cev[112].cevr";
connectAttr "animCurveTA4539.a" "clipLibrary1.cel[0].cev[113].cevr";
connectAttr "animCurveTL4537.a" "clipLibrary1.cel[0].cev[114].cevr";
connectAttr "animCurveTL4538.a" "clipLibrary1.cel[0].cev[115].cevr";
connectAttr "animCurveTL4539.a" "clipLibrary1.cel[0].cev[116].cevr";
connectAttr "animCurveTU4540.a" "clipLibrary1.cel[0].cev[117].cevr";
connectAttr "animCurveTU4541.a" "clipLibrary1.cel[0].cev[118].cevr";
connectAttr "animCurveTU4542.a" "clipLibrary1.cel[0].cev[119].cevr";
connectAttr "animCurveTA4540.a" "clipLibrary1.cel[0].cev[120].cevr";
connectAttr "animCurveTA4541.a" "clipLibrary1.cel[0].cev[121].cevr";
connectAttr "animCurveTA4542.a" "clipLibrary1.cel[0].cev[122].cevr";
connectAttr "animCurveTL4540.a" "clipLibrary1.cel[0].cev[123].cevr";
connectAttr "animCurveTL4541.a" "clipLibrary1.cel[0].cev[124].cevr";
connectAttr "animCurveTL4542.a" "clipLibrary1.cel[0].cev[125].cevr";
connectAttr "animCurveTU4543.a" "clipLibrary1.cel[0].cev[126].cevr";
connectAttr "animCurveTU4544.a" "clipLibrary1.cel[0].cev[127].cevr";
connectAttr "animCurveTU4545.a" "clipLibrary1.cel[0].cev[128].cevr";
connectAttr "animCurveTA4543.a" "clipLibrary1.cel[0].cev[129].cevr";
connectAttr "animCurveTA4544.a" "clipLibrary1.cel[0].cev[130].cevr";
connectAttr "animCurveTA4545.a" "clipLibrary1.cel[0].cev[131].cevr";
connectAttr "animCurveTL4543.a" "clipLibrary1.cel[0].cev[132].cevr";
connectAttr "animCurveTL4544.a" "clipLibrary1.cel[0].cev[133].cevr";
connectAttr "animCurveTL4545.a" "clipLibrary1.cel[0].cev[134].cevr";
connectAttr "animCurveTU4546.a" "clipLibrary1.cel[0].cev[135].cevr";
connectAttr "animCurveTU4547.a" "clipLibrary1.cel[0].cev[136].cevr";
connectAttr "animCurveTU4548.a" "clipLibrary1.cel[0].cev[137].cevr";
connectAttr "animCurveTA4546.a" "clipLibrary1.cel[0].cev[138].cevr";
connectAttr "animCurveTA4547.a" "clipLibrary1.cel[0].cev[139].cevr";
connectAttr "animCurveTA4548.a" "clipLibrary1.cel[0].cev[140].cevr";
connectAttr "animCurveTL4546.a" "clipLibrary1.cel[0].cev[141].cevr";
connectAttr "animCurveTL4547.a" "clipLibrary1.cel[0].cev[142].cevr";
connectAttr "animCurveTL4548.a" "clipLibrary1.cel[0].cev[143].cevr";
connectAttr "animCurveTU4549.a" "clipLibrary1.cel[0].cev[144].cevr";
connectAttr "animCurveTU4550.a" "clipLibrary1.cel[0].cev[145].cevr";
connectAttr "animCurveTU4551.a" "clipLibrary1.cel[0].cev[146].cevr";
connectAttr "animCurveTA4549.a" "clipLibrary1.cel[0].cev[147].cevr";
connectAttr "animCurveTA4550.a" "clipLibrary1.cel[0].cev[148].cevr";
connectAttr "animCurveTA4551.a" "clipLibrary1.cel[0].cev[149].cevr";
connectAttr "animCurveTL4549.a" "clipLibrary1.cel[0].cev[150].cevr";
connectAttr "animCurveTL4550.a" "clipLibrary1.cel[0].cev[151].cevr";
connectAttr "animCurveTL4551.a" "clipLibrary1.cel[0].cev[152].cevr";
connectAttr "animCurveTU4552.a" "clipLibrary1.cel[0].cev[153].cevr";
connectAttr "animCurveTU4553.a" "clipLibrary1.cel[0].cev[154].cevr";
connectAttr "animCurveTU4554.a" "clipLibrary1.cel[0].cev[155].cevr";
connectAttr "animCurveTA4552.a" "clipLibrary1.cel[0].cev[156].cevr";
connectAttr "animCurveTA4553.a" "clipLibrary1.cel[0].cev[157].cevr";
connectAttr "animCurveTA4554.a" "clipLibrary1.cel[0].cev[158].cevr";
connectAttr "animCurveTL4552.a" "clipLibrary1.cel[0].cev[159].cevr";
connectAttr "animCurveTL4553.a" "clipLibrary1.cel[0].cev[160].cevr";
connectAttr "animCurveTL4554.a" "clipLibrary1.cel[0].cev[161].cevr";
connectAttr "animCurveTU4555.a" "clipLibrary1.cel[0].cev[162].cevr";
connectAttr "animCurveTU4556.a" "clipLibrary1.cel[0].cev[163].cevr";
connectAttr "animCurveTU4557.a" "clipLibrary1.cel[0].cev[164].cevr";
connectAttr "animCurveTA4555.a" "clipLibrary1.cel[0].cev[165].cevr";
connectAttr "animCurveTA4556.a" "clipLibrary1.cel[0].cev[166].cevr";
connectAttr "animCurveTA4557.a" "clipLibrary1.cel[0].cev[167].cevr";
connectAttr "animCurveTL4555.a" "clipLibrary1.cel[0].cev[168].cevr";
connectAttr "animCurveTL4556.a" "clipLibrary1.cel[0].cev[169].cevr";
connectAttr "animCurveTL4557.a" "clipLibrary1.cel[0].cev[170].cevr";
connectAttr "animCurveTU4558.a" "clipLibrary1.cel[0].cev[171].cevr";
connectAttr "animCurveTU4559.a" "clipLibrary1.cel[0].cev[172].cevr";
connectAttr "animCurveTU4560.a" "clipLibrary1.cel[0].cev[173].cevr";
connectAttr "animCurveTA4558.a" "clipLibrary1.cel[0].cev[174].cevr";
connectAttr "animCurveTA4559.a" "clipLibrary1.cel[0].cev[175].cevr";
connectAttr "animCurveTA4560.a" "clipLibrary1.cel[0].cev[176].cevr";
connectAttr "animCurveTL4558.a" "clipLibrary1.cel[0].cev[177].cevr";
connectAttr "animCurveTL4559.a" "clipLibrary1.cel[0].cev[178].cevr";
connectAttr "animCurveTL4560.a" "clipLibrary1.cel[0].cev[179].cevr";
connectAttr "animCurveTU4561.a" "clipLibrary1.cel[0].cev[180].cevr";
connectAttr "animCurveTU4562.a" "clipLibrary1.cel[0].cev[181].cevr";
connectAttr "animCurveTU4563.a" "clipLibrary1.cel[0].cev[182].cevr";
connectAttr "animCurveTA4561.a" "clipLibrary1.cel[0].cev[183].cevr";
connectAttr "animCurveTA4562.a" "clipLibrary1.cel[0].cev[184].cevr";
connectAttr "animCurveTA4563.a" "clipLibrary1.cel[0].cev[185].cevr";
connectAttr "animCurveTL4561.a" "clipLibrary1.cel[0].cev[186].cevr";
connectAttr "animCurveTL4562.a" "clipLibrary1.cel[0].cev[187].cevr";
connectAttr "animCurveTL4563.a" "clipLibrary1.cel[0].cev[188].cevr";
connectAttr "animCurveTU4564.a" "clipLibrary1.cel[0].cev[189].cevr";
connectAttr "animCurveTU4565.a" "clipLibrary1.cel[0].cev[190].cevr";
connectAttr "animCurveTU4566.a" "clipLibrary1.cel[0].cev[191].cevr";
connectAttr "animCurveTA4564.a" "clipLibrary1.cel[0].cev[192].cevr";
connectAttr "animCurveTA4565.a" "clipLibrary1.cel[0].cev[193].cevr";
connectAttr "animCurveTA4566.a" "clipLibrary1.cel[0].cev[194].cevr";
connectAttr "animCurveTL4564.a" "clipLibrary1.cel[0].cev[195].cevr";
connectAttr "animCurveTL4565.a" "clipLibrary1.cel[0].cev[196].cevr";
connectAttr "animCurveTL4566.a" "clipLibrary1.cel[0].cev[197].cevr";
connectAttr "animCurveTU4567.a" "clipLibrary1.cel[0].cev[198].cevr";
connectAttr "animCurveTU4568.a" "clipLibrary1.cel[0].cev[199].cevr";
connectAttr "animCurveTU4569.a" "clipLibrary1.cel[0].cev[200].cevr";
connectAttr "animCurveTA4567.a" "clipLibrary1.cel[0].cev[201].cevr";
connectAttr "animCurveTA4568.a" "clipLibrary1.cel[0].cev[202].cevr";
connectAttr "animCurveTA4569.a" "clipLibrary1.cel[0].cev[203].cevr";
connectAttr "animCurveTL4567.a" "clipLibrary1.cel[0].cev[204].cevr";
connectAttr "animCurveTL4568.a" "clipLibrary1.cel[0].cev[205].cevr";
connectAttr "animCurveTL4569.a" "clipLibrary1.cel[0].cev[206].cevr";
connectAttr "animCurveTU4570.a" "clipLibrary1.cel[0].cev[207].cevr";
connectAttr "animCurveTU4571.a" "clipLibrary1.cel[0].cev[208].cevr";
connectAttr "animCurveTU4572.a" "clipLibrary1.cel[0].cev[209].cevr";
connectAttr "animCurveTA4570.a" "clipLibrary1.cel[0].cev[210].cevr";
connectAttr "animCurveTA4571.a" "clipLibrary1.cel[0].cev[211].cevr";
connectAttr "animCurveTA4572.a" "clipLibrary1.cel[0].cev[212].cevr";
connectAttr "animCurveTL4570.a" "clipLibrary1.cel[0].cev[213].cevr";
connectAttr "animCurveTL4571.a" "clipLibrary1.cel[0].cev[214].cevr";
connectAttr "animCurveTL4572.a" "clipLibrary1.cel[0].cev[215].cevr";
connectAttr "animCurveTU4573.a" "clipLibrary1.cel[0].cev[216].cevr";
connectAttr "animCurveTU4574.a" "clipLibrary1.cel[0].cev[217].cevr";
connectAttr "animCurveTU4575.a" "clipLibrary1.cel[0].cev[218].cevr";
connectAttr "animCurveTA4573.a" "clipLibrary1.cel[0].cev[219].cevr";
connectAttr "animCurveTA4574.a" "clipLibrary1.cel[0].cev[220].cevr";
connectAttr "animCurveTA4575.a" "clipLibrary1.cel[0].cev[221].cevr";
connectAttr "animCurveTL4573.a" "clipLibrary1.cel[0].cev[222].cevr";
connectAttr "animCurveTL4574.a" "clipLibrary1.cel[0].cev[223].cevr";
connectAttr "animCurveTL4575.a" "clipLibrary1.cel[0].cev[224].cevr";
connectAttr "animCurveTU4576.a" "clipLibrary1.cel[0].cev[225].cevr";
connectAttr "animCurveTU4577.a" "clipLibrary1.cel[0].cev[226].cevr";
connectAttr "animCurveTU4578.a" "clipLibrary1.cel[0].cev[227].cevr";
connectAttr "animCurveTA4576.a" "clipLibrary1.cel[0].cev[228].cevr";
connectAttr "animCurveTA4577.a" "clipLibrary1.cel[0].cev[229].cevr";
connectAttr "animCurveTA4578.a" "clipLibrary1.cel[0].cev[230].cevr";
connectAttr "animCurveTL4576.a" "clipLibrary1.cel[0].cev[231].cevr";
connectAttr "animCurveTL4577.a" "clipLibrary1.cel[0].cev[232].cevr";
connectAttr "animCurveTL4578.a" "clipLibrary1.cel[0].cev[233].cevr";
connectAttr "animCurveTU4579.a" "clipLibrary1.cel[0].cev[234].cevr";
connectAttr "animCurveTU4580.a" "clipLibrary1.cel[0].cev[235].cevr";
connectAttr "animCurveTU4581.a" "clipLibrary1.cel[0].cev[236].cevr";
connectAttr "animCurveTA4579.a" "clipLibrary1.cel[0].cev[237].cevr";
connectAttr "animCurveTA4580.a" "clipLibrary1.cel[0].cev[238].cevr";
connectAttr "animCurveTA4581.a" "clipLibrary1.cel[0].cev[239].cevr";
connectAttr "animCurveTL4579.a" "clipLibrary1.cel[0].cev[240].cevr";
connectAttr "animCurveTL4580.a" "clipLibrary1.cel[0].cev[241].cevr";
connectAttr "animCurveTL4581.a" "clipLibrary1.cel[0].cev[242].cevr";
connectAttr "animCurveTU4582.a" "clipLibrary1.cel[0].cev[243].cevr";
connectAttr "animCurveTU4583.a" "clipLibrary1.cel[0].cev[244].cevr";
connectAttr "animCurveTU4584.a" "clipLibrary1.cel[0].cev[245].cevr";
connectAttr "animCurveTA4582.a" "clipLibrary1.cel[0].cev[246].cevr";
connectAttr "animCurveTA4583.a" "clipLibrary1.cel[0].cev[247].cevr";
connectAttr "animCurveTA4584.a" "clipLibrary1.cel[0].cev[248].cevr";
connectAttr "animCurveTL4582.a" "clipLibrary1.cel[0].cev[249].cevr";
connectAttr "animCurveTL4583.a" "clipLibrary1.cel[0].cev[250].cevr";
connectAttr "animCurveTL4584.a" "clipLibrary1.cel[0].cev[251].cevr";
connectAttr "animCurveTU4585.a" "clipLibrary1.cel[0].cev[252].cevr";
connectAttr "animCurveTU4586.a" "clipLibrary1.cel[0].cev[253].cevr";
connectAttr "animCurveTU4587.a" "clipLibrary1.cel[0].cev[254].cevr";
connectAttr "animCurveTA4585.a" "clipLibrary1.cel[0].cev[255].cevr";
connectAttr "animCurveTA4586.a" "clipLibrary1.cel[0].cev[256].cevr";
connectAttr "animCurveTA4587.a" "clipLibrary1.cel[0].cev[257].cevr";
connectAttr "animCurveTL4585.a" "clipLibrary1.cel[0].cev[258].cevr";
connectAttr "animCurveTL4586.a" "clipLibrary1.cel[0].cev[259].cevr";
connectAttr "animCurveTL4587.a" "clipLibrary1.cel[0].cev[260].cevr";
connectAttr "animCurveTU4588.a" "clipLibrary1.cel[0].cev[261].cevr";
connectAttr "animCurveTU4589.a" "clipLibrary1.cel[0].cev[262].cevr";
connectAttr "animCurveTU4590.a" "clipLibrary1.cel[0].cev[263].cevr";
connectAttr "animCurveTA4588.a" "clipLibrary1.cel[0].cev[264].cevr";
connectAttr "animCurveTA4589.a" "clipLibrary1.cel[0].cev[265].cevr";
connectAttr "animCurveTA4590.a" "clipLibrary1.cel[0].cev[266].cevr";
connectAttr "animCurveTL4588.a" "clipLibrary1.cel[0].cev[267].cevr";
connectAttr "animCurveTL4589.a" "clipLibrary1.cel[0].cev[268].cevr";
connectAttr "animCurveTL4590.a" "clipLibrary1.cel[0].cev[269].cevr";
// End of bat_invert_idle.ma
