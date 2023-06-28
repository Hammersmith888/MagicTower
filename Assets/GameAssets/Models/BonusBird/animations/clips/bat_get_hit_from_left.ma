//Maya ASCII 2013 scene
//Name: bat_get_hit_from_left.ma
//Last modified: Sat, Jul 12, 2014 02:46:56 PM
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
createNode animClip -n "get_hit_from_leftSource";
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
	setAttr ".ss" 111;
	setAttr ".se" 130;
	setAttr ".ci" no;
createNode animCurveTU -n "animCurveTU1261";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1262";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1263";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1261";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  111 0 114 28.213159561157227 117 27.064813613891602
		 122 6.3252978324890137 130 0;
	setAttr -s 5 ".ktl[0:4]" no yes yes yes no;
	setAttr -s 5 ".kix[0:4]"  1 0.46777328848838806 0.65746527910232544 
		0.75367069244384766 1;
	setAttr -s 5 ".kiy[0:4]"  0 0.88384842872619629 -0.75348484516143799 
		-0.65725219249725342 0;
	setAttr -s 5 ".kox[0:4]"  1 0.46777328848838806 0.65746527910232544 
		0.75367069244384766 1;
	setAttr -s 5 ".koy[0:4]"  0 0.88384842872619629 -0.75348484516143799 
		-0.65725219249725342 0;
createNode animCurveTA -n "animCurveTA1262";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 117 46.995841979980469 122 28.779098510742184
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.67404550313949585 0.551064133644104 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.7386898398399353 -0.83446288108825684 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.67404550313949585 0.551064133644104 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.7386898398399353 -0.83446288108825684 
		0;
createNode animCurveTA -n "animCurveTA1263";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 117 28.459024429321289 122 -29.644741058349609
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.66308915615081787 0.73703485727310181 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.74854040145874023 -0.67585480213165283 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.66308915615081787 0.73703485727310181 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.74854040145874023 -0.67585480213165283 
		0;
createNode animCurveTL -n "animCurveTL1261";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -5.7247552871704102 130 -5.7247552871704102;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1262";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 12.644636154174805 130 12.644636154174805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1263";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 43.253993988037109 130 43.253993988037109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1264";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1265";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1266";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1264";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 116 -20.742237091064453 121 -20.742237091064453
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.75487309694290161 0.84967172145843506 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.65587085485458374 0.52731192111968994 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.75487309694290161 0.84967172145843506 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.65587085485458374 0.52731192111968994 
		0;
createNode animCurveTA -n "animCurveTA1265";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 116 0.83327752351760864 121 0.83327752351760864
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99939143657684326 0.99968934059143066 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.034883026033639908 -0.024923874065279961 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99939143657684326 0.99968934059143066 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.034883026033639908 -0.024923874065279961 
		0;
createNode animCurveTA -n "animCurveTA1266";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 116 -5.0326323509216309 121 -5.0326323509216309
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.97849446535110474 0.98885256052017212 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20627295970916748 0.14889755845069885 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.97849446535110474 0.98885256052017212 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20627295970916748 0.14889755845069885 
		0;
createNode animCurveTL -n "animCurveTL1264";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 -1.9167585372924805 116 -1.9167585372924805
		 121 -1.9167585372924805 130 -1.9167585372924805;
	setAttr -s 4 ".kix[0:3]"  1 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  1 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL1265";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 -5.0555992126464844 116 -5.0555992126464844
		 121 -5.0555992126464844 130 -5.0555992126464844;
	setAttr -s 4 ".kix[0:3]"  1 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  1 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL1266";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 28.262805938720703 116 28.262805938720703
		 121 28.262805938720703 130 28.262805938720703;
	setAttr -s 4 ".kix[0:3]"  1 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  1 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTU -n "animCurveTU1267";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1268";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1269";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1267";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  111 0 114 29.829652786254886 115 22.790458679199219
		 116 23.501316070556641 117 23.600898742675781 118 23.398967742919922 119 22.826234817504883
		 120 21.923406600952148 121 20.727809906005859 125 -12.359256744384766 130 0;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes no;
	setAttr -s 11 ".kix[0:10]"  1 0.38645118474960327 0.6022905707359314 
		0.98589849472045898 0.99977028369903564 0.98709255456924438 0.95541632175445557 0.91548550128936768 
		0.32882100343704224 0.71968948841094971 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.92230981588363647 -0.79827690124511719 
		0.16734428703784943 -0.021431004628539085 -0.16015084087848663 -0.29526194930076599 
		-0.40235105156898499 -0.94439226388931274 -0.69429612159729004 0;
	setAttr -s 11 ".kox[0:10]"  1 0.38645118474960327 0.6022905707359314 
		0.98589849472045898 0.99977028369903564 0.98709255456924438 0.95541632175445557 0.91548550128936768 
		0.32882100343704224 0.71968948841094971 1;
	setAttr -s 11 ".koy[0:10]"  0 0.92230981588363647 -0.79827690124511719 
		0.16734428703784943 -0.021431004628539085 -0.16015084087848663 -0.29526194930076599 
		-0.40235105156898499 -0.94439226388931274 -0.69429612159729004 0;
createNode animCurveTA -n "animCurveTA1268";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  111 0 114 -9.9790019989013672 115 -26.052816390991211
		 116 -25.418119430541992 117 -25.325958251953125 118 -25.511987686157227 119 -26.021816253662109
		 120 -26.775466918945313 121 -27.688148498535156 130 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.34414634108543396 0.29545128345489502 
		0.98861026763916016 0.99980682134628296 0.98954623937606812 0.96672523021697998 0.94415324926376343 
		0.6654970645904541 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.93891602754592896 -0.95535784959793091 
		0.1504986584186554 -0.019655926153063774 -0.14421612024307251 -0.25581669807434082 
		-0.32950675487518311 0.74640047550201416 0;
	setAttr -s 10 ".kox[0:9]"  1 0.34414634108543396 0.29545128345489502 
		0.98861026763916016 0.99980682134628296 0.98954623937606812 0.96672523021697998 0.94415324926376343 
		0.6654970645904541 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.93891602754592896 -0.95535784959793091 
		0.1504986584186554 -0.019655926153063774 -0.14421612024307251 -0.25581669807434082 
		-0.32950675487518311 0.74640047550201416 0;
createNode animCurveTA -n "animCurveTA1269";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  111 0 114 -20.650945663452148 115 -5.8824453353881836
		 116 -7.530545711517334 117 -7.7645554542541504 118 -7.2908644676208505 119 -5.9644918441772461
		 120 -3.9208128452301025 121 -1.2920641899108887 130 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.85142099857330322 0.34197106957435608 
		0.93032968044281006 0.99874234199523926 0.9357113242149353 0.81699162721633911 0.71471470594406128 
		0.98678040504455566 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.52448290586471558 0.93971049785614014 
		-0.36672431230545044 0.050135817378759384 0.35276663303375244 0.57664948701858521 
		0.69941616058349609 0.16206353902816772 0;
	setAttr -s 10 ".kox[0:9]"  1 0.85142099857330322 0.34197106957435608 
		0.93032968044281006 0.99874234199523926 0.9357113242149353 0.81699162721633911 0.71471470594406128 
		0.98678040504455566 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.52448290586471558 0.93971049785614014 
		-0.36672431230545044 0.050135817378759384 0.35276663303375244 0.57664948701858521 
		0.69941616058349609 0.16206353902816772 0;
createNode animCurveTL -n "animCurveTL1267";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 -5.7247552871704102 114 -5.7247552871704102
		 120 -5.7247552871704102 130 -5.7247552871704102;
	setAttr -s 4 ".kix[0:3]"  1 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  1 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL1268";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  111 12.644636154174805 114 29.353170394897461
		 115 32.997020721435547 116 34.586891174316406 117 35.342742919921875 118 35.750091552734375
		 119 35.709663391113281 120 35.103130340576172 121 33.78033447265625 125 26.121583938598633
		 130 12.644636154174805;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes no;
	setAttr -s 11 ".kix[0:10]"  1 0.0081887654960155487 0.015920404344797134 
		0.035503290593624115 0.071457944810390472 0.22147688269615173 0.12775219976902008 
		0.04315248504281044 0.023189488798379898 0.017739702016115189 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.99996644258499146 0.99987328052520752 
		0.99936956167221069 0.99744361639022827 0.97516566514968872 -0.99180608987808228 
		-0.9990684986114502 -0.99973106384277344 -0.99984264373779297 0;
	setAttr -s 11 ".kox[0:10]"  1 0.0081887654960155487 0.015920404344797134 
		0.035503290593624115 0.071457944810390472 0.22147688269615173 0.12775219976902008 
		0.04315248504281044 0.023189488798379898 0.017739702016115189 1;
	setAttr -s 11 ".koy[0:10]"  0 0.99996644258499146 0.99987328052520752 
		0.99936956167221069 0.99744361639022827 0.97516566514968872 -0.99180608987808228 
		-0.9990684986114502 -0.99973106384277344 -0.99984264373779297 0;
createNode animCurveTL -n "animCurveTL1269";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  111 -43.253993988037109 114 -59.088138580322266
		 115 -53.560352325439453 116 -51.255420684814453 117 -50.6402587890625 118 -51.099864959716797
		 119 -52.989391326904297 120 -56.098648071289063 121 -60.185512542724609 125 -55.353462219238281
		 130 -43.253993988037109;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes no;
	setAttr -s 11 ".kix[0:10]"  1 0.016169112175703049 0.010638552717864513 
		0.02852633036673069 0.47221443057060242 0.035451881587505341 0.016668440774083138 
		0.011579492129385471 0.26924842596054077 0.022142613306641579 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.99986928701400757 0.99994343519210815 
		0.99959307909011841 0.88148373365402222 -0.99937140941619873 -0.99986112117767334 
		-0.99993294477462769 0.96307080984115601 0.99975484609603882 0;
	setAttr -s 11 ".kox[0:10]"  1 0.016169112175703049 0.010638552717864513 
		0.02852633036673069 0.47221443057060242 0.035451881587505341 0.016668440774083138 
		0.011579492129385471 0.26924842596054077 0.022142613306641579 1;
	setAttr -s 11 ".koy[0:10]"  0 -0.99986928701400757 0.99994343519210815 
		0.99959307909011841 0.88148373365402222 -0.99937140941619873 -0.99986112117767334 
		-0.99993294477462769 0.96307080984115601 0.99975484609603882 0;
createNode animCurveTU -n "animCurveTU1270";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1271";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1272";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1270";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0.0048254411667585373 112 0 113 0 130 0.0048254411667585373;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.0010106356348842382 0.00011229312804061919 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0010106356348842382 0.00011229312804061919 
		0;
createNode animCurveTA -n "animCurveTA1271";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 1.5292341709136963 112 0 113 0 130 1.5292341709136963;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9523463249206543 0.99936741590499878 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.30501881241798401 0.035564377903938293 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9523463249206543 0.99936741590499878 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.30501881241798401 0.035564377903938293 
		0;
createNode animCurveTA -n "animCurveTA1272";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 1.0246820449829102 112 0 113 0 130 1.0246820449829102;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9777376651763916 0.99971580505371094 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20983083546161652 0.02383865974843502 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9777376651763916 0.99971580505371094 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20983083546161652 0.02383865974843502 
		0;
createNode animCurveTL -n "animCurveTL1270";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -0.72905689477920532 130 -0.72905689477920532;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1271";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -19.141372680664063 130 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1272";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 23.549764633178711 130 23.549764633178711;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1273";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1274";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1275";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1273";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1274";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1275";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 12.527528762817383 130 12.527528762817383;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1273";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -36.1805419921875 130 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1274";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 7.3658723831176758 130 7.3658723831176758;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1275";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 41.597393035888672 130 41.597393035888672;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1276";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1277";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1278";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1276";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0.0048254411667585373 112 0 113 0 130 0.0048254411667585373;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.0010106356348842382 0.00011229312804061919 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0010106356348842382 0.00011229312804061919 
		0;
createNode animCurveTA -n "animCurveTA1277";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 1.5292341709136963 112 0 113 0 130 1.5292341709136963;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9523463249206543 0.99936741590499878 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.30501881241798401 0.035564377903938293 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9523463249206543 0.99936741590499878 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.30501881241798401 0.035564377903938293 
		0;
createNode animCurveTA -n "animCurveTA1278";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 1.0246820449829102 112 0 113 0 130 1.0246820449829102;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9777376651763916 0.99971580505371094 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20983083546161652 0.02383865974843502 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9777376651763916 0.99971580505371094 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20983083546161652 0.02383865974843502 
		0;
createNode animCurveTL -n "animCurveTL1276";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -0.11375267058610916 130 -0.11375267058610916;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1277";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -0.067464433610439301 130 -0.067464433610439301;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1278";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 41.135360717773437 130 41.135360717773437;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1279";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1280";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1281";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1279";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 11.022937774658203 130 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1280";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 -5.0461244583129883 130 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1281";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 12.527528762817383 116 13.587104797363281
		 130 12.527528762817383;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1279";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -54.695327758789062 116 -54.695327758789062
		 130 -54.695327758789062;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1280";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 3.2521772384643555 116 11.117268562316895
		 130 3.2521772384643555;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1281";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 0 130 0;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1282";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1283";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1284";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1282";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0.0048254411667585373 112 0 113 0 130 0.0048254411667585373;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.0010106356348842382 0.00011229312804061919 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0010106356348842382 0.00011229312804061919 
		0;
createNode animCurveTA -n "animCurveTA1283";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 1.5292341709136963 112 0 113 0 130 1.5292341709136963;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9523463249206543 0.99936741590499878 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.30501881241798401 0.035564377903938293 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9523463249206543 0.99936741590499878 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.30501881241798401 0.035564377903938293 
		0;
createNode animCurveTA -n "animCurveTA1284";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 1.0246820449829102 112 0 113 0 130 1.0246820449829102;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9777376651763916 0.99971580505371094 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20983083546161652 0.02383865974843502 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9777376651763916 0.99971580505371094 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20983083546161652 0.02383865974843502 
		0;
createNode animCurveTL -n "animCurveTL1282";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -2.6052179336547852 130 -2.6052179336547852;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1283";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -19.141372680664063 130 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1284";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 23.227632522583008 130 23.227632522583008;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1285";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1286";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1287";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1285";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 50.691921234130859 130 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1286";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 -23.934183120727539 130 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1287";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 12.527528762817383 116 -0.26591598987579346
		 130 12.527528762817383;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1285";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -36.1805419921875 116 -36.1805419921875
		 130 -36.1805419921875;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1286";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 7.3658723831176758 116 9.4866580963134766
		 130 7.3658723831176758;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1287";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -41.399761199951172 116 -41.399761199951172
		 130 -41.399761199951172;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1288";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1289";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1290";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1288";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1289";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1290";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1288";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 22.400806427001953 130 22.400806427001953;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1289";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 10.647112846374512 130 10.647112846374512;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1290";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1291";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1292";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1293";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1291";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1292";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1293";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1291";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 35.083248138427734 130 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1292";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 30.643020629882813 130 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1293";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 36.804916381835937 130 36.804916381835937;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1294";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1295";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1296";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1294";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1295";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1296";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1294";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 35.083248138427734 130 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1295";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 30.643020629882813 130 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1296";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -36.361770629882813 130 -36.361770629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1297";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1298";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1299";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1297";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1298";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1299";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1297";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -5.8221402168273926 130 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1298";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -10.433219909667969 130 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1299";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -28.427871704101563 130 -28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1300";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1301";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1302";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1300";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 113 -22.765649795532227 116 11.962923049926758
		 119 16.684890747070312 121 16.049772262573242 124 12.950023651123047 127 -0.82227146625518799
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.70632845163345337 0.34128627181053162 
		0.94608443975448608 0.95437341928482056 0.64719474315643311 0.74178659915924072 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.70788425207138062 0.93995946645736694 
		0.32392001152038574 -0.29861587285995483 -0.76232469081878662 -0.67063599824905396 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.70632845163345337 0.34128627181053162 
		0.94608443975448608 0.95437341928482056 0.64719474315643311 0.74178659915924072 1;
	setAttr -s 8 ".koy[0:7]"  0 0.70788425207138062 0.93995946645736694 
		0.32392001152038574 -0.29861587285995483 -0.76232469081878662 -0.67063599824905396 
		0;
createNode animCurveTA -n "animCurveTA1301";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 113 10.220004081726074 116 0.21278534829616547
		 119 -1.7370536327362061 121 -2.3446319103240967 124 -3.2371189594268799 127 0.67567956447601318
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99984121322631836 0.76768231391906738 
		0.97780954837799072 0.99219590425491333 0.9784843921661377 0.97540175914764404 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.017823418602347374 -0.6408306360244751 
		-0.20949570834636688 -0.12468864023685455 0.20632079243659973 0.22043450176715851 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99984121322631836 0.76768231391906738 
		0.97780954837799072 0.99219590425491333 0.9784843921661377 0.97540175914764404 1;
	setAttr -s 8 ".koy[0:7]"  0 0.017823418602347374 -0.6408306360244751 
		-0.20949570834636688 -0.12468864023685455 0.20632079243659973 0.22043450176715851 
		0;
createNode animCurveTA -n "animCurveTA1302";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 113 12.242433547973633 116 19.712648391723633
		 119 17.095508575439453 121 14.76383590698242 124 13.207479476928711 127 5.5054006576538086
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.51797062158584595 0.94711613655090332 
		0.92375606298446655 0.95083171129226685 0.83983749151229858 0.73517733812332153 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.85539835691452026 0.32089102268218994 
		-0.38298130035400391 -0.30970805883407593 -0.54283797740936279 -0.67787474393844604 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.51797062158584595 0.94711613655090332 
		0.92375606298446655 0.95083171129226685 0.83983749151229858 0.73517733812332153 1;
	setAttr -s 8 ".koy[0:7]"  0 0.85539835691452026 0.32089102268218994 
		-0.38298130035400391 -0.30970805883407593 -0.54283797740936279 -0.67787474393844604 
		0;
createNode animCurveTL -n "animCurveTL1300";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 11.41090202331543 116 10.480576515197754
		 130 11.41090202331543;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1301";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -0.91886520385742188 116 -0.36813303828239441
		 130 -0.91886520385742188;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1302";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -13.740226745605469 116 -18.447288513183594
		 130 -13.740226745605469;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1303";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1304";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1305";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 1 116 1 130 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1303";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 -44.445175170898438 130 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1304";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 -19.805761337280273 130 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1305";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0 116 19.946817398071289 130 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1303";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0.057151313871145248 116 -0.86372637748718262
		 130 0.057151313871145248;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1304";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 23.729547500610352 116 24.274686813354492
		 130 23.729547500610352;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1305";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -53.338920593261719 116 -57.998180389404297
		 130 -53.338920593261719;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1306";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1307";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1308";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1306";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1307";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1308";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1306";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -5.8221402168273926 130 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1307";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -10.433219909667969 130 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1308";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 28.427871704101563 130 28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1309";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1310";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1311";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1309";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  111 0 112 3.4822049140930176 114 -28.589834213256836
		 116 -27.184732437133789 119 -3.9386708736419678 121 1.8728443384170532 124 -6.4158225059509277
		 127 3.7560007572174077 130 0;
	setAttr -s 9 ".ktl[0:8]" no yes yes yes yes yes yes yes no;
	setAttr -s 9 ".kix[0:8]"  1 0.24299919605255127 0.29730764031410217 
		0.43581670522689819 0.3799799382686615 0.97913801670074463 0.99146831035614014 0.91263431310653687 
		1;
	setAttr -s 9 ".kiy[0:8]"  0 -0.97002649307250977 -0.95478177070617676 
		0.90003550052642822 0.92499470710754395 -0.20319631695747375 0.13034747540950775 
		0.40877699851989746 0;
	setAttr -s 9 ".kox[0:8]"  1 0.24299919605255127 0.29730764031410217 
		0.43581670522689819 0.3799799382686615 0.97913801670074463 0.99146831035614014 0.91263431310653687 
		1;
	setAttr -s 9 ".koy[0:8]"  0 -0.97002649307250977 -0.95478177070617676 
		0.90003550052642822 0.92499470710754395 -0.20319631695747375 0.13034747540950775 
		0.40877699851989746 0;
createNode animCurveTA -n "animCurveTA1310";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 114 -0.17859935760498047 116 0.18131028115749359
		 119 -1.9616516828536987 121 -2.4973921775817871 124 -6.8123245239257813 127 1.0975222587585449
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99988466501235962 0.98902660608291626 
		0.97573268413543701 0.92642790079116821 0.96992015838623047 0.90307092666625977 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.015187651850283146 -0.14773735404014587 
		-0.21896494925022125 -0.37647214531898499 0.24342314898967743 0.42949151992797852 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99988466501235962 0.98902660608291626 
		0.97573268413543701 0.92642790079116821 0.96992015838623047 0.90307092666625977 1;
	setAttr -s 8 ".koy[0:7]"  0 0.015187651850283146 -0.14773735404014587 
		-0.21896494925022125 -0.37647214531898499 0.24342314898967743 0.42949151992797852 
		0;
createNode animCurveTA -n "animCurveTA1311";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 114 9.4982233047485352 116 9.7092819213867188
		 119 5.0221700668334961 121 3.8503921031951904 124 7.9581441879272461 127 0.8807712197303772
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.77577131986618042 0.93633383512496948 
		0.89769423007965088 0.97105765342712402 0.97917830944061279 0.87414693832397461 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.63101410865783691 -0.35111084580421448 
		-0.44061881303787231 0.23884518444538116 -0.20300191640853882 -0.48566144704818726 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.77577131986618042 0.93633383512496948 
		0.89769423007965088 0.97105765342712402 0.97917830944061279 0.87414693832397461 1;
	setAttr -s 8 ".koy[0:7]"  0 0.63101410865783691 -0.35111084580421448 
		-0.44061881303787231 0.23884518444538116 -0.20300191640853882 -0.48566144704818726 
		0;
createNode animCurveTL -n "animCurveTL1309";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 11.41090202331543 130 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1310";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -0.91886520385742188 130 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1311";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 13.740226745605469 130 13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1312";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1313";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1314";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1312";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 113 -28.589834213256836 115 -27.184732437133789
		 118 -3.9386708736419678 120 1.8728443384170532 123 -6.4158225059509277 126 3.7560007572174077
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.33142098784446716 0.43581601977348328 
		0.3799806535243988 0.97913813591003418 0.99146831035614014 0.93356227874755859 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.94348299503326416 0.9000357985496521 
		0.92499440908432007 -0.20319584012031555 0.13034747540950775 0.35841524600982666 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.33142098784446716 0.43581601977348328 
		0.3799806535243988 0.97913813591003418 0.99146831035614014 0.93356227874755859 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.94348299503326416 0.9000357985496521 
		0.92499440908432007 -0.20319584012031555 0.13034747540950775 0.35841524600982666 
		0;
createNode animCurveTA -n "animCurveTA1313";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 113 -0.17859935760498047 115 0.18131028115749359
		 118 -1.9616516828536987 120 -2.4973921775817871 123 -6.8123245239257813 126 1.0975222587585449
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99981981515884399 0.98902660608291626 
		0.97573280334472656 0.92642819881439209 0.96992015838623047 0.926014244556427 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.01898336224257946 -0.14773769676685333 
		-0.21896451711654663 -0.37647145986557007 0.24342314898967743 0.37748855352401733 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99981981515884399 0.98902660608291626 
		0.97573280334472656 0.92642819881439209 0.96992015838623047 0.926014244556427 1;
	setAttr -s 8 ".koy[0:7]"  0 0.01898336224257946 -0.14773769676685333 
		-0.21896451711654663 -0.37647145986557007 0.24342314898967743 0.37748855352401733 
		0;
createNode animCurveTA -n "animCurveTA1314";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  111 0 113 9.4982233047485352 115 9.7092819213867188
		 118 5.0221700668334961 120 3.8503921031951904 123 7.9581441879272461 126 0.8807712197303772
		 130 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.70120811462402344 0.93633359670639038 
		0.89769470691680908 0.97105777263641357 0.97917830944061279 0.90285211801528931 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.71295660734176636 -0.35111153125762939 
		-0.44061803817749023 0.23884472250938416 -0.20300191640853882 -0.4299512505531311 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.70120811462402344 0.93633359670639038 
		0.89769470691680908 0.97105777263641357 0.97917830944061279 0.90285211801528931 1;
	setAttr -s 8 ".koy[0:7]"  0 0.71295660734176636 -0.35111153125762939 
		-0.44061803817749023 0.23884472250938416 -0.20300191640853882 -0.4299512505531311 
		0;
createNode animCurveTL -n "animCurveTL1312";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0.057151321321725845 130 0.057151321321725845;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1313";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 23.729547500610352 130 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1314";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 53.782066345214844 130 53.782066345214844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1315";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1316";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1317";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1315";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 -1.6647806167602539 122 6.7356438636779785
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99986273050308228 0.99999135732650757 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.016564738005399704 0.0041628330945968628 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999135732650757 0.99999111890792847 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.0041598593816161156 -0.0042202034965157509 
		0;
createNode animCurveTA -n "animCurveTA1316";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 34.385700225830078 122 -19.266994476318359
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.94613993167877197 0.99964672327041626 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.32375797629356384 -0.026578444987535477 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99964720010757446 0.9999271035194397 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.026559485122561455 0.012070921249687672 
		0;
createNode animCurveTA -n "animCurveTA1317";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 18.04615592956543 122 11.426885604858398
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.98425436019897461 0.99999463558197021 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.17675803601741791 -0.0032801912166178226 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999463558197021 0.99997442960739136 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0032778480090200901 -0.0071593713946640491 
		0;
createNode animCurveTL -n "animCurveTL1315";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -1.1630247831344604 130 -1.1630247831344604;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1316";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1.228269100189209 130 1.228269100189209;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1317";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 27.684015274047852 130 27.684015274047852;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1318";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1319";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1320";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1318";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 -17.5140380859375 122 26.14234733581543
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.98514896631240845 0.99976611137390137 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.17170199751853943 0.021629059687256813 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99976640939712524 0.99986588954925537 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.021613625809550285 -0.016377381980419159 
		0;
createNode animCurveTA -n "animCurveTA1319";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 -14.218031883239746 122 -24.542560577392578
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.60300970077514648 0.99999970197677612 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.7977338433265686 -0.00079216680023819208 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.63511258363723755 0.99988186359405518 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.77241963148117065 0.015375410206615925 
		0;
createNode animCurveTA -n "animCurveTA1320";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 37.118995666503906 122 -14.269143104553223
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.93804836273193359 0.9996759295463562 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.34650424122810364 -0.025457374751567841 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9996764063835144 0.99996000528335571 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.025439208373427391 0.0089400233700871468 
		0;
createNode animCurveTL -n "animCurveTL1318";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 4.9883952140808105 130 4.9883952140808105;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1319";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 41.4617919921875 130 41.4617919921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1320";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 38.623714447021484 130 38.623714447021484;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1321";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1322";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1323";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1321";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 -1.6647806167602539 122 6.7260823249816895
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99986273050308228 0.99999135732650757 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.016564738005399704 0.0041580949909985065 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999135732650757 0.99999111890792847 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.0041551259346306324 -0.0042142136953771114 
		0;
createNode animCurveTA -n "animCurveTA1322";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 34.385700225830078 122 -19.234474182128906
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.94613993167877197 0.99964714050292969 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.32375797629356384 -0.026562346145510674 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99964773654937744 0.9999273419380188 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.026543395593762398 0.012050552293658257 
		0;
createNode animCurveTA -n "animCurveTA1323";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 18.04615592956543 122 11.506757736206055
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.98425436019897461 0.99999469518661499 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.17675803601741791 -0.0032406111713498831 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999469518661499 0.99997401237487793 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0032382970675826073 -0.0072094127535820007 
		0;
createNode animCurveTL -n "animCurveTL1321";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1.1630247831344604 130 1.1630247831344604;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1322";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 2.0187394618988037 130 2.0187394618988037;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1323";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 27.637619018554688 130 27.637619018554688;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1324";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1325";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1326";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1324";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 19.510826110839844 122 -25.465585708618164
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.98166745901107788 0.99975168704986572 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.1906018853187561 -0.022282732650637627 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99975210428237915 0.99987274408340454 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.022266829386353493 0.015953518450260162 
		0;
createNode animCurveTA -n "animCurveTA1325";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 33.203403472900391 122 11.476161956787109
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.94950920343399048 0.99994200468063354 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.31373929977416992 -0.010766409337520599 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9999421238899231 0.99997419118881226 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.010758719407021999 -0.0071902447380125523 
		0;
createNode animCurveTA -n "animCurveTA1326";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 113 22.514463424682617 122 -25.851930618286133
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9758075475692749 0.99971288442611694 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.2186315655708313 -0.023961305618286133 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99971330165863037 0.99986886978149414 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.023944204673171043 0.016195490956306458 
		0;
createNode animCurveTL -n "animCurveTL1324";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 4.9883952140808105 130 4.9883952140808105;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1325";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 41.4617919921875 130 41.4617919921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1326";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -38.180568695068359 130 -38.180568695068359;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1327";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1328";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1329";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1327";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -9.5584049224853516 119 -4.7276773452758789
		 130 -9.5584049224853516;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1328";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -14.087939262390137 119 -14.722927093505858
		 130 -14.087939262390137;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1329";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -2.2710940837860107 119 -14.460274696350098
		 130 -2.2710940837860107;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1327";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 32.845657348632812 130 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1328";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 17.186578750610352 130 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1329";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 11.930496215820313 130 11.930496215820313;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1330";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1331";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1332";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1330";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 -0.89352136850357056 119 3.8156967163085937
		 130 -0.89352136850357056;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1331";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 11.041102409362793 119 10.111042976379395
		 130 11.041102409362793;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1332";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 0.32489952445030212 119 -9.7969655990600586
		 130 0.32489952445030212;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1330";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 32.845657348632812 130 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1331";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 17.186578750610352 130 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1332";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -11.48735237121582 130 -11.48735237121582;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1333";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1334";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1335";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1333";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1334";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1335";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1333";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 47.368160247802734 130 47.368160247802734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1334";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  111 26.913848876953125 115 69.189155578613281
		 130 26.913848876953125;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1335";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0.22157172858715057 130 0.22157172858715057;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1336";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1337";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1338";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1336";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  111 0 112 -9.5518598556518555 113 -16.935991287231445
		 116 6.2262754440307617 119 8.9774618148803711 122 7.3384523391723633 130 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.2713463306427002 0.51777857542037964 
		0.48377275466918945 0.99699926376342773 0.94623464345932007 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.96248185634613037 0.85551470518112183 
		0.87519365549087524 0.077411584556102753 -0.32348087430000305 0;
	setAttr -s 7 ".kox[0:6]"  1 0.2713463306427002 0.51777857542037964 
		0.48377275466918945 0.99699926376342773 0.94623464345932007 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.96248185634613037 0.85551470518112183 
		0.87519365549087524 0.077411584556102753 -0.32348087430000305 0;
createNode animCurveTA -n "animCurveTA1337";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1338";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1336";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0.55634701251983643 130 0.55634701251983643;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1337";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  111 28.874954223632813 112 28.586336135864258
		 116 34.654804229736328 117 34.691616058349609 118 32.763950347900391 119 30.236442565917969
		 122 27.327857971191406 127 30.643697738647461 130 28.874954223632813;
	setAttr -s 9 ".ktl[0:8]" no yes yes yes yes yes yes yes no;
	setAttr -s 9 ".kix[0:8]"  1 0.036021403968334198 0.034103646874427795 
		0.044028885662555695 0.018701614812016487 0.030644942075014114 0.63337957859039307 
		0.21062390506267548 1;
	setAttr -s 9 ".kiy[0:8]"  0 0.99935102462768555 0.99941825866699219 
		-0.99903029203414917 -0.999825119972229 -0.99953031539916992 0.77384120225906372 
		0.97756719589233398 0;
	setAttr -s 9 ".kox[0:8]"  1 0.036021403968334198 0.034103646874427795 
		0.044028885662555695 0.018701614812016487 0.030644942075014114 0.63337957859039307 
		0.21062390506267548 1;
	setAttr -s 9 ".koy[0:8]"  0 0.99935102462768555 0.99941825866699219 
		-0.99903029203414917 -0.999825119972229 -0.99953031539916992 0.77384120225906372 
		0.97756719589233398 0;
createNode animCurveTL -n "animCurveTL1338";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  111 0 112 3.9458136558532715 116 -8.4793462753295898
		 117 -10.837972640991211 118 -11.414670944213867 119 -9.3194952011108398 122 -7.4307632446289063
		 127 -1.441595196723938 130 0;
	setAttr -s 9 ".ktl[0:8]" no yes yes yes yes yes yes yes no;
	setAttr -s 9 ".kix[0:8]"  1 0.024562111124396324 0.014090627431869507 
		0.028378276154398918 0.054797179996967316 0.041798483580350876 0.042274594306945801 
		0.044813450425863266 1;
	setAttr -s 9 ".kiy[0:8]"  0 -0.99969828128814697 -0.9999006986618042 
		-0.99959725141525269 0.99849748611450195 0.99912607669830322 0.99910604953765869 
		0.99899542331695557 0;
	setAttr -s 9 ".kox[0:8]"  1 0.024562111124396324 0.014090627431869507 
		0.028378276154398918 0.054797179996967316 0.041798483580350876 0.042274594306945801 
		0.044813450425863266 1;
	setAttr -s 9 ".koy[0:8]"  0 -0.99969828128814697 -0.9999006986618042 
		-0.99959725141525269 0.99849748611450195 0.99912607669830322 0.99910604953765869 
		0.99899542331695557 0;
createNode animCurveTU -n "animCurveTU1339";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1340";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1341";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1339";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1340";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1341";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1339";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -1.4725730419158936 130 -1.4725730419158936;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1340";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 25.007797241210938 130 25.007797241210938;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1341";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1342";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1343";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1344";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1342";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1343";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1344";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1342";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -0.28501001000404358 130 -0.28501001000404358;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1343";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1344";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1345";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1346";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1347";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1345";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 114 21.474340438842773 117 27.701995849609375
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.45930466055870056 0.8716883659362793 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.8882787823677063 -0.49006059765815735 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.45930466055870056 0.8716883659362793 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.8882787823677063 -0.49006059765815735 
		0;
createNode animCurveTA -n "animCurveTA1346";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1347";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1345";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 0 130 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1346";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 121 -4.7826738357543945 126 1.406557559967041
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.40606430172920227 0.078168116509914398 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.91384446620941162 0.99694019556045532 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.40606430172920227 0.078168116509914398 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.91384446620941162 0.99694019556045532 
		0;
createNode animCurveTL -n "animCurveTL1347";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 114 -27.000385284423828 117 -31.466835021972656
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.0079446230083703995 0.024683473631739616 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.99996846914291382 0.9996953010559082 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.0079446230083703995 0.024683473631739616 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.99996846914291382 0.9996953010559082 
		0;
createNode animCurveTU -n "animCurveTU1348";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1349";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1350";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 1 130 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1348";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 115 -44.617214202880859 120 31.566934585571289
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.5626753568649292 0.62593162059783936 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.82667797803878784 0.77987796068191528 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.5626753568649292 0.62593162059783936 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.82667797803878784 0.77987796068191528 
		0;
createNode animCurveTA -n "animCurveTA1349";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 115 -5.4443774223327637 120 5.9405221939086914
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.96383863687515259 0.98863911628723145 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.26648640632629395 0.15030844509601593 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.96383863687515259 0.98863911628723145 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.26648640632629395 0.15030844509601593 
		0;
createNode animCurveTA -n "animCurveTA1350";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  111 0 115 4.3227691650390625 120 -27.421512603759766
		 130 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.61676400899887085 0.99279272556304932 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.787148118019104 -0.1198444589972496 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.61676400899887085 0.99279272556304932 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.787148118019104 -0.1198444589972496 
		0;
createNode animCurveTL -n "animCurveTL1348";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 2.0856802463531494 130 2.0856802463531494;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1349";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 -5.0555992126464844 130 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1350";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  111 28.250843048095703 130 28.250843048095703;
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
connectAttr "get_hit_from_leftSource.cl" "clipLibrary1.sc[0]";
connectAttr "animCurveTU1261.a" "clipLibrary1.cel[0].cev[0].cevr";
connectAttr "animCurveTU1262.a" "clipLibrary1.cel[0].cev[1].cevr";
connectAttr "animCurveTU1263.a" "clipLibrary1.cel[0].cev[2].cevr";
connectAttr "animCurveTA1261.a" "clipLibrary1.cel[0].cev[3].cevr";
connectAttr "animCurveTA1262.a" "clipLibrary1.cel[0].cev[4].cevr";
connectAttr "animCurveTA1263.a" "clipLibrary1.cel[0].cev[5].cevr";
connectAttr "animCurveTL1261.a" "clipLibrary1.cel[0].cev[6].cevr";
connectAttr "animCurveTL1262.a" "clipLibrary1.cel[0].cev[7].cevr";
connectAttr "animCurveTL1263.a" "clipLibrary1.cel[0].cev[8].cevr";
connectAttr "animCurveTU1264.a" "clipLibrary1.cel[0].cev[9].cevr";
connectAttr "animCurveTU1265.a" "clipLibrary1.cel[0].cev[10].cevr";
connectAttr "animCurveTU1266.a" "clipLibrary1.cel[0].cev[11].cevr";
connectAttr "animCurveTA1264.a" "clipLibrary1.cel[0].cev[12].cevr";
connectAttr "animCurveTA1265.a" "clipLibrary1.cel[0].cev[13].cevr";
connectAttr "animCurveTA1266.a" "clipLibrary1.cel[0].cev[14].cevr";
connectAttr "animCurveTL1264.a" "clipLibrary1.cel[0].cev[15].cevr";
connectAttr "animCurveTL1265.a" "clipLibrary1.cel[0].cev[16].cevr";
connectAttr "animCurveTL1266.a" "clipLibrary1.cel[0].cev[17].cevr";
connectAttr "animCurveTU1267.a" "clipLibrary1.cel[0].cev[18].cevr";
connectAttr "animCurveTU1268.a" "clipLibrary1.cel[0].cev[19].cevr";
connectAttr "animCurveTU1269.a" "clipLibrary1.cel[0].cev[20].cevr";
connectAttr "animCurveTA1267.a" "clipLibrary1.cel[0].cev[21].cevr";
connectAttr "animCurveTA1268.a" "clipLibrary1.cel[0].cev[22].cevr";
connectAttr "animCurveTA1269.a" "clipLibrary1.cel[0].cev[23].cevr";
connectAttr "animCurveTL1267.a" "clipLibrary1.cel[0].cev[24].cevr";
connectAttr "animCurveTL1268.a" "clipLibrary1.cel[0].cev[25].cevr";
connectAttr "animCurveTL1269.a" "clipLibrary1.cel[0].cev[26].cevr";
connectAttr "animCurveTU1270.a" "clipLibrary1.cel[0].cev[27].cevr";
connectAttr "animCurveTU1271.a" "clipLibrary1.cel[0].cev[28].cevr";
connectAttr "animCurveTU1272.a" "clipLibrary1.cel[0].cev[29].cevr";
connectAttr "animCurveTA1270.a" "clipLibrary1.cel[0].cev[30].cevr";
connectAttr "animCurveTA1271.a" "clipLibrary1.cel[0].cev[31].cevr";
connectAttr "animCurveTA1272.a" "clipLibrary1.cel[0].cev[32].cevr";
connectAttr "animCurveTL1270.a" "clipLibrary1.cel[0].cev[33].cevr";
connectAttr "animCurveTL1271.a" "clipLibrary1.cel[0].cev[34].cevr";
connectAttr "animCurveTL1272.a" "clipLibrary1.cel[0].cev[35].cevr";
connectAttr "animCurveTU1273.a" "clipLibrary1.cel[0].cev[36].cevr";
connectAttr "animCurveTU1274.a" "clipLibrary1.cel[0].cev[37].cevr";
connectAttr "animCurveTU1275.a" "clipLibrary1.cel[0].cev[38].cevr";
connectAttr "animCurveTA1273.a" "clipLibrary1.cel[0].cev[39].cevr";
connectAttr "animCurveTA1274.a" "clipLibrary1.cel[0].cev[40].cevr";
connectAttr "animCurveTA1275.a" "clipLibrary1.cel[0].cev[41].cevr";
connectAttr "animCurveTL1273.a" "clipLibrary1.cel[0].cev[42].cevr";
connectAttr "animCurveTL1274.a" "clipLibrary1.cel[0].cev[43].cevr";
connectAttr "animCurveTL1275.a" "clipLibrary1.cel[0].cev[44].cevr";
connectAttr "animCurveTU1276.a" "clipLibrary1.cel[0].cev[45].cevr";
connectAttr "animCurveTU1277.a" "clipLibrary1.cel[0].cev[46].cevr";
connectAttr "animCurveTU1278.a" "clipLibrary1.cel[0].cev[47].cevr";
connectAttr "animCurveTA1276.a" "clipLibrary1.cel[0].cev[48].cevr";
connectAttr "animCurveTA1277.a" "clipLibrary1.cel[0].cev[49].cevr";
connectAttr "animCurveTA1278.a" "clipLibrary1.cel[0].cev[50].cevr";
connectAttr "animCurveTL1276.a" "clipLibrary1.cel[0].cev[51].cevr";
connectAttr "animCurveTL1277.a" "clipLibrary1.cel[0].cev[52].cevr";
connectAttr "animCurveTL1278.a" "clipLibrary1.cel[0].cev[53].cevr";
connectAttr "animCurveTU1279.a" "clipLibrary1.cel[0].cev[54].cevr";
connectAttr "animCurveTU1280.a" "clipLibrary1.cel[0].cev[55].cevr";
connectAttr "animCurveTU1281.a" "clipLibrary1.cel[0].cev[56].cevr";
connectAttr "animCurveTA1279.a" "clipLibrary1.cel[0].cev[57].cevr";
connectAttr "animCurveTA1280.a" "clipLibrary1.cel[0].cev[58].cevr";
connectAttr "animCurveTA1281.a" "clipLibrary1.cel[0].cev[59].cevr";
connectAttr "animCurveTL1279.a" "clipLibrary1.cel[0].cev[60].cevr";
connectAttr "animCurveTL1280.a" "clipLibrary1.cel[0].cev[61].cevr";
connectAttr "animCurveTL1281.a" "clipLibrary1.cel[0].cev[62].cevr";
connectAttr "animCurveTU1282.a" "clipLibrary1.cel[0].cev[63].cevr";
connectAttr "animCurveTU1283.a" "clipLibrary1.cel[0].cev[64].cevr";
connectAttr "animCurveTU1284.a" "clipLibrary1.cel[0].cev[65].cevr";
connectAttr "animCurveTA1282.a" "clipLibrary1.cel[0].cev[66].cevr";
connectAttr "animCurveTA1283.a" "clipLibrary1.cel[0].cev[67].cevr";
connectAttr "animCurveTA1284.a" "clipLibrary1.cel[0].cev[68].cevr";
connectAttr "animCurveTL1282.a" "clipLibrary1.cel[0].cev[69].cevr";
connectAttr "animCurveTL1283.a" "clipLibrary1.cel[0].cev[70].cevr";
connectAttr "animCurveTL1284.a" "clipLibrary1.cel[0].cev[71].cevr";
connectAttr "animCurveTU1285.a" "clipLibrary1.cel[0].cev[72].cevr";
connectAttr "animCurveTU1286.a" "clipLibrary1.cel[0].cev[73].cevr";
connectAttr "animCurveTU1287.a" "clipLibrary1.cel[0].cev[74].cevr";
connectAttr "animCurveTA1285.a" "clipLibrary1.cel[0].cev[75].cevr";
connectAttr "animCurveTA1286.a" "clipLibrary1.cel[0].cev[76].cevr";
connectAttr "animCurveTA1287.a" "clipLibrary1.cel[0].cev[77].cevr";
connectAttr "animCurveTL1285.a" "clipLibrary1.cel[0].cev[78].cevr";
connectAttr "animCurveTL1286.a" "clipLibrary1.cel[0].cev[79].cevr";
connectAttr "animCurveTL1287.a" "clipLibrary1.cel[0].cev[80].cevr";
connectAttr "animCurveTU1288.a" "clipLibrary1.cel[0].cev[81].cevr";
connectAttr "animCurveTU1289.a" "clipLibrary1.cel[0].cev[82].cevr";
connectAttr "animCurveTU1290.a" "clipLibrary1.cel[0].cev[83].cevr";
connectAttr "animCurveTA1288.a" "clipLibrary1.cel[0].cev[84].cevr";
connectAttr "animCurveTA1289.a" "clipLibrary1.cel[0].cev[85].cevr";
connectAttr "animCurveTA1290.a" "clipLibrary1.cel[0].cev[86].cevr";
connectAttr "animCurveTL1288.a" "clipLibrary1.cel[0].cev[87].cevr";
connectAttr "animCurveTL1289.a" "clipLibrary1.cel[0].cev[88].cevr";
connectAttr "animCurveTL1290.a" "clipLibrary1.cel[0].cev[89].cevr";
connectAttr "animCurveTU1291.a" "clipLibrary1.cel[0].cev[90].cevr";
connectAttr "animCurveTU1292.a" "clipLibrary1.cel[0].cev[91].cevr";
connectAttr "animCurveTU1293.a" "clipLibrary1.cel[0].cev[92].cevr";
connectAttr "animCurveTA1291.a" "clipLibrary1.cel[0].cev[93].cevr";
connectAttr "animCurveTA1292.a" "clipLibrary1.cel[0].cev[94].cevr";
connectAttr "animCurveTA1293.a" "clipLibrary1.cel[0].cev[95].cevr";
connectAttr "animCurveTL1291.a" "clipLibrary1.cel[0].cev[96].cevr";
connectAttr "animCurveTL1292.a" "clipLibrary1.cel[0].cev[97].cevr";
connectAttr "animCurveTL1293.a" "clipLibrary1.cel[0].cev[98].cevr";
connectAttr "animCurveTU1294.a" "clipLibrary1.cel[0].cev[99].cevr";
connectAttr "animCurveTU1295.a" "clipLibrary1.cel[0].cev[100].cevr";
connectAttr "animCurveTU1296.a" "clipLibrary1.cel[0].cev[101].cevr";
connectAttr "animCurveTA1294.a" "clipLibrary1.cel[0].cev[102].cevr";
connectAttr "animCurveTA1295.a" "clipLibrary1.cel[0].cev[103].cevr";
connectAttr "animCurveTA1296.a" "clipLibrary1.cel[0].cev[104].cevr";
connectAttr "animCurveTL1294.a" "clipLibrary1.cel[0].cev[105].cevr";
connectAttr "animCurveTL1295.a" "clipLibrary1.cel[0].cev[106].cevr";
connectAttr "animCurveTL1296.a" "clipLibrary1.cel[0].cev[107].cevr";
connectAttr "animCurveTU1297.a" "clipLibrary1.cel[0].cev[108].cevr";
connectAttr "animCurveTU1298.a" "clipLibrary1.cel[0].cev[109].cevr";
connectAttr "animCurveTU1299.a" "clipLibrary1.cel[0].cev[110].cevr";
connectAttr "animCurveTA1297.a" "clipLibrary1.cel[0].cev[111].cevr";
connectAttr "animCurveTA1298.a" "clipLibrary1.cel[0].cev[112].cevr";
connectAttr "animCurveTA1299.a" "clipLibrary1.cel[0].cev[113].cevr";
connectAttr "animCurveTL1297.a" "clipLibrary1.cel[0].cev[114].cevr";
connectAttr "animCurveTL1298.a" "clipLibrary1.cel[0].cev[115].cevr";
connectAttr "animCurveTL1299.a" "clipLibrary1.cel[0].cev[116].cevr";
connectAttr "animCurveTU1300.a" "clipLibrary1.cel[0].cev[117].cevr";
connectAttr "animCurveTU1301.a" "clipLibrary1.cel[0].cev[118].cevr";
connectAttr "animCurveTU1302.a" "clipLibrary1.cel[0].cev[119].cevr";
connectAttr "animCurveTA1300.a" "clipLibrary1.cel[0].cev[120].cevr";
connectAttr "animCurveTA1301.a" "clipLibrary1.cel[0].cev[121].cevr";
connectAttr "animCurveTA1302.a" "clipLibrary1.cel[0].cev[122].cevr";
connectAttr "animCurveTL1300.a" "clipLibrary1.cel[0].cev[123].cevr";
connectAttr "animCurveTL1301.a" "clipLibrary1.cel[0].cev[124].cevr";
connectAttr "animCurveTL1302.a" "clipLibrary1.cel[0].cev[125].cevr";
connectAttr "animCurveTU1303.a" "clipLibrary1.cel[0].cev[126].cevr";
connectAttr "animCurveTU1304.a" "clipLibrary1.cel[0].cev[127].cevr";
connectAttr "animCurveTU1305.a" "clipLibrary1.cel[0].cev[128].cevr";
connectAttr "animCurveTA1303.a" "clipLibrary1.cel[0].cev[129].cevr";
connectAttr "animCurveTA1304.a" "clipLibrary1.cel[0].cev[130].cevr";
connectAttr "animCurveTA1305.a" "clipLibrary1.cel[0].cev[131].cevr";
connectAttr "animCurveTL1303.a" "clipLibrary1.cel[0].cev[132].cevr";
connectAttr "animCurveTL1304.a" "clipLibrary1.cel[0].cev[133].cevr";
connectAttr "animCurveTL1305.a" "clipLibrary1.cel[0].cev[134].cevr";
connectAttr "animCurveTU1306.a" "clipLibrary1.cel[0].cev[135].cevr";
connectAttr "animCurveTU1307.a" "clipLibrary1.cel[0].cev[136].cevr";
connectAttr "animCurveTU1308.a" "clipLibrary1.cel[0].cev[137].cevr";
connectAttr "animCurveTA1306.a" "clipLibrary1.cel[0].cev[138].cevr";
connectAttr "animCurveTA1307.a" "clipLibrary1.cel[0].cev[139].cevr";
connectAttr "animCurveTA1308.a" "clipLibrary1.cel[0].cev[140].cevr";
connectAttr "animCurveTL1306.a" "clipLibrary1.cel[0].cev[141].cevr";
connectAttr "animCurveTL1307.a" "clipLibrary1.cel[0].cev[142].cevr";
connectAttr "animCurveTL1308.a" "clipLibrary1.cel[0].cev[143].cevr";
connectAttr "animCurveTU1309.a" "clipLibrary1.cel[0].cev[144].cevr";
connectAttr "animCurveTU1310.a" "clipLibrary1.cel[0].cev[145].cevr";
connectAttr "animCurveTU1311.a" "clipLibrary1.cel[0].cev[146].cevr";
connectAttr "animCurveTA1309.a" "clipLibrary1.cel[0].cev[147].cevr";
connectAttr "animCurveTA1310.a" "clipLibrary1.cel[0].cev[148].cevr";
connectAttr "animCurveTA1311.a" "clipLibrary1.cel[0].cev[149].cevr";
connectAttr "animCurveTL1309.a" "clipLibrary1.cel[0].cev[150].cevr";
connectAttr "animCurveTL1310.a" "clipLibrary1.cel[0].cev[151].cevr";
connectAttr "animCurveTL1311.a" "clipLibrary1.cel[0].cev[152].cevr";
connectAttr "animCurveTU1312.a" "clipLibrary1.cel[0].cev[153].cevr";
connectAttr "animCurveTU1313.a" "clipLibrary1.cel[0].cev[154].cevr";
connectAttr "animCurveTU1314.a" "clipLibrary1.cel[0].cev[155].cevr";
connectAttr "animCurveTA1312.a" "clipLibrary1.cel[0].cev[156].cevr";
connectAttr "animCurveTA1313.a" "clipLibrary1.cel[0].cev[157].cevr";
connectAttr "animCurveTA1314.a" "clipLibrary1.cel[0].cev[158].cevr";
connectAttr "animCurveTL1312.a" "clipLibrary1.cel[0].cev[159].cevr";
connectAttr "animCurveTL1313.a" "clipLibrary1.cel[0].cev[160].cevr";
connectAttr "animCurveTL1314.a" "clipLibrary1.cel[0].cev[161].cevr";
connectAttr "animCurveTU1315.a" "clipLibrary1.cel[0].cev[162].cevr";
connectAttr "animCurveTU1316.a" "clipLibrary1.cel[0].cev[163].cevr";
connectAttr "animCurveTU1317.a" "clipLibrary1.cel[0].cev[164].cevr";
connectAttr "animCurveTA1315.a" "clipLibrary1.cel[0].cev[165].cevr";
connectAttr "animCurveTA1316.a" "clipLibrary1.cel[0].cev[166].cevr";
connectAttr "animCurveTA1317.a" "clipLibrary1.cel[0].cev[167].cevr";
connectAttr "animCurveTL1315.a" "clipLibrary1.cel[0].cev[168].cevr";
connectAttr "animCurveTL1316.a" "clipLibrary1.cel[0].cev[169].cevr";
connectAttr "animCurveTL1317.a" "clipLibrary1.cel[0].cev[170].cevr";
connectAttr "animCurveTU1318.a" "clipLibrary1.cel[0].cev[171].cevr";
connectAttr "animCurveTU1319.a" "clipLibrary1.cel[0].cev[172].cevr";
connectAttr "animCurveTU1320.a" "clipLibrary1.cel[0].cev[173].cevr";
connectAttr "animCurveTA1318.a" "clipLibrary1.cel[0].cev[174].cevr";
connectAttr "animCurveTA1319.a" "clipLibrary1.cel[0].cev[175].cevr";
connectAttr "animCurveTA1320.a" "clipLibrary1.cel[0].cev[176].cevr";
connectAttr "animCurveTL1318.a" "clipLibrary1.cel[0].cev[177].cevr";
connectAttr "animCurveTL1319.a" "clipLibrary1.cel[0].cev[178].cevr";
connectAttr "animCurveTL1320.a" "clipLibrary1.cel[0].cev[179].cevr";
connectAttr "animCurveTU1321.a" "clipLibrary1.cel[0].cev[180].cevr";
connectAttr "animCurveTU1322.a" "clipLibrary1.cel[0].cev[181].cevr";
connectAttr "animCurveTU1323.a" "clipLibrary1.cel[0].cev[182].cevr";
connectAttr "animCurveTA1321.a" "clipLibrary1.cel[0].cev[183].cevr";
connectAttr "animCurveTA1322.a" "clipLibrary1.cel[0].cev[184].cevr";
connectAttr "animCurveTA1323.a" "clipLibrary1.cel[0].cev[185].cevr";
connectAttr "animCurveTL1321.a" "clipLibrary1.cel[0].cev[186].cevr";
connectAttr "animCurveTL1322.a" "clipLibrary1.cel[0].cev[187].cevr";
connectAttr "animCurveTL1323.a" "clipLibrary1.cel[0].cev[188].cevr";
connectAttr "animCurveTU1324.a" "clipLibrary1.cel[0].cev[189].cevr";
connectAttr "animCurveTU1325.a" "clipLibrary1.cel[0].cev[190].cevr";
connectAttr "animCurveTU1326.a" "clipLibrary1.cel[0].cev[191].cevr";
connectAttr "animCurveTA1324.a" "clipLibrary1.cel[0].cev[192].cevr";
connectAttr "animCurveTA1325.a" "clipLibrary1.cel[0].cev[193].cevr";
connectAttr "animCurveTA1326.a" "clipLibrary1.cel[0].cev[194].cevr";
connectAttr "animCurveTL1324.a" "clipLibrary1.cel[0].cev[195].cevr";
connectAttr "animCurveTL1325.a" "clipLibrary1.cel[0].cev[196].cevr";
connectAttr "animCurveTL1326.a" "clipLibrary1.cel[0].cev[197].cevr";
connectAttr "animCurveTU1327.a" "clipLibrary1.cel[0].cev[198].cevr";
connectAttr "animCurveTU1328.a" "clipLibrary1.cel[0].cev[199].cevr";
connectAttr "animCurveTU1329.a" "clipLibrary1.cel[0].cev[200].cevr";
connectAttr "animCurveTA1327.a" "clipLibrary1.cel[0].cev[201].cevr";
connectAttr "animCurveTA1328.a" "clipLibrary1.cel[0].cev[202].cevr";
connectAttr "animCurveTA1329.a" "clipLibrary1.cel[0].cev[203].cevr";
connectAttr "animCurveTL1327.a" "clipLibrary1.cel[0].cev[204].cevr";
connectAttr "animCurveTL1328.a" "clipLibrary1.cel[0].cev[205].cevr";
connectAttr "animCurveTL1329.a" "clipLibrary1.cel[0].cev[206].cevr";
connectAttr "animCurveTU1330.a" "clipLibrary1.cel[0].cev[207].cevr";
connectAttr "animCurveTU1331.a" "clipLibrary1.cel[0].cev[208].cevr";
connectAttr "animCurveTU1332.a" "clipLibrary1.cel[0].cev[209].cevr";
connectAttr "animCurveTA1330.a" "clipLibrary1.cel[0].cev[210].cevr";
connectAttr "animCurveTA1331.a" "clipLibrary1.cel[0].cev[211].cevr";
connectAttr "animCurveTA1332.a" "clipLibrary1.cel[0].cev[212].cevr";
connectAttr "animCurveTL1330.a" "clipLibrary1.cel[0].cev[213].cevr";
connectAttr "animCurveTL1331.a" "clipLibrary1.cel[0].cev[214].cevr";
connectAttr "animCurveTL1332.a" "clipLibrary1.cel[0].cev[215].cevr";
connectAttr "animCurveTU1333.a" "clipLibrary1.cel[0].cev[216].cevr";
connectAttr "animCurveTU1334.a" "clipLibrary1.cel[0].cev[217].cevr";
connectAttr "animCurveTU1335.a" "clipLibrary1.cel[0].cev[218].cevr";
connectAttr "animCurveTA1333.a" "clipLibrary1.cel[0].cev[219].cevr";
connectAttr "animCurveTA1334.a" "clipLibrary1.cel[0].cev[220].cevr";
connectAttr "animCurveTA1335.a" "clipLibrary1.cel[0].cev[221].cevr";
connectAttr "animCurveTL1333.a" "clipLibrary1.cel[0].cev[222].cevr";
connectAttr "animCurveTL1334.a" "clipLibrary1.cel[0].cev[223].cevr";
connectAttr "animCurveTL1335.a" "clipLibrary1.cel[0].cev[224].cevr";
connectAttr "animCurveTU1336.a" "clipLibrary1.cel[0].cev[225].cevr";
connectAttr "animCurveTU1337.a" "clipLibrary1.cel[0].cev[226].cevr";
connectAttr "animCurveTU1338.a" "clipLibrary1.cel[0].cev[227].cevr";
connectAttr "animCurveTA1336.a" "clipLibrary1.cel[0].cev[228].cevr";
connectAttr "animCurveTA1337.a" "clipLibrary1.cel[0].cev[229].cevr";
connectAttr "animCurveTA1338.a" "clipLibrary1.cel[0].cev[230].cevr";
connectAttr "animCurveTL1336.a" "clipLibrary1.cel[0].cev[231].cevr";
connectAttr "animCurveTL1337.a" "clipLibrary1.cel[0].cev[232].cevr";
connectAttr "animCurveTL1338.a" "clipLibrary1.cel[0].cev[233].cevr";
connectAttr "animCurveTU1339.a" "clipLibrary1.cel[0].cev[234].cevr";
connectAttr "animCurveTU1340.a" "clipLibrary1.cel[0].cev[235].cevr";
connectAttr "animCurveTU1341.a" "clipLibrary1.cel[0].cev[236].cevr";
connectAttr "animCurveTA1339.a" "clipLibrary1.cel[0].cev[237].cevr";
connectAttr "animCurveTA1340.a" "clipLibrary1.cel[0].cev[238].cevr";
connectAttr "animCurveTA1341.a" "clipLibrary1.cel[0].cev[239].cevr";
connectAttr "animCurveTL1339.a" "clipLibrary1.cel[0].cev[240].cevr";
connectAttr "animCurveTL1340.a" "clipLibrary1.cel[0].cev[241].cevr";
connectAttr "animCurveTL1341.a" "clipLibrary1.cel[0].cev[242].cevr";
connectAttr "animCurveTU1342.a" "clipLibrary1.cel[0].cev[243].cevr";
connectAttr "animCurveTU1343.a" "clipLibrary1.cel[0].cev[244].cevr";
connectAttr "animCurveTU1344.a" "clipLibrary1.cel[0].cev[245].cevr";
connectAttr "animCurveTA1342.a" "clipLibrary1.cel[0].cev[246].cevr";
connectAttr "animCurveTA1343.a" "clipLibrary1.cel[0].cev[247].cevr";
connectAttr "animCurveTA1344.a" "clipLibrary1.cel[0].cev[248].cevr";
connectAttr "animCurveTL1342.a" "clipLibrary1.cel[0].cev[249].cevr";
connectAttr "animCurveTL1343.a" "clipLibrary1.cel[0].cev[250].cevr";
connectAttr "animCurveTL1344.a" "clipLibrary1.cel[0].cev[251].cevr";
connectAttr "animCurveTU1345.a" "clipLibrary1.cel[0].cev[252].cevr";
connectAttr "animCurveTU1346.a" "clipLibrary1.cel[0].cev[253].cevr";
connectAttr "animCurveTU1347.a" "clipLibrary1.cel[0].cev[254].cevr";
connectAttr "animCurveTA1345.a" "clipLibrary1.cel[0].cev[255].cevr";
connectAttr "animCurveTA1346.a" "clipLibrary1.cel[0].cev[256].cevr";
connectAttr "animCurveTA1347.a" "clipLibrary1.cel[0].cev[257].cevr";
connectAttr "animCurveTL1345.a" "clipLibrary1.cel[0].cev[258].cevr";
connectAttr "animCurveTL1346.a" "clipLibrary1.cel[0].cev[259].cevr";
connectAttr "animCurveTL1347.a" "clipLibrary1.cel[0].cev[260].cevr";
connectAttr "animCurveTU1348.a" "clipLibrary1.cel[0].cev[261].cevr";
connectAttr "animCurveTU1349.a" "clipLibrary1.cel[0].cev[262].cevr";
connectAttr "animCurveTU1350.a" "clipLibrary1.cel[0].cev[263].cevr";
connectAttr "animCurveTA1348.a" "clipLibrary1.cel[0].cev[264].cevr";
connectAttr "animCurveTA1349.a" "clipLibrary1.cel[0].cev[265].cevr";
connectAttr "animCurveTA1350.a" "clipLibrary1.cel[0].cev[266].cevr";
connectAttr "animCurveTL1348.a" "clipLibrary1.cel[0].cev[267].cevr";
connectAttr "animCurveTL1349.a" "clipLibrary1.cel[0].cev[268].cevr";
connectAttr "animCurveTL1350.a" "clipLibrary1.cel[0].cev[269].cevr";
// End of bat_get_hit_from_left.ma
