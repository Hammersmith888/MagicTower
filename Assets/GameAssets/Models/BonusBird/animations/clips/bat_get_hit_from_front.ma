//Maya ASCII 2013 scene
//Name: bat_get_hit_from_front.ma
//Last modified: Sat, Jul 12, 2014 02:46:34 PM
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
createNode animClip -n "get_hit_from_frontSource";
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
	setAttr ".ss" 91;
	setAttr ".se" 110;
	setAttr ".ci" no;
createNode animCurveTU -n "animCurveTU901";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU902";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU903";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA901";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 93 -6.674738883972168 97 67.780532836914062
		 104 5.1502742767333984 107 8.1900339126586914 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.73155277967453003 0.20676158368587494 
		0.91182070970535278 0.99858146905899048 0.99990898370742798 1;
	setAttr -s 6 ".kiy[0:5]"  -0.68178474903106689 0.97839140892028809 
		0.41058862209320068 -0.053245261311531067 0.013491630554199219 0;
	setAttr -s 6 ".kox[0:5]"  0.73155277967453003 0.20676158368587494 
		0.91182070970535278 0.99990910291671753 0.99934083223342896 1;
	setAttr -s 6 ".koy[0:5]"  -0.68178474903106689 0.97839140892028809 
		0.41058862209320068 0.013482022099196911 -0.036304004490375519 0;
createNode animCurveTA -n "animCurveTA902";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 93 -3.2280733585357666 97 51.456279754638672
		 104 39.405513763427734 107 24.528476715087891 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.91167432069778442 0.26817429065704346 
		0.5244525671005249 0.58012449741363525 0.24749042093753815 1;
	setAttr -s 6 ".kiy[0:5]"  -0.41091355681419373 0.96337038278579712 
		0.8514397144317627 -0.81452775001525879 -0.96889030933380127 0;
	setAttr -s 6 ".kox[0:5]"  0.91167432069778442 0.26817429065704346 
		0.5244525671005249 0.58296430110931396 0.24419912695884705 1;
	setAttr -s 6 ".koy[0:5]"  -0.41091355681419373 0.96337038278579712 
		0.8514397144317627 -0.81249773502349854 -0.96972507238388062 0;
createNode animCurveTA -n "animCurveTA903";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 93 -52.922073364257812 97 -16.965888977050781
		 104 -20.634910583496094 107 6.866361141204834 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.1341080516576767 0.64510661363601685 
		0.63098710775375366 0.99996298551559448 0.99263137578964233 1;
	setAttr -s 6 ".kiy[0:5]"  -0.99096673727035522 -0.76409256458282471 
		0.77579331398010254 -0.0086012491956353188 0.12117289006710052 0;
	setAttr -s 6 ".kox[0:5]"  0.1341080516576767 0.64510661363601685 
		0.63098710775375366 0.99264180660247803 0.99953651428222656 1;
	setAttr -s 6 ".koy[0:5]"  -0.99096673727035522 -0.76409256458282471 
		0.77579331398010254 0.12108781933784485 -0.030442517250776291 0;
createNode animCurveTL -n "animCurveTL901";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -5.7247552871704102 110 -5.7247552871704102;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL902";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 12.644636154174805 110 12.644636154174805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL903";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 43.253993988037109 110 43.253993988037109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU904";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU905";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU906";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA904";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA905";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA906";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL904";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -1.9167585372924805 110 -1.9167585372924805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL905";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -5.0555992126464844 110 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL906";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 28.262805938720703 110 28.262805938720703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU907";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU908";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU909";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA907";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 93 -2.7844502925872803 98 22.303333282470703
		 102 -9.3010120391845703 107 5.8757166862487793 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.93203812837600708 0.59962737560272217 
		0.95695418119430542 0.99707990884780884 0.99970436096191406 1;
	setAttr -s 6 ".kiy[0:5]"  -0.36236026883125305 0.80027931928634644 
		-0.29023900628089905 -0.076365247368812561 0.024314152076840401 0;
	setAttr -s 6 ".kox[0:5]"  0.93203812837600708 0.59962737560272217 
		0.95695418119430542 0.99970483779907227 0.99966055154800415 1;
	setAttr -s 6 ".koy[0:5]"  -0.36236026883125305 0.80027931928634644 
		-0.29023900628089905 0.02429681271314621 -0.026053657755255699 0;
createNode animCurveTA -n "animCurveTA908";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 93 4.5514512062072754 98 -53.772708892822266
		 102 -54.802555084228516 107 -18.545572280883789 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.84399062395095825 0.29677495360374451 
		0.34038046002388 0.99981296062469482 0.22892510890960693 1;
	setAttr -s 6 ".kiy[0:5]"  0.53635799884796143 -0.95494747161865234 
		-0.94028776884078979 0.019342012703418732 0.97344404458999634 0;
	setAttr -s 6 ".kox[0:5]"  0.84399062395095825 0.29677495360374451 
		0.34038046002388 0.99951803684234619 0.22960299253463745 1;
	setAttr -s 6 ".koy[0:5]"  0.53635799884796143 -0.95494747161865234 
		-0.94028776884078979 0.031043073162436485 0.97328436374664307 0;
createNode animCurveTA -n "animCurveTA909";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 93 41.259292602539062 98 44.330841064453125
		 102 31.953889846801754 107 3.0130627155303955 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.17102693021297455 0.35273674130439758 
		0.91763603687286377 0.3436037003993988 0.61706805229187012 1;
	setAttr -s 6 ".kiy[0:5]"  0.98526632785797119 0.93572264909744263 
		-0.39742189645767212 -0.93911474943161011 -0.78690981864929199 0;
	setAttr -s 6 ".kox[0:5]"  0.17102693021297455 0.35273674130439758 
		0.91763603687286377 0.34144824743270874 0.62512052059173584 1;
	setAttr -s 6 ".koy[0:5]"  0.98526632785797119 0.93572264909744263 
		-0.39742189645767212 -0.93990057706832886 -0.78052824735641479 0;
createNode animCurveTL -n "animCurveTL907";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -5.7247552871704102 110 -5.7247552871704102;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL908";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 12.644636154174805 110 12.644636154174805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL909";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -43.253993988037109 110 -43.253993988037109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU910";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU911";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU912";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA910";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 0.0048254411667585373 92 0 93 0 110 0.0048254411667585373;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.99999946355819702 0.99999946355819702 
		1 1;
	setAttr -s 4 ".kiy[0:3]"  -0.0010106385452672839 -0.0010106385452672839 
		0.00011229310621274635 0;
	setAttr -s 4 ".kox[0:3]"  0.99999946355819702 0.99999946355819702 
		1 1;
	setAttr -s 4 ".koy[0:3]"  -0.0010106385452672839 -0.0010106385452672839 
		0.00011229310621274635 0;
createNode animCurveTA -n "animCurveTA911";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 1.5292341709136963 92 0 93 0 110 1.5292341709136963;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.95234602689743042 0.95234602689743042 
		0.99936741590499878 1;
	setAttr -s 4 ".kiy[0:3]"  -0.30501961708068848 -0.30501961708068848 
		0.0355643630027771 0;
	setAttr -s 4 ".kox[0:3]"  0.95234602689743042 0.95234602689743042 
		0.99936741590499878 1;
	setAttr -s 4 ".koy[0:3]"  -0.30501961708068848 -0.30501961708068848 
		0.0355643630027771 0;
createNode animCurveTA -n "animCurveTA912";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 1.0246820449829102 92 0 93 0 95 25.055164337158203
		 100 -9.0873785018920898 110 1.0246820449829102;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.97773760557174683 0.97773760557174683 
		0.27484014630317688 0.87851035594940186 0.83036375045776367 1;
	setAttr -s 6 ".kiy[0:5]"  -0.20983138680458069 -0.20983138680458069 
		0.9614899754524231 -0.47772327065467834 -0.55722182989120483 0;
	setAttr -s 6 ".kox[0:5]"  0.97773760557174683 0.97773760557174683 
		0.27484014630317688 0.87851035594940186 0.83036375045776367 1;
	setAttr -s 6 ".koy[0:5]"  -0.20983138680458069 -0.20983138680458069 
		0.9614899754524231 -0.47772327065467834 -0.55722182989120483 0;
createNode animCurveTL -n "animCurveTL910";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -0.72905689477920532 93 -1.1657956838607788
		 100 -17.691616058349609 110 -0.72905689477920532;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.27516376972198486 0.022102098912000656 
		0.85120683908462524 1;
	setAttr -s 4 ".kiy[0:3]"  -0.96139740943908691 -0.99975574016571045 
		0.52483046054840088 0;
	setAttr -s 4 ".kox[0:3]"  0.27516376972198486 0.022102098912000656 
		0.85120683908462524 1;
	setAttr -s 4 ".koy[0:3]"  -0.96139740943908691 -0.99975574016571045 
		0.52483046054840088 0;
createNode animCurveTL -n "animCurveTL911";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -19.141372680664063 93 -19.400392532348633
		 100 -10.145771026611328 110 -19.141372680664063;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.43462327122688293 0.041650839149951935 
		0.93917649984359741 1;
	setAttr -s 4 ".kiy[0:3]"  -0.90061235427856445 0.99913221597671509 
		0.34343487024307251 0;
	setAttr -s 4 ".kox[0:3]"  0.43462327122688293 0.041650839149951935 
		0.93917649984359741 1;
	setAttr -s 4 ".koy[0:3]"  -0.90061235427856445 0.99913221597671509 
		0.34343487024307251 0;
createNode animCurveTL -n "animCurveTL912";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 23.549764633178711 93 23.549764633178711
		 100 25.138574600219727 110 23.549764633178711;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  1 0.22971373796463013 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0.97325819730758667 0 0;
	setAttr -s 4 ".kox[0:3]"  1 0.22971373796463013 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0.97325819730758667 0 0;
createNode animCurveTU -n "animCurveTU913";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU914";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU915";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA913";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 0 96 20.177358627319336 110 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99947834014892578 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.032295204699039459 0;
	setAttr -s 3 ".kox[0:2]"  0.99947834014892578 0.99999147653579712 
		1;
	setAttr -s 3 ".koy[0:2]"  0.032295204699039459 -0.0041327476501464844 
		0;
createNode animCurveTA -n "animCurveTA914";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 0 96 -5.368046760559082 110 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99996310472488403 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.0085960831493139267 0;
	setAttr -s 3 ".kox[0:2]"  0.99996310472488403 0.99999934434890747 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.0085960831493139267 0.0010994977783411741 
		0;
createNode animCurveTA -n "animCurveTA915";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 12.527528762817383 96 20.434331893920898
		 110 12.527528762817383;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99991989135742188 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.01266095694154501 0;
	setAttr -s 3 ".kox[0:2]"  0.99991989135742188 0.99999868869781494 
		1;
	setAttr -s 3 ".koy[0:2]"  0.01266095694154501 -0.0016194919589906931 
		0;
createNode animCurveTL -n "animCurveTL913";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -36.1805419921875 110 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL914";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 7.3658723831176758 96 15.867499351501465
		 110 7.3658723831176758;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.024497754871845245 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.99969983100891113 0;
	setAttr -s 3 ".kox[0:2]"  0.8870011568069458 0.068453386425971985 
		1;
	setAttr -s 3 ".koy[0:2]"  0.46176722645759583 -0.99765431880950928 
		0;
createNode animCurveTL -n "animCurveTL915";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 41.597393035888672 110 41.597393035888672;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU916";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU917";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU918";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA916";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 0.0048254411667585373 92 0 93 0 110 0.0048254411667585373;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.99999946355819702 0.99999946355819702 
		1 1;
	setAttr -s 4 ".kiy[0:3]"  -0.0010106385452672839 -0.0010106385452672839 
		0.00011229310621274635 0;
	setAttr -s 4 ".kox[0:3]"  0.99999946355819702 0.99999946355819702 
		1 1;
	setAttr -s 4 ".koy[0:3]"  -0.0010106385452672839 -0.0010106385452672839 
		0.00011229310621274635 0;
createNode animCurveTA -n "animCurveTA917";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 1.5292341709136963 92 0 93 0 110 1.5292341709136963;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.95234602689743042 0.95234602689743042 
		0.99936741590499878 1;
	setAttr -s 4 ".kiy[0:3]"  -0.30501961708068848 -0.30501961708068848 
		0.0355643630027771 0;
	setAttr -s 4 ".kox[0:3]"  0.95234602689743042 0.95234602689743042 
		0.99936741590499878 1;
	setAttr -s 4 ".koy[0:3]"  -0.30501961708068848 -0.30501961708068848 
		0.0355643630027771 0;
createNode animCurveTA -n "animCurveTA918";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 1.0246820449829102 92 0 93 0 95 25.055164337158203
		 100 -9.0873785018920898 110 1.0246820449829102;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.97773760557174683 0.97773760557174683 
		0.27484014630317688 0.87851035594940186 0.83036375045776367 1;
	setAttr -s 6 ".kiy[0:5]"  -0.20983138680458069 -0.20983138680458069 
		0.9614899754524231 -0.47772327065467834 -0.55722182989120483 0;
	setAttr -s 6 ".kox[0:5]"  0.97773760557174683 0.97773760557174683 
		0.27484014630317688 0.87851035594940186 0.83036375045776367 1;
	setAttr -s 6 ".koy[0:5]"  -0.20983138680458069 -0.20983138680458069 
		0.9614899754524231 -0.47772327065467834 -0.55722182989120483 0;
createNode animCurveTL -n "animCurveTL916";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -0.11375267058610916 93 -0.55049139261245728
		 100 -17.076311111450195 110 -0.11375267058610916;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.27516376972198486 0.022102098912000656 
		0.85120683908462524 1;
	setAttr -s 4 ".kiy[0:3]"  -0.96139740943908691 -0.99975574016571045 
		0.52483046054840088 0;
	setAttr -s 4 ".kox[0:3]"  0.27516376972198486 0.022102098912000656 
		0.85120683908462524 1;
	setAttr -s 4 ".koy[0:3]"  -0.96139740943908691 -0.99975574016571045 
		0.52483046054840088 0;
createNode animCurveTL -n "animCurveTL917";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -0.067464433610439301 93 -0.32648545503616333
		 100 8.9281368255615234 110 -0.067464433610439301;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.43462327122688293 0.041650839149951935 
		0.93917649984359741 1;
	setAttr -s 4 ".kiy[0:3]"  -0.90061235427856445 0.99913221597671509 
		0.34343487024307251 0;
	setAttr -s 4 ".kox[0:3]"  0.43462327122688293 0.041650839149951935 
		0.93917649984359741 1;
	setAttr -s 4 ".koy[0:3]"  -0.90061235427856445 0.99913221597671509 
		0.34343487024307251 0;
createNode animCurveTL -n "animCurveTL918";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 41.135360717773437 93 41.135360717773437
		 100 42.724170684814453 110 41.135360717773437;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  1 0.22971373796463013 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0.97325819730758667 0 0;
	setAttr -s 4 ".kox[0:3]"  1 0.22971373796463013 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0.97325819730758667 0 0;
createNode animCurveTU -n "animCurveTU919";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU920";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU921";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA919";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 0 96 42.496311187744141 110 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA920";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA921";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 12.527528762817383 110 12.527528762817383;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL919";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -54.695327758789062 110 -54.695327758789062;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL920";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 3.2521772384643555 96 14.484033584594727
		 110 3.2521772384643555;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL921";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU922";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU923";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU924";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA922";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 0.0048254411667585373 92 0 93 0 110 0.0048254411667585373;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.99999946355819702 0.99999946355819702 
		1 1;
	setAttr -s 4 ".kiy[0:3]"  -0.0010106385452672839 -0.0010106385452672839 
		0.00011229310621274635 0;
	setAttr -s 4 ".kox[0:3]"  0.99999946355819702 0.99999946355819702 
		1 1;
	setAttr -s 4 ".koy[0:3]"  -0.0010106385452672839 -0.0010106385452672839 
		0.00011229310621274635 0;
createNode animCurveTA -n "animCurveTA923";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 1.5292341709136963 92 0 93 0 110 1.5292341709136963;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.95234602689743042 0.95234602689743042 
		0.99936741590499878 1;
	setAttr -s 4 ".kiy[0:3]"  -0.30501961708068848 -0.30501961708068848 
		0.0355643630027771 0;
	setAttr -s 4 ".kox[0:3]"  0.95234602689743042 0.95234602689743042 
		0.99936741590499878 1;
	setAttr -s 4 ".koy[0:3]"  -0.30501961708068848 -0.30501961708068848 
		0.0355643630027771 0;
createNode animCurveTA -n "animCurveTA924";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 1.0246820449829102 92 0 93 0 95 25.055164337158203
		 100 -9.0873785018920898 110 1.0246820449829102;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.97773760557174683 0.97773760557174683 
		0.27484014630317688 0.87851035594940186 0.83036375045776367 1;
	setAttr -s 6 ".kiy[0:5]"  -0.20983138680458069 -0.20983138680458069 
		0.9614899754524231 -0.47772327065467834 -0.55722182989120483 0;
	setAttr -s 6 ".kox[0:5]"  0.97773760557174683 0.97773760557174683 
		0.27484014630317688 0.87851035594940186 0.83036375045776367 1;
	setAttr -s 6 ".koy[0:5]"  -0.20983138680458069 -0.20983138680458069 
		0.9614899754524231 -0.47772327065467834 -0.55722182989120483 0;
createNode animCurveTL -n "animCurveTL922";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -2.6052179336547852 93 -3.0419566631317139
		 100 -19.567777633666992 110 -2.6052179336547852;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.27516376972198486 0.022102098912000656 
		0.85120683908462524 1;
	setAttr -s 4 ".kiy[0:3]"  -0.96139740943908691 -0.99975574016571045 
		0.52483046054840088 0;
	setAttr -s 4 ".kox[0:3]"  0.27516376972198486 0.022102098912000656 
		0.85120683908462524 1;
	setAttr -s 4 ".koy[0:3]"  -0.96139740943908691 -0.99975574016571045 
		0.52483046054840088 0;
createNode animCurveTL -n "animCurveTL923";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -19.141372680664063 93 -19.400392532348633
		 100 -10.145771026611328 110 -19.141372680664063;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.43462327122688293 0.041650839149951935 
		0.93917649984359741 1;
	setAttr -s 4 ".kiy[0:3]"  -0.90061235427856445 0.99913221597671509 
		0.34343487024307251 0;
	setAttr -s 4 ".kox[0:3]"  0.43462327122688293 0.041650839149951935 
		0.93917649984359741 1;
	setAttr -s 4 ".koy[0:3]"  -0.90061235427856445 0.99913221597671509 
		0.34343487024307251 0;
createNode animCurveTL -n "animCurveTL924";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 23.227632522583008 93 23.227632522583008
		 100 24.816442489624023 110 23.227632522583008;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  1 0.22971373796463013 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0.97325819730758667 0 0;
	setAttr -s 4 ".kox[0:3]"  1 0.22971373796463013 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0.97325819730758667 0 0;
createNode animCurveTU -n "animCurveTU925";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU926";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU927";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA925";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 0 96 24.217554092407227 110 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99924880266189575 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.038752906024456024 0;
	setAttr -s 3 ".kox[0:2]"  0.99924880266189575 0.99998766183853149 
		1;
	setAttr -s 3 ".koy[0:2]"  0.038752906024456024 -0.0049602468498051167 
		0;
createNode animCurveTA -n "animCurveTA926";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 0 96 5.6998481750488281 110 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.999958336353302 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.0091273672878742218 0;
	setAttr -s 3 ".kox[0:2]"  0.999958336353302 0.9999992847442627 1;
	setAttr -s 3 ".koy[0:2]"  0.0091273672878742218 -0.0011674582492560148 
		0;
createNode animCurveTA -n "animCurveTA927";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 12.527528762817383 96 -35.214511871337891
		 110 12.527528762817383;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99709010124206543 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.076231725513935089 0;
	setAttr -s 3 ".kox[0:2]"  0.99709010124206543 0.99995213747024536 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.076231725513935089 0.0097781931981444359 
		0;
createNode animCurveTL -n "animCurveTL925";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -36.1805419921875 110 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL926";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 7.3658723831176758 96 15.867499351501465
		 110 7.3658723831176758;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.024497754871845245 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.99969983100891113 0;
	setAttr -s 3 ".kox[0:2]"  0.8870011568069458 0.068453386425971985 
		1;
	setAttr -s 3 ".koy[0:2]"  0.46176722645759583 -0.99765431880950928 
		0;
createNode animCurveTL -n "animCurveTL927";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -41.399761199951172 110 -41.399761199951172;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU928";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU929";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU930";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA928";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA929";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA930";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL928";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 22.400806427001953 110 22.400806427001953;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL929";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 10.647112846374512 110 10.647112846374512;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL930";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU931";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU932";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU933";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA931";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA932";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA933";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL931";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 35.083248138427734 110 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL932";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 30.643020629882813 110 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL933";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 36.804916381835937 110 36.804916381835937;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU934";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU935";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU936";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA934";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA935";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA936";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL934";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 35.083248138427734 110 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL935";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 30.643020629882813 110 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL936";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -36.361770629882813 110 -36.361770629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU937";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU938";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU939";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA937";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA938";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA939";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL937";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -5.8221402168273926 110 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL938";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -10.433219909667969 110 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL939";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -28.427871704101563 110 -28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU940";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU941";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU942";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA940";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 93 33.427665710449219 95 27.924270629882812
		 97 10.367711067199707 99 7.1488351821899414 103 12.709237098693848 107 16.134506225585937
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.20949836075305939 0.32357388734817505 
		0.38259932398796082 0.41763857007026672 0.98690086603164673 0.6823086142539978 1 
		1;
	setAttr -s 8 ".kiy[0:7]"  0.97780907154083252 0.94620287418365479 
		-0.92391437292098999 -0.90861326456069946 0.16132804751396179 0.7310643196105957 
		0 0;
	setAttr -s 8 ".kox[0:7]"  0.20949836075305939 0.32357388734817505 
		0.38259932398796082 0.41763857007026672 0.98690086603164673 0.68355590105056763 0.99744892120361328 
		1;
	setAttr -s 8 ".koy[0:7]"  0.97780907154083252 0.94620287418365479 
		-0.92391437292098999 -0.90861326456069946 0.16132804751396179 0.72989815473556519 
		-0.071384109556674957 0;
createNode animCurveTA -n "animCurveTA941";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 93 -20.829410552978516 95 -23.445919036865234
		 97 -3.6731741428375249 99 18.200727462768555 103 10.021164894104004 107 0.072637945413589478
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.32515546679496765 0.3772035539150238 
		0.48634514212608337 0.22349342703819275 0.72281390428543091 0.36465290188789368 0.99940699338912964 
		1;
	setAttr -s 8 ".kiy[0:7]"  -0.94566059112548828 -0.92613035440444946 
		0.87376683950424194 0.97470545768737793 0.69104272127151489 -0.93114352226257324 
		-0.034433960914611816 0;
	setAttr -s 8 ".kox[0:7]"  0.32515546679496765 0.3772035539150238 
		0.48634514212608337 0.22349342703819275 0.72281390428543091 0.36496263742446899 0.99954730272293091 
		1;
	setAttr -s 8 ".koy[0:7]"  -0.94566059112548828 -0.92613035440444946 
		0.87376683950424194 0.97470545768737793 0.69104272127151489 -0.93102222681045532 
		-0.030087331309914589 0;
createNode animCurveTA -n "animCurveTA942";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 93 28.769611358642578 95 25.329629898071289
		 97 15.31396007537842 99 5.1371760368347168 103 -1.3935849666595459 107 1.0404855012893677
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.24156956374645233 0.35276415944099426 
		0.57875162363052368 0.42751780152320862 0.65087497234344482 0.99997502565383911 0.99998152256011963 
		1;
	setAttr -s 8 ".kiy[0:7]"  0.97038346529006958 0.93571215867996216 
		-0.81550389528274536 -0.90400689840316772 -0.75918489694595337 -0.0070682703517377377 
		0.0060881851240992546 0;
	setAttr -s 8 ".kox[0:7]"  0.24156956374645233 0.35276415944099426 
		0.57875162363052368 0.42751780152320862 0.65087497234344482 0.99998152256011963 0.99998933076858521 
		1;
	setAttr -s 8 ".koy[0:7]"  0.97038346529006958 0.93571215867996216 
		-0.81550389528274536 -0.90400689840316772 -0.75918489694595337 0.0060881851240992546 
		-0.004615158773958683 0;
createNode animCurveTL -n "animCurveTL940";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 11.41090202331543 110 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL941";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -0.91886520385742188 110 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL942";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -13.740226745605469 110 -13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU943";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU944";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU945";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA943";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 92 33.427665710449219 94 27.924270629882812
		 96 10.367711067199707 98 7.1488351821899414 102 -8.1442689895629883 106 -4.7189998626708984
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.14139986038208008 0.24843734502792358 
		0.38259977102279663 0.43081694841384888 0.67194259166717529 0.99957400560379028 0.69590705633163452 
		1;
	setAttr -s 8 ".kiy[0:7]"  0.98995262384414673 0.96864795684814453 
		-0.92391419410705566 -0.90243929624557495 -0.74060326814651489 -0.029184391722083092 
		0.71813184022903442 0;
	setAttr -s 8 ".kox[0:7]"  0.14139986038208008 0.24843734502792358 
		0.38259977102279663 0.45222830772399902 0.65363824367523193 1 0.69465547800064087 
		1;
	setAttr -s 8 ".koy[0:7]"  0.98995262384414673 0.96864795684814453 
		-0.92391419410705566 -0.89190220832824707 -0.75680714845657349 0.00030907546170055866 
		0.71934252977371216 0;
createNode animCurveTA -n "animCurveTA944";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 92 -20.829410552978516 94 -23.445919036865234
		 96 -3.6731741428375249 98 18.200727462768555 102 10.021164894104004 106 0.072637945413589478
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.22343118488788605 0.29214182496070862 
		0.48634567856788635 0.22349342703819275 0.72281390428543091 0.36457571387290955 0.99963700771331787 
		1;
	setAttr -s 8 ".kiy[0:7]"  -0.97471976280212402 -0.95637500286102295 
		0.87376642227172852 0.97470545768737793 0.69104272127151489 -0.93117368221282959 
		-0.026941020041704178 0;
	setAttr -s 8 ".kox[0:7]"  0.22343118488788605 0.29214182496070862 
		0.48634567856788635 0.22349342703819275 0.72281390428543091 0.364990234375 0.99974370002746582 
		1;
	setAttr -s 8 ".koy[0:7]"  -0.97471976280212402 -0.95637500286102295 
		0.87376642227172852 0.97470545768737793 0.69104272127151489 -0.93101131916046143 
		-0.022638408467173576 0;
createNode animCurveTA -n "animCurveTA945";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 92 28.769611358642578 94 25.329629898071289
		 96 15.31396007537842 98 5.1371760368347168 102 -1.3935849666595459 106 1.0404855012893677
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.16372205317020416 0.27208349108695984 
		0.57875210046768188 0.42751780152320862 0.65087497234344482 0.99997502565383911 0.99998152256011963 
		1;
	setAttr -s 8 ".kiy[0:7]"  0.98650652170181274 0.96227359771728516 
		-0.81550353765487671 -0.90400689840316772 -0.75918489694595337 -0.0070682703517377377 
		0.0060838791541755199 0;
	setAttr -s 8 ".kox[0:7]"  0.16372205317020416 0.27208349108695984 
		0.57875210046768188 0.42751780152320862 0.65087497234344482 0.99998152256011963 0.9999966025352478 
		1;
	setAttr -s 8 ".koy[0:7]"  0.98650652170181274 0.96227359771728516 
		-0.81550353765487671 -0.90400689840316772 -0.75918489694595337 0.0060838791541755199 
		-0.002602539025247097 0;
createNode animCurveTL -n "animCurveTL943";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0.057151313871145248 110 0.057151313871145248;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL944";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 23.729547500610352 110 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL945";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -53.338920593261719 110 -53.338920593261719;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU946";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU947";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU948";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA946";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA947";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA948";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL946";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -5.8221402168273926 110 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL947";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -10.433219909667969 110 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL948";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 28.427871704101563 110 28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU949";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU950";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU951";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA949";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 92 -9.6617546081542969 93 -31.745410919189453
		 95 -22.588455200195313 98 -12.198409080505371 102 -14.929085731506348 106 -14.226858139038086
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.44303449988365173 0.14873138070106506 
		0.48463284969329834 0.5211714506149292 0.90906411409378052 0.99994528293609619 0.97688257694244385 
		1;
	setAttr -s 8 ".kiy[0:7]"  -0.89650458097457886 -0.98887765407562256 
		-0.87471765279769897 0.85345202684402466 0.41665628552436829 -0.010461618192493916 
		0.2137763649225235 0;
	setAttr -s 8 ".kox[0:7]"  0.44303449988365173 0.14873138070106506 
		0.48463284969329834 0.5211714506149292 0.90906411409378052 1 0.96951383352279663 
		1;
	setAttr -s 8 ".koy[0:7]"  -0.89650458097457886 -0.98887765407562256 
		-0.87471765279769897 0.85345202684402466 0.41665628552436829 0 0.24503673613071442 
		0;
createNode animCurveTA -n "animCurveTA950";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 92 -13.797221183776855 93 -18.390560150146484
		 95 -19.691062927246094 98 -1.4554990530014038 102 6.9281392097473145 106 -0.42259505391120911
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.32702994346618652 0.25129368901252747 
		0.77215522527694702 0.57611823081970215 0.53169715404510498 0.99996548891067505 0.99983125925064087 
		1;
	setAttr -s 8 ".kiy[0:7]"  -0.94501399993896484 -0.96791094541549683 
		-0.63543397188186646 0.81736636161804199 0.84693455696105957 0.0083153741434216499 
		-0.018370155245065689 0;
	setAttr -s 8 ".kox[0:7]"  0.32702994346618652 0.25129368901252747 
		0.77215522527694702 0.57611823081970215 0.53169715404510498 0.99983125925064087 0.99999946355819702 
		1;
	setAttr -s 8 ".koy[0:7]"  -0.94501399993896484 -0.96791094541549683 
		-0.63543397188186646 0.81736636161804199 0.84693455696105957 -0.018370155245065689 
		0.001057029003277421 0;
createNode animCurveTA -n "animCurveTA951";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  91 0 92 8.095911979675293 93 24.522287368774414
		 95 17.751670837402344 98 5.6311731338500977 102 2.6162304878234863 106 1.5140807628631592
		 110 0;
	setAttr -s 8 ".ktl[7]" no;
	setAttr -s 8 ".kix[0:7]"  0.50799542665481567 0.19111739099025726 
		0.59574085474014282 0.53416574001312256 0.74118888378143311 0.97816497087478638 0.99089992046356201 
		1;
	setAttr -s 8 ".kiy[0:7]"  0.86135971546173096 0.98156720399856567 
		0.8031766414642334 -0.84537982940673828 -0.67129659652709961 -0.20782999694347382 
		-0.13460104167461395 0;
	setAttr -s 8 ".kox[0:7]"  0.50799542665481567 0.19111739099025726 
		0.59574085474014282 0.53416574001312256 0.74118888378143311 0.97790205478668213 0.99052751064300537 
		1;
	setAttr -s 8 ".koy[0:7]"  0.86135971546173096 0.98156720399856567 
		0.8031766414642334 -0.84537982940673828 -0.67129659652709961 -0.2090635746717453 
		-0.1373143196105957 0;
createNode animCurveTL -n "animCurveTL949";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 11.41090202331543 110 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL950";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -0.91886520385742188 110 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL951";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 13.740226745605469 110 13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU952";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU953";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU954";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA952";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  91 0 92 -31.745410919189453 94 -22.588455200195313
		 97 -12.198409080505371 101 -2.9912095069885254 105 -2.2889821529388428 110 0;
	setAttr -s 7 ".ktl[6]" no;
	setAttr -s 7 ".kix[0:6]"  0.14873138070106506 0.30223551392555237 
		0.52117103338241577 0.63687324523925781 0.97442764043807983 0.99158823490142822 1;
	setAttr -s 7 ".kiy[0:6]"  -0.98887765407562256 -0.95323324203491211 
		0.85345220565795898 0.77096849679946899 0.22470167279243469 0.12943270802497864 0;
	setAttr -s 7 ".kox[0:6]"  0.14873138070106506 0.30223551392555237 
		0.52117103338241577 0.63710260391235352 0.97709697484970093 0.99106097221374512 1;
	setAttr -s 7 ".koy[0:6]"  -0.98887765407562256 -0.95323324203491211 
		0.85345220565795898 0.7707790732383728 0.21279492974281311 0.13340963423252106 0;
createNode animCurveTA -n "animCurveTA953";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  91 0 92 -18.390560150146484 94 -19.691062927246094
		 97 -1.4554990530014038 101 6.9281392097473145 105 -0.42259505391120911 110 0;
	setAttr -s 7 ".ktl[6]" no;
	setAttr -s 7 ".kix[0:6]"  0.25129368901252747 0.34180986881256104 
		0.5761178731918335 0.53169715404510498 0.99854075908660889 0.99982333183288574 1;
	setAttr -s 7 ".kiy[0:6]"  -0.96791094541549683 -0.93976914882659912 
		0.81736660003662109 0.84693455696105957 0.054003767669200897 -0.018799077719449997 
		0;
	setAttr -s 7 ".kox[0:6]"  0.25129368901252747 0.34180986881256104 
		0.5761178731918335 0.53169715404510498 0.99854075908660889 0.99999970197677612 1;
	setAttr -s 7 ".koy[0:6]"  -0.96791094541549683 -0.93976914882659912 
		0.81736660003662109 0.84693455696105957 0.054003767669200897 0.00067674292949959636 
		0;
createNode animCurveTA -n "animCurveTA954";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  91 0 92 24.522287368774414 94 17.751670837402344
		 97 5.6311731338500977 101 2.6162304878234863 105 1.5140807628631592 110 0;
	setAttr -s 7 ".ktl[6]" no;
	setAttr -s 7 ".kix[0:6]"  0.19111739099025726 0.37414988875389099 
		0.53416532278060913 0.74118888378143311 0.97754436731338501 0.99284911155700684 1;
	setAttr -s 7 ".kiy[0:6]"  0.98156720399856567 0.92736828327178955 
		-0.84538006782531738 -0.67129659652709961 -0.21072956919670105 -0.11937578022480011 
		0;
	setAttr -s 7 ".kox[0:6]"  0.19111739099025726 0.37414988875389099 
		0.53416532278060913 0.74118888378143311 0.97754436731338501 0.99263995885848999 1;
	setAttr -s 7 ".koy[0:6]"  0.98156720399856567 0.92736828327178955 
		-0.84538006782531738 -0.67129659652709961 -0.21072956919670105 -0.12110275030136108 
		0;
createNode animCurveTL -n "animCurveTL952";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0.057151321321725845 110 0.057151321321725845;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL953";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 23.729547500610352 110 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL954";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 53.782066345214844 110 53.782066345214844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU955";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU956";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU957";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA955";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 2.3232021855164326 92 4.7022008895874023
		 105 -1.7321264743804932 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.99890851974487305 
		0.99999880790710449 1;
	setAttr -s 4 ".kiy[0:3]"  0.061064749956130981 0.046709503978490829 
		-0.0015282677486538887 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99999880790710449 
		0.99999618530273438 1;
	setAttr -s 4 ".koy[0:3]"  0.061064399778842926 -0.0015288138529285789 
		0.0027738139033317566 0;
createNode animCurveTA -n "animCurveTA956";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -13.59076686019182 92 -27.507944107055664
		 105 -10.261875152587891 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.96456176042556763 
		0.51536095142364502 1;
	setAttr -s 4 ".kiy[0:3]"  -0.35722970962524414 -0.26385694742202759 
		0.85697317123413086 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 0.51552814245223999 
		1;
	setAttr -s 4 ".koy[0:3]"  -0.35722768306732178 0 0.85687255859375 
		0;
createNode animCurveTA -n "animCurveTA957";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 3.530491865850748 92 7.1457757949829102
		 105 -4.1811895370483398 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.99748468399047852 
		0.9999963641166687 1;
	setAttr -s 4 ".kiy[0:3]"  0.092798039317131042 0.070882201194763184 
		-0.0026903506368398666 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.9999963641166687 
		0.99997758865356445 1;
	setAttr -s 4 ".koy[0:3]"  0.092797502875328064 -0.0026913117617368698 
		0.0066955992951989174 0;
createNode animCurveTL -n "animCurveTL955";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 -1.1630247831344604 92 -1.1630247831344604
		 110 -1.1630247831344604;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL956";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1.228269100189209 92 1.228269100189209
		 110 1.228269100189209;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL957";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 27.684015274047852 92 27.684015274047852
		 110 27.684015274047852;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU958";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU959";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU960";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA958";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -9.9051623962934343 92 -20.0482177734375
		 105 -4.1821646690368652 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.98069947957992554 
		0.68978691101074219 1;
	setAttr -s 4 ".kiy[0:3]"  -0.26035454869270325 -0.19552116096019745 
		0.72401243448257446 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.9999992847442627 
		0.69161981344223022 1;
	setAttr -s 4 ".koy[0:3]"  -0.26035308837890625 0.0011883376864716411 
		0.72226178646087646 0;
createNode animCurveTA -n "animCurveTA959";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -69.772178649902344 92 -58.976150512695313
		 105 20.210897445678711 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.34213656187057495 0.13050772249698639 
		1 1;
	setAttr -s 4 ".kiy[0:3]"  -0.93965017795562744 0.99144726991653442 
		0 0;
	setAttr -s 4 ".kox[0:3]"  0.98282945156097412 0.12984053790569305 
		0.99947661161422729 1;
	setAttr -s 4 ".koy[0:3]"  0.18451634049415588 0.99153488874435425 
		-0.032348763197660446 0;
createNode animCurveTA -n "animCurveTA960";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 5.0707623334107614 92 10.263309478759766
		 105 -8.014521598815918 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.99483191967010498 
		0.99999052286148071 1;
	setAttr -s 4 ".kiy[0:3]"  0.13328364491462708 0.10153526812791824 
		-0.0043412758968770504 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99999052286148071 
		0.99991762638092041 1;
	setAttr -s 4 ".koy[0:3]"  0.13328289985656738 -0.0043428265489637852 
		0.012833384796977043 0;
createNode animCurveTL -n "animCurveTL958";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 4.9883952140808105 92 4.9883952140808105
		 110 4.9883952140808105;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL959";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 41.4617919921875 92 41.4617919921875
		 110 41.4617919921875;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL960";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 38.623714447021484 92 38.623714447021484
		 110 38.623714447021484;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU961";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU962";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU963";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA961";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 9.9401427069059558 92 20.1190185546875
		 105 15.46749687194824 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.98056715726852417 
		0.91243362426757813 1;
	setAttr -s 4 ".kiy[0:3]"  0.26127400994300842 0.19618374109268188 
		-0.40922477841377258 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 0.90549808740615845 
		1;
	setAttr -s 4 ".koy[0:3]"  0.26127249002456665 0 -0.42435038089752197 
		0;
createNode animCurveTA -n "animCurveTA962";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 18.570242007794295 92 37.58648681640625
		 105 14.376406669616699 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.93670523166656494 
		0.40796834230422974 1;
	setAttr -s 4 ".kiy[0:3]"  0.48811385035514832 0.35011902451515198 
		-0.91299599409103394 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 0.40798091888427734 
		1;
	setAttr -s 4 ".koy[0:3]"  0.48811110854148865 0 -0.91299045085906982 
		0;
createNode animCurveTA -n "animCurveTA963";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 13.999147066052986 92 28.334512710571289
		 105 23.681692123413086 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.96252012252807617 
		0.91239094734191895 1;
	setAttr -s 4 ".kiy[0:3]"  0.36796388030052185 0.27121031284332275 
		-0.40931990742683411 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 0.90084880590438843 
		1;
	setAttr -s 4 ".koy[0:3]"  0.36796170473098755 0 -0.43413302302360535 
		0;
createNode animCurveTL -n "animCurveTL961";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1.1630247831344604 92 1.1630247831344604
		 110 1.1630247831344604;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL962";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 2.0187394618988037 92 2.0187394618988037
		 110 2.0187394618988037;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL963";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 27.637619018554688 92 27.637619018554688
		 110 27.637619018554688;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU964";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU965";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU966";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1 92 1 110 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA964";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 -2.7527070487259331 92 -5.571526050567627
		 105 1.6143791675567627 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.99846863746643066 
		0.99999850988388062 1;
	setAttr -s 4 ".kiy[0:3]"  -0.07235417515039444 -0.055321060121059418 
		0.0017067806329578161 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99999850988388062 
		0.99999666213989258 1;
	setAttr -s 4 ".koy[0:3]"  -0.072353750467300415 0.0017073902999982238 
		-0.0025852557737380266 0;
createNode animCurveTA -n "animCurveTA965";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 26.741337542302205 92 54.124923706054688
		 105 -18.139936447143555 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.88055109977722168 
		0.99985277652740479 1;
	setAttr -s 4 ".kiy[0:3]"  0.70288896560668945 0.47395122051239014 
		-0.017161687836050987 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99985271692276001 
		0.99957835674285889 1;
	setAttr -s 4 ".koy[0:3]"  0.70288485288619995 -0.017167819663882256 
		0.029037019237875938 0;
createNode animCurveTA -n "animCurveTA966";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 2.6124958625319388 92 5.4182491302490234
		 105 6.5726613998413086 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.98714298009872437 
		1 1;
	setAttr -s 4 ".kiy[0:3]"  0.069238230586051941 0.15984007716178894 
		0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99386006593704224 
		0.99994462728500366 1;
	setAttr -s 4 ".koy[0:3]"  0.069237843155860901 0.11064430326223373 
		-0.010524865239858627 0;
createNode animCurveTL -n "animCurveTL964";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 4.9883952140808105 92 4.9883952140808105
		 110 4.9883952140808105;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL965";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 41.4617919921875 92 41.4617919921875
		 110 41.4617919921875;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL966";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 -38.180568695068359 92 -38.180568695068359
		 110 -38.180568695068359;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU967";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU968";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU969";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA967";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 -9.5584049224853516 93 -6.9610333442687988
		 95 -5.5398592948913574 101 -9.1595706939697266 106 -12.695022583007813 110 -9.5584049224853516;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.94008743762969971 0.92171156406402588 
		0.99343937635421753 0.96482723951339722 0.99999231100082397 1;
	setAttr -s 6 ".kiy[0:5]"  0.34093347191810608 0.38787603378295898 
		-0.11435984075069427 -0.26288458704948425 -0.0039292755536735058 0;
	setAttr -s 6 ".kox[0:5]"  0.94008743762969971 0.92171156406402588 
		0.99343937635421753 0.96482723951339722 0.9999692440032959 1;
	setAttr -s 6 ".koy[0:5]"  0.34093347191810608 0.38787603378295898 
		-0.11435984075069427 -0.26288458704948425 0.0078453253954648972 0;
createNode animCurveTA -n "animCurveTA968";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 -14.087939262390137 93 -11.750126838684082
		 95 -14.977632522583006 101 -16.650836944580078 106 -16.498847961425781 110 -14.087939262390137;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.95063644647598267 0.99568790197372437 
		0.96861958503723145 0.99832642078399658 0.99926656484603882 1;
	setAttr -s 6 ".kiy[0:5]"  0.3103068470954895 -0.092766784131526947 
		-0.24854819476604462 -0.057830784469842911 0.03829270601272583 0;
	setAttr -s 6 ".kox[0:5]"  0.95063644647598267 0.99568790197372437 
		0.96861958503723145 0.99832642078399658 0.99904948472976685 1;
	setAttr -s 6 ".koy[0:5]"  0.3103068470954895 -0.092766784131526947 
		-0.24854819476604462 -0.057830784469842911 0.043589875102043152 0;
createNode animCurveTA -n "animCurveTA969";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 -2.2710940837860107 93 -7.5891270637512198
		 95 -12.259181022644043 101 -2.2560274600982666 106 5.5441665649414062 110 -2.2710940837860107;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.80286669731140137 0.69105124473571777 
		0.96315371990203857 0.82771468162536621 0.99996650218963623 1;
	setAttr -s 6 ".kiy[0:5]"  -0.59615862369537354 -0.72280573844909668 
		0.26895129680633545 0.56114917993545532 0.0081805065274238586 0;
	setAttr -s 6 ".kox[0:5]"  0.80286669731140137 0.69105124473571777 
		0.96315371990203857 0.82771468162536621 0.99980896711349487 1;
	setAttr -s 6 ".koy[0:5]"  -0.59615862369537354 -0.72280573844909668 
		0.26895129680633545 0.56114917993545532 -0.019544443115592003 0;
createNode animCurveTL -n "animCurveTL967";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 32.845657348632812 110 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL968";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 17.186578750610352 110 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL969";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 11.930496215820313 110 11.930496215820313;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU970";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU971";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU972";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA970";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 -0.89352136850357056 93 -0.58495610952377319
		 95 -1.3040084838867187 101 -0.72641885280609131 106 -0.98100537061691284 110 -0.89352136850357056;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.99907314777374268 0.99907732009887695 
		0.99997258186340332 0.99992430210113525 0.99999982118606567 1;
	setAttr -s 6 ".kiy[0:5]"  0.043043911457061768 -0.042946483939886093 
		-0.0074067683890461922 0.012299001216888428 -0.00048590078949928284 0;
	setAttr -s 6 ".kox[0:5]"  0.99907314777374268 0.99907732009887695 
		0.99997258186340332 0.99992430210113525 1 1;
	setAttr -s 6 ".koy[0:5]"  0.043043911457061768 -0.042946483939886093 
		-0.0074067683890461922 0.012299001216888428 0.00021882216969970614 0;
createNode animCurveTA -n "animCurveTA971";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 11.041102409362793 93 13.867194175720215
		 95 11.245979309082031 101 8.3085050582885742 106 7.1991539001464844 110 11.041102409362793;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.93019968271255493 0.99976992607116699 
		0.96015852689743042 0.98833352327346802 0.99999970197677612 1;
	setAttr -s 6 ".kiy[0:5]"  0.36705392599105835 0.02144971489906311 
		-0.27945610880851746 -0.15230493247509003 -0.00079671601997688413 0;
	setAttr -s 6 ".kox[0:5]"  0.93019968271255493 0.99976992607116699 
		0.96015852689743042 0.98833352327346802 0.99995380640029907 1;
	setAttr -s 6 ".koy[0:5]"  0.36705392599105835 0.02144971489906311 
		-0.27945610880851746 -0.15230493247509003 0.0096093537285923958 0;
createNode animCurveTA -n "animCurveTA972";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0.32489952445030212 93 -4.6245579719543457
		 95 -9.5683956146240234 101 0.6155322790145874 106 8.2436456680297852 110 0.32489952445030212;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.82266664505004883 0.69448673725128174 
		0.96436047554016113 0.82758742570877075 0.99996870756149292 1;
	setAttr -s 6 ".kiy[0:5]"  -0.56852400302886963 -0.7195054292678833 
		0.26459190249443054 0.56133687496185303 0.007902858778834343 0;
	setAttr -s 6 ".kox[0:5]"  0.82266664505004883 0.69448673725128174 
		0.96436047554016113 0.82758742570877075 0.99980396032333374 1;
	setAttr -s 6 ".koy[0:5]"  -0.56852400302886963 -0.7195054292678833 
		0.26459190249443054 0.56133687496185303 -0.019803140312433243 0;
createNode animCurveTL -n "animCurveTL970";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 32.845657348632812 110 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL971";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 17.186578750610352 110 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL972";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -11.48735237121582 110 -11.48735237121582;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU973";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU974";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU975";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA973";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA974";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA975";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL973";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 47.368160247802734 110 47.368160247802734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL974";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  91 1.1064795255661011 95 69.189155578613281
		 110 26.913848876953125;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.017178500071167946 0.10202652215957642 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.99985241889953613 0.99478167295455933 
		0;
	setAttr -s 3 ".kox[0:2]"  0.10202652215957642 0.91787618398666382 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99478167295455933 -0.39686667919158936 
		0;
createNode animCurveTL -n "animCurveTL975";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0.22157172858715057 110 0.22157172858715057;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU976";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU977";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU978";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA976";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 94 2.5114529132843018 97 -3.8270037174224854
		 102 -3.9307630062103271 106 -2.898101806640625 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.96711248159408569 0.96611243486404419 
		0.94754570722579956 0.99999803304672241 0.95556199550628662 1;
	setAttr -s 6 ".kiy[0:5]"  0.2543492317199707 -0.25812160968780518 
		-0.31962016224861145 0.0019785163458436728 0.29479032754898071 0;
	setAttr -s 6 ".kox[0:5]"  0.96711248159408569 0.96611243486404419 
		0.94754570722579956 1 0.95426923036575317 1;
	setAttr -s 6 ".koy[0:5]"  0.2543492317199707 -0.25812160968780518 
		-0.31962016224861145 0 0.29894861578941345 0;
createNode animCurveTA -n "animCurveTA977";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 94 5.1289529800415039 97 -5.3558669090270996
		 102 4.048649787902832 106 6.5229926109313965 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.88097047805786133 0.93666428327560425 
		0.99840402603149414 0.7874377965927124 1 1;
	setAttr -s 6 ".kiy[0:5]"  0.47317126393318176 -0.35022854804992676 
		-0.056474287062883377 0.61639416217803955 0 0;
	setAttr -s 6 ".kox[0:5]"  0.88097047805786133 0.93666428327560425 
		0.99840402603149414 0.79191559553146362 0.99986696243286133 1;
	setAttr -s 6 ".koy[0:5]"  0.47317126393318176 -0.35022854804992676 
		-0.056474287062883377 0.61063039302825928 -0.016313677653670311 0;
createNode animCurveTA -n "animCurveTA978";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  91 0 94 7.0021562576293945 97 -21.760629653930664
		 102 -25.018987655639648 106 -9.5242080688476563 110 0;
	setAttr -s 6 ".ktl[5]" no;
	setAttr -s 6 ".kix[0:5]"  0.80643171072006226 0.54982340335845947 
		0.51224392652511597 0.99998515844345093 0.44025909900665283 1;
	setAttr -s 6 ".kiy[0:5]"  0.59132719039916992 -0.8352808952331543 
		-0.85883998870849609 0.0054421587847173214 0.89787083864212036 0;
	setAttr -s 6 ".kox[0:5]"  0.80643171072006226 0.54982340335845947 
		0.51224392652511597 0.99974483251571655 0.44274294376373291 1;
	setAttr -s 6 ".koy[0:5]"  0.59132719039916992 -0.8352808952331543 
		-0.85883998870849609 0.02259024977684021 0.8966485857963562 0;
createNode animCurveTL -n "animCurveTL976";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  91 0.55634701251983643 94 -8.5071859359741211
		 97 -16.202709197998047 102 -12.601634979248047 110 0.55634701251983643;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.018385613337159157 0.01491563580930233 
		0.08114255964756012 0.01937670074403286 1;
	setAttr -s 5 ".kiy[0:4]"  -0.99983096122741699 -0.99988877773284912 
		-0.99670249223709106 0.99981224536895752 0;
	setAttr -s 5 ".kox[0:4]"  0.018385613337159157 0.01491563580930233 
		0.08114255964756012 0.019260495901107788 1;
	setAttr -s 5 ".koy[0:4]"  -0.99983096122741699 -0.99988877773284912 
		-0.99670249223709106 0.99981445074081421 0;
createNode animCurveTL -n "animCurveTL977";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  91 28.874954223632813 94 31.335857391357422
		 97 34.897098541259766 102 33.421794891357422 110 28.874954223632813;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.067571043968200684 0.041477680206298828 
		0.15779818594455719 0.047235295176506042 1;
	setAttr -s 5 ".kiy[0:4]"  0.99771445989608765 0.99913942813873291 
		0.98747140169143677 -0.99888378381729126 0;
	setAttr -s 5 ".kox[0:4]"  0.067571043968200684 0.041477680206298828 
		0.15779818594455719 0.047036662697792053 1;
	setAttr -s 5 ".koy[0:4]"  0.99771445989608765 0.99913942813873291 
		0.98747140169143677 -0.99889320135116577 0;
createNode animCurveTL -n "animCurveTL978";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU979";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU980";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU981";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA979";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA980";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA981";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL979";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -1.4725730419158936 110 -1.4725730419158936;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL980";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 25.007797241210938 110 25.007797241210938;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL981";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU982";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU983";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU984";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA982";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA983";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA984";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL982";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -0.28501001000404358 110 -0.28501001000404358;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL983";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL984";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU985";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU986";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU987";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA985";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA986";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA987";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 0 94 -21.642412185668945 97 -22.903671264648438
		 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.40368205308914185 0.53024226427078247 
		0.87004822492599487 1;
	setAttr -s 4 ".kiy[0:3]"  -0.91489934921264648 -0.84784615039825439 
		0.49296662211418152 0;
	setAttr -s 4 ".kox[0:3]"  0.40368205308914185 0.53024226427078247 
		0.87004822492599487 1;
	setAttr -s 4 ".koy[0:3]"  -0.91489934921264648 -0.84784615039825439 
		0.49296662211418152 0;
createNode animCurveTL -n "animCurveTL985";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 0 94 -38.110141754150391 97 -41.809566497802734
		 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.0043732482008635998 0.0059793815016746521 
		0.017490478232502937 1;
	setAttr -s 4 ".kiy[0:3]"  -0.99999040365219116 -0.99998211860656738 
		0.99984699487686157 0;
	setAttr -s 4 ".kox[0:3]"  0.0043732482008635998 0.0059793815016746521 
		0.017490478232502937 1;
	setAttr -s 4 ".koy[0:3]"  -0.99999040365219116 -0.99998211860656738 
		0.99984699487686157 0;
createNode animCurveTL -n "animCurveTL986";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  91 0 101 10.34201717376709 106 -4.4103717803955078
		 110 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.044274155050516129 0.14030946791172028 
		0.60714876651763916 1;
	setAttr -s 4 ".kiy[0:3]"  0.99901944398880005 -0.99010771512985229 
		-0.79458808898925781 0;
	setAttr -s 4 ".kox[0:3]"  0.044274155050516129 0.14030946791172028 
		0.84530407190322876 1;
	setAttr -s 4 ".koy[0:3]"  0.99901944398880005 -0.99010771512985229 
		0.53428566455841064 0;
createNode animCurveTL -n "animCurveTL987";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU988";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU989";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU990";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 1 110 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA988";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA989";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA990";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 0 110 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL988";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 2.0856802463531494 110 2.0856802463531494;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL989";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 -5.0555992126464844 110 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL990";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  91 28.250843048095703 110 28.250843048095703;
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
connectAttr "get_hit_from_frontSource.cl" "clipLibrary1.sc[0]";
connectAttr "animCurveTU901.a" "clipLibrary1.cel[0].cev[0].cevr";
connectAttr "animCurveTU902.a" "clipLibrary1.cel[0].cev[1].cevr";
connectAttr "animCurveTU903.a" "clipLibrary1.cel[0].cev[2].cevr";
connectAttr "animCurveTA901.a" "clipLibrary1.cel[0].cev[3].cevr";
connectAttr "animCurveTA902.a" "clipLibrary1.cel[0].cev[4].cevr";
connectAttr "animCurveTA903.a" "clipLibrary1.cel[0].cev[5].cevr";
connectAttr "animCurveTL901.a" "clipLibrary1.cel[0].cev[6].cevr";
connectAttr "animCurveTL902.a" "clipLibrary1.cel[0].cev[7].cevr";
connectAttr "animCurveTL903.a" "clipLibrary1.cel[0].cev[8].cevr";
connectAttr "animCurveTU904.a" "clipLibrary1.cel[0].cev[9].cevr";
connectAttr "animCurveTU905.a" "clipLibrary1.cel[0].cev[10].cevr";
connectAttr "animCurveTU906.a" "clipLibrary1.cel[0].cev[11].cevr";
connectAttr "animCurveTA904.a" "clipLibrary1.cel[0].cev[12].cevr";
connectAttr "animCurveTA905.a" "clipLibrary1.cel[0].cev[13].cevr";
connectAttr "animCurveTA906.a" "clipLibrary1.cel[0].cev[14].cevr";
connectAttr "animCurveTL904.a" "clipLibrary1.cel[0].cev[15].cevr";
connectAttr "animCurveTL905.a" "clipLibrary1.cel[0].cev[16].cevr";
connectAttr "animCurveTL906.a" "clipLibrary1.cel[0].cev[17].cevr";
connectAttr "animCurveTU907.a" "clipLibrary1.cel[0].cev[18].cevr";
connectAttr "animCurveTU908.a" "clipLibrary1.cel[0].cev[19].cevr";
connectAttr "animCurveTU909.a" "clipLibrary1.cel[0].cev[20].cevr";
connectAttr "animCurveTA907.a" "clipLibrary1.cel[0].cev[21].cevr";
connectAttr "animCurveTA908.a" "clipLibrary1.cel[0].cev[22].cevr";
connectAttr "animCurveTA909.a" "clipLibrary1.cel[0].cev[23].cevr";
connectAttr "animCurveTL907.a" "clipLibrary1.cel[0].cev[24].cevr";
connectAttr "animCurveTL908.a" "clipLibrary1.cel[0].cev[25].cevr";
connectAttr "animCurveTL909.a" "clipLibrary1.cel[0].cev[26].cevr";
connectAttr "animCurveTU910.a" "clipLibrary1.cel[0].cev[27].cevr";
connectAttr "animCurveTU911.a" "clipLibrary1.cel[0].cev[28].cevr";
connectAttr "animCurveTU912.a" "clipLibrary1.cel[0].cev[29].cevr";
connectAttr "animCurveTA910.a" "clipLibrary1.cel[0].cev[30].cevr";
connectAttr "animCurveTA911.a" "clipLibrary1.cel[0].cev[31].cevr";
connectAttr "animCurveTA912.a" "clipLibrary1.cel[0].cev[32].cevr";
connectAttr "animCurveTL910.a" "clipLibrary1.cel[0].cev[33].cevr";
connectAttr "animCurveTL911.a" "clipLibrary1.cel[0].cev[34].cevr";
connectAttr "animCurveTL912.a" "clipLibrary1.cel[0].cev[35].cevr";
connectAttr "animCurveTU913.a" "clipLibrary1.cel[0].cev[36].cevr";
connectAttr "animCurveTU914.a" "clipLibrary1.cel[0].cev[37].cevr";
connectAttr "animCurveTU915.a" "clipLibrary1.cel[0].cev[38].cevr";
connectAttr "animCurveTA913.a" "clipLibrary1.cel[0].cev[39].cevr";
connectAttr "animCurveTA914.a" "clipLibrary1.cel[0].cev[40].cevr";
connectAttr "animCurveTA915.a" "clipLibrary1.cel[0].cev[41].cevr";
connectAttr "animCurveTL913.a" "clipLibrary1.cel[0].cev[42].cevr";
connectAttr "animCurveTL914.a" "clipLibrary1.cel[0].cev[43].cevr";
connectAttr "animCurveTL915.a" "clipLibrary1.cel[0].cev[44].cevr";
connectAttr "animCurveTU916.a" "clipLibrary1.cel[0].cev[45].cevr";
connectAttr "animCurveTU917.a" "clipLibrary1.cel[0].cev[46].cevr";
connectAttr "animCurveTU918.a" "clipLibrary1.cel[0].cev[47].cevr";
connectAttr "animCurveTA916.a" "clipLibrary1.cel[0].cev[48].cevr";
connectAttr "animCurveTA917.a" "clipLibrary1.cel[0].cev[49].cevr";
connectAttr "animCurveTA918.a" "clipLibrary1.cel[0].cev[50].cevr";
connectAttr "animCurveTL916.a" "clipLibrary1.cel[0].cev[51].cevr";
connectAttr "animCurveTL917.a" "clipLibrary1.cel[0].cev[52].cevr";
connectAttr "animCurveTL918.a" "clipLibrary1.cel[0].cev[53].cevr";
connectAttr "animCurveTU919.a" "clipLibrary1.cel[0].cev[54].cevr";
connectAttr "animCurveTU920.a" "clipLibrary1.cel[0].cev[55].cevr";
connectAttr "animCurveTU921.a" "clipLibrary1.cel[0].cev[56].cevr";
connectAttr "animCurveTA919.a" "clipLibrary1.cel[0].cev[57].cevr";
connectAttr "animCurveTA920.a" "clipLibrary1.cel[0].cev[58].cevr";
connectAttr "animCurveTA921.a" "clipLibrary1.cel[0].cev[59].cevr";
connectAttr "animCurveTL919.a" "clipLibrary1.cel[0].cev[60].cevr";
connectAttr "animCurveTL920.a" "clipLibrary1.cel[0].cev[61].cevr";
connectAttr "animCurveTL921.a" "clipLibrary1.cel[0].cev[62].cevr";
connectAttr "animCurveTU922.a" "clipLibrary1.cel[0].cev[63].cevr";
connectAttr "animCurveTU923.a" "clipLibrary1.cel[0].cev[64].cevr";
connectAttr "animCurveTU924.a" "clipLibrary1.cel[0].cev[65].cevr";
connectAttr "animCurveTA922.a" "clipLibrary1.cel[0].cev[66].cevr";
connectAttr "animCurveTA923.a" "clipLibrary1.cel[0].cev[67].cevr";
connectAttr "animCurveTA924.a" "clipLibrary1.cel[0].cev[68].cevr";
connectAttr "animCurveTL922.a" "clipLibrary1.cel[0].cev[69].cevr";
connectAttr "animCurveTL923.a" "clipLibrary1.cel[0].cev[70].cevr";
connectAttr "animCurveTL924.a" "clipLibrary1.cel[0].cev[71].cevr";
connectAttr "animCurveTU925.a" "clipLibrary1.cel[0].cev[72].cevr";
connectAttr "animCurveTU926.a" "clipLibrary1.cel[0].cev[73].cevr";
connectAttr "animCurveTU927.a" "clipLibrary1.cel[0].cev[74].cevr";
connectAttr "animCurveTA925.a" "clipLibrary1.cel[0].cev[75].cevr";
connectAttr "animCurveTA926.a" "clipLibrary1.cel[0].cev[76].cevr";
connectAttr "animCurveTA927.a" "clipLibrary1.cel[0].cev[77].cevr";
connectAttr "animCurveTL925.a" "clipLibrary1.cel[0].cev[78].cevr";
connectAttr "animCurveTL926.a" "clipLibrary1.cel[0].cev[79].cevr";
connectAttr "animCurveTL927.a" "clipLibrary1.cel[0].cev[80].cevr";
connectAttr "animCurveTU928.a" "clipLibrary1.cel[0].cev[81].cevr";
connectAttr "animCurveTU929.a" "clipLibrary1.cel[0].cev[82].cevr";
connectAttr "animCurveTU930.a" "clipLibrary1.cel[0].cev[83].cevr";
connectAttr "animCurveTA928.a" "clipLibrary1.cel[0].cev[84].cevr";
connectAttr "animCurveTA929.a" "clipLibrary1.cel[0].cev[85].cevr";
connectAttr "animCurveTA930.a" "clipLibrary1.cel[0].cev[86].cevr";
connectAttr "animCurveTL928.a" "clipLibrary1.cel[0].cev[87].cevr";
connectAttr "animCurveTL929.a" "clipLibrary1.cel[0].cev[88].cevr";
connectAttr "animCurveTL930.a" "clipLibrary1.cel[0].cev[89].cevr";
connectAttr "animCurveTU931.a" "clipLibrary1.cel[0].cev[90].cevr";
connectAttr "animCurveTU932.a" "clipLibrary1.cel[0].cev[91].cevr";
connectAttr "animCurveTU933.a" "clipLibrary1.cel[0].cev[92].cevr";
connectAttr "animCurveTA931.a" "clipLibrary1.cel[0].cev[93].cevr";
connectAttr "animCurveTA932.a" "clipLibrary1.cel[0].cev[94].cevr";
connectAttr "animCurveTA933.a" "clipLibrary1.cel[0].cev[95].cevr";
connectAttr "animCurveTL931.a" "clipLibrary1.cel[0].cev[96].cevr";
connectAttr "animCurveTL932.a" "clipLibrary1.cel[0].cev[97].cevr";
connectAttr "animCurveTL933.a" "clipLibrary1.cel[0].cev[98].cevr";
connectAttr "animCurveTU934.a" "clipLibrary1.cel[0].cev[99].cevr";
connectAttr "animCurveTU935.a" "clipLibrary1.cel[0].cev[100].cevr";
connectAttr "animCurveTU936.a" "clipLibrary1.cel[0].cev[101].cevr";
connectAttr "animCurveTA934.a" "clipLibrary1.cel[0].cev[102].cevr";
connectAttr "animCurveTA935.a" "clipLibrary1.cel[0].cev[103].cevr";
connectAttr "animCurveTA936.a" "clipLibrary1.cel[0].cev[104].cevr";
connectAttr "animCurveTL934.a" "clipLibrary1.cel[0].cev[105].cevr";
connectAttr "animCurveTL935.a" "clipLibrary1.cel[0].cev[106].cevr";
connectAttr "animCurveTL936.a" "clipLibrary1.cel[0].cev[107].cevr";
connectAttr "animCurveTU937.a" "clipLibrary1.cel[0].cev[108].cevr";
connectAttr "animCurveTU938.a" "clipLibrary1.cel[0].cev[109].cevr";
connectAttr "animCurveTU939.a" "clipLibrary1.cel[0].cev[110].cevr";
connectAttr "animCurveTA937.a" "clipLibrary1.cel[0].cev[111].cevr";
connectAttr "animCurveTA938.a" "clipLibrary1.cel[0].cev[112].cevr";
connectAttr "animCurveTA939.a" "clipLibrary1.cel[0].cev[113].cevr";
connectAttr "animCurveTL937.a" "clipLibrary1.cel[0].cev[114].cevr";
connectAttr "animCurveTL938.a" "clipLibrary1.cel[0].cev[115].cevr";
connectAttr "animCurveTL939.a" "clipLibrary1.cel[0].cev[116].cevr";
connectAttr "animCurveTU940.a" "clipLibrary1.cel[0].cev[117].cevr";
connectAttr "animCurveTU941.a" "clipLibrary1.cel[0].cev[118].cevr";
connectAttr "animCurveTU942.a" "clipLibrary1.cel[0].cev[119].cevr";
connectAttr "animCurveTA940.a" "clipLibrary1.cel[0].cev[120].cevr";
connectAttr "animCurveTA941.a" "clipLibrary1.cel[0].cev[121].cevr";
connectAttr "animCurveTA942.a" "clipLibrary1.cel[0].cev[122].cevr";
connectAttr "animCurveTL940.a" "clipLibrary1.cel[0].cev[123].cevr";
connectAttr "animCurveTL941.a" "clipLibrary1.cel[0].cev[124].cevr";
connectAttr "animCurveTL942.a" "clipLibrary1.cel[0].cev[125].cevr";
connectAttr "animCurveTU943.a" "clipLibrary1.cel[0].cev[126].cevr";
connectAttr "animCurveTU944.a" "clipLibrary1.cel[0].cev[127].cevr";
connectAttr "animCurveTU945.a" "clipLibrary1.cel[0].cev[128].cevr";
connectAttr "animCurveTA943.a" "clipLibrary1.cel[0].cev[129].cevr";
connectAttr "animCurveTA944.a" "clipLibrary1.cel[0].cev[130].cevr";
connectAttr "animCurveTA945.a" "clipLibrary1.cel[0].cev[131].cevr";
connectAttr "animCurveTL943.a" "clipLibrary1.cel[0].cev[132].cevr";
connectAttr "animCurveTL944.a" "clipLibrary1.cel[0].cev[133].cevr";
connectAttr "animCurveTL945.a" "clipLibrary1.cel[0].cev[134].cevr";
connectAttr "animCurveTU946.a" "clipLibrary1.cel[0].cev[135].cevr";
connectAttr "animCurveTU947.a" "clipLibrary1.cel[0].cev[136].cevr";
connectAttr "animCurveTU948.a" "clipLibrary1.cel[0].cev[137].cevr";
connectAttr "animCurveTA946.a" "clipLibrary1.cel[0].cev[138].cevr";
connectAttr "animCurveTA947.a" "clipLibrary1.cel[0].cev[139].cevr";
connectAttr "animCurveTA948.a" "clipLibrary1.cel[0].cev[140].cevr";
connectAttr "animCurveTL946.a" "clipLibrary1.cel[0].cev[141].cevr";
connectAttr "animCurveTL947.a" "clipLibrary1.cel[0].cev[142].cevr";
connectAttr "animCurveTL948.a" "clipLibrary1.cel[0].cev[143].cevr";
connectAttr "animCurveTU949.a" "clipLibrary1.cel[0].cev[144].cevr";
connectAttr "animCurveTU950.a" "clipLibrary1.cel[0].cev[145].cevr";
connectAttr "animCurveTU951.a" "clipLibrary1.cel[0].cev[146].cevr";
connectAttr "animCurveTA949.a" "clipLibrary1.cel[0].cev[147].cevr";
connectAttr "animCurveTA950.a" "clipLibrary1.cel[0].cev[148].cevr";
connectAttr "animCurveTA951.a" "clipLibrary1.cel[0].cev[149].cevr";
connectAttr "animCurveTL949.a" "clipLibrary1.cel[0].cev[150].cevr";
connectAttr "animCurveTL950.a" "clipLibrary1.cel[0].cev[151].cevr";
connectAttr "animCurveTL951.a" "clipLibrary1.cel[0].cev[152].cevr";
connectAttr "animCurveTU952.a" "clipLibrary1.cel[0].cev[153].cevr";
connectAttr "animCurveTU953.a" "clipLibrary1.cel[0].cev[154].cevr";
connectAttr "animCurveTU954.a" "clipLibrary1.cel[0].cev[155].cevr";
connectAttr "animCurveTA952.a" "clipLibrary1.cel[0].cev[156].cevr";
connectAttr "animCurveTA953.a" "clipLibrary1.cel[0].cev[157].cevr";
connectAttr "animCurveTA954.a" "clipLibrary1.cel[0].cev[158].cevr";
connectAttr "animCurveTL952.a" "clipLibrary1.cel[0].cev[159].cevr";
connectAttr "animCurveTL953.a" "clipLibrary1.cel[0].cev[160].cevr";
connectAttr "animCurveTL954.a" "clipLibrary1.cel[0].cev[161].cevr";
connectAttr "animCurveTU955.a" "clipLibrary1.cel[0].cev[162].cevr";
connectAttr "animCurveTU956.a" "clipLibrary1.cel[0].cev[163].cevr";
connectAttr "animCurveTU957.a" "clipLibrary1.cel[0].cev[164].cevr";
connectAttr "animCurveTA955.a" "clipLibrary1.cel[0].cev[165].cevr";
connectAttr "animCurveTA956.a" "clipLibrary1.cel[0].cev[166].cevr";
connectAttr "animCurveTA957.a" "clipLibrary1.cel[0].cev[167].cevr";
connectAttr "animCurveTL955.a" "clipLibrary1.cel[0].cev[168].cevr";
connectAttr "animCurveTL956.a" "clipLibrary1.cel[0].cev[169].cevr";
connectAttr "animCurveTL957.a" "clipLibrary1.cel[0].cev[170].cevr";
connectAttr "animCurveTU958.a" "clipLibrary1.cel[0].cev[171].cevr";
connectAttr "animCurveTU959.a" "clipLibrary1.cel[0].cev[172].cevr";
connectAttr "animCurveTU960.a" "clipLibrary1.cel[0].cev[173].cevr";
connectAttr "animCurveTA958.a" "clipLibrary1.cel[0].cev[174].cevr";
connectAttr "animCurveTA959.a" "clipLibrary1.cel[0].cev[175].cevr";
connectAttr "animCurveTA960.a" "clipLibrary1.cel[0].cev[176].cevr";
connectAttr "animCurveTL958.a" "clipLibrary1.cel[0].cev[177].cevr";
connectAttr "animCurveTL959.a" "clipLibrary1.cel[0].cev[178].cevr";
connectAttr "animCurveTL960.a" "clipLibrary1.cel[0].cev[179].cevr";
connectAttr "animCurveTU961.a" "clipLibrary1.cel[0].cev[180].cevr";
connectAttr "animCurveTU962.a" "clipLibrary1.cel[0].cev[181].cevr";
connectAttr "animCurveTU963.a" "clipLibrary1.cel[0].cev[182].cevr";
connectAttr "animCurveTA961.a" "clipLibrary1.cel[0].cev[183].cevr";
connectAttr "animCurveTA962.a" "clipLibrary1.cel[0].cev[184].cevr";
connectAttr "animCurveTA963.a" "clipLibrary1.cel[0].cev[185].cevr";
connectAttr "animCurveTL961.a" "clipLibrary1.cel[0].cev[186].cevr";
connectAttr "animCurveTL962.a" "clipLibrary1.cel[0].cev[187].cevr";
connectAttr "animCurveTL963.a" "clipLibrary1.cel[0].cev[188].cevr";
connectAttr "animCurveTU964.a" "clipLibrary1.cel[0].cev[189].cevr";
connectAttr "animCurveTU965.a" "clipLibrary1.cel[0].cev[190].cevr";
connectAttr "animCurveTU966.a" "clipLibrary1.cel[0].cev[191].cevr";
connectAttr "animCurveTA964.a" "clipLibrary1.cel[0].cev[192].cevr";
connectAttr "animCurveTA965.a" "clipLibrary1.cel[0].cev[193].cevr";
connectAttr "animCurveTA966.a" "clipLibrary1.cel[0].cev[194].cevr";
connectAttr "animCurveTL964.a" "clipLibrary1.cel[0].cev[195].cevr";
connectAttr "animCurveTL965.a" "clipLibrary1.cel[0].cev[196].cevr";
connectAttr "animCurveTL966.a" "clipLibrary1.cel[0].cev[197].cevr";
connectAttr "animCurveTU967.a" "clipLibrary1.cel[0].cev[198].cevr";
connectAttr "animCurveTU968.a" "clipLibrary1.cel[0].cev[199].cevr";
connectAttr "animCurveTU969.a" "clipLibrary1.cel[0].cev[200].cevr";
connectAttr "animCurveTA967.a" "clipLibrary1.cel[0].cev[201].cevr";
connectAttr "animCurveTA968.a" "clipLibrary1.cel[0].cev[202].cevr";
connectAttr "animCurveTA969.a" "clipLibrary1.cel[0].cev[203].cevr";
connectAttr "animCurveTL967.a" "clipLibrary1.cel[0].cev[204].cevr";
connectAttr "animCurveTL968.a" "clipLibrary1.cel[0].cev[205].cevr";
connectAttr "animCurveTL969.a" "clipLibrary1.cel[0].cev[206].cevr";
connectAttr "animCurveTU970.a" "clipLibrary1.cel[0].cev[207].cevr";
connectAttr "animCurveTU971.a" "clipLibrary1.cel[0].cev[208].cevr";
connectAttr "animCurveTU972.a" "clipLibrary1.cel[0].cev[209].cevr";
connectAttr "animCurveTA970.a" "clipLibrary1.cel[0].cev[210].cevr";
connectAttr "animCurveTA971.a" "clipLibrary1.cel[0].cev[211].cevr";
connectAttr "animCurveTA972.a" "clipLibrary1.cel[0].cev[212].cevr";
connectAttr "animCurveTL970.a" "clipLibrary1.cel[0].cev[213].cevr";
connectAttr "animCurveTL971.a" "clipLibrary1.cel[0].cev[214].cevr";
connectAttr "animCurveTL972.a" "clipLibrary1.cel[0].cev[215].cevr";
connectAttr "animCurveTU973.a" "clipLibrary1.cel[0].cev[216].cevr";
connectAttr "animCurveTU974.a" "clipLibrary1.cel[0].cev[217].cevr";
connectAttr "animCurveTU975.a" "clipLibrary1.cel[0].cev[218].cevr";
connectAttr "animCurveTA973.a" "clipLibrary1.cel[0].cev[219].cevr";
connectAttr "animCurveTA974.a" "clipLibrary1.cel[0].cev[220].cevr";
connectAttr "animCurveTA975.a" "clipLibrary1.cel[0].cev[221].cevr";
connectAttr "animCurveTL973.a" "clipLibrary1.cel[0].cev[222].cevr";
connectAttr "animCurveTL974.a" "clipLibrary1.cel[0].cev[223].cevr";
connectAttr "animCurveTL975.a" "clipLibrary1.cel[0].cev[224].cevr";
connectAttr "animCurveTU976.a" "clipLibrary1.cel[0].cev[225].cevr";
connectAttr "animCurveTU977.a" "clipLibrary1.cel[0].cev[226].cevr";
connectAttr "animCurveTU978.a" "clipLibrary1.cel[0].cev[227].cevr";
connectAttr "animCurveTA976.a" "clipLibrary1.cel[0].cev[228].cevr";
connectAttr "animCurveTA977.a" "clipLibrary1.cel[0].cev[229].cevr";
connectAttr "animCurveTA978.a" "clipLibrary1.cel[0].cev[230].cevr";
connectAttr "animCurveTL976.a" "clipLibrary1.cel[0].cev[231].cevr";
connectAttr "animCurveTL977.a" "clipLibrary1.cel[0].cev[232].cevr";
connectAttr "animCurveTL978.a" "clipLibrary1.cel[0].cev[233].cevr";
connectAttr "animCurveTU979.a" "clipLibrary1.cel[0].cev[234].cevr";
connectAttr "animCurveTU980.a" "clipLibrary1.cel[0].cev[235].cevr";
connectAttr "animCurveTU981.a" "clipLibrary1.cel[0].cev[236].cevr";
connectAttr "animCurveTA979.a" "clipLibrary1.cel[0].cev[237].cevr";
connectAttr "animCurveTA980.a" "clipLibrary1.cel[0].cev[238].cevr";
connectAttr "animCurveTA981.a" "clipLibrary1.cel[0].cev[239].cevr";
connectAttr "animCurveTL979.a" "clipLibrary1.cel[0].cev[240].cevr";
connectAttr "animCurveTL980.a" "clipLibrary1.cel[0].cev[241].cevr";
connectAttr "animCurveTL981.a" "clipLibrary1.cel[0].cev[242].cevr";
connectAttr "animCurveTU982.a" "clipLibrary1.cel[0].cev[243].cevr";
connectAttr "animCurveTU983.a" "clipLibrary1.cel[0].cev[244].cevr";
connectAttr "animCurveTU984.a" "clipLibrary1.cel[0].cev[245].cevr";
connectAttr "animCurveTA982.a" "clipLibrary1.cel[0].cev[246].cevr";
connectAttr "animCurveTA983.a" "clipLibrary1.cel[0].cev[247].cevr";
connectAttr "animCurveTA984.a" "clipLibrary1.cel[0].cev[248].cevr";
connectAttr "animCurveTL982.a" "clipLibrary1.cel[0].cev[249].cevr";
connectAttr "animCurveTL983.a" "clipLibrary1.cel[0].cev[250].cevr";
connectAttr "animCurveTL984.a" "clipLibrary1.cel[0].cev[251].cevr";
connectAttr "animCurveTU985.a" "clipLibrary1.cel[0].cev[252].cevr";
connectAttr "animCurveTU986.a" "clipLibrary1.cel[0].cev[253].cevr";
connectAttr "animCurveTU987.a" "clipLibrary1.cel[0].cev[254].cevr";
connectAttr "animCurveTA985.a" "clipLibrary1.cel[0].cev[255].cevr";
connectAttr "animCurveTA986.a" "clipLibrary1.cel[0].cev[256].cevr";
connectAttr "animCurveTA987.a" "clipLibrary1.cel[0].cev[257].cevr";
connectAttr "animCurveTL985.a" "clipLibrary1.cel[0].cev[258].cevr";
connectAttr "animCurveTL986.a" "clipLibrary1.cel[0].cev[259].cevr";
connectAttr "animCurveTL987.a" "clipLibrary1.cel[0].cev[260].cevr";
connectAttr "animCurveTU988.a" "clipLibrary1.cel[0].cev[261].cevr";
connectAttr "animCurveTU989.a" "clipLibrary1.cel[0].cev[262].cevr";
connectAttr "animCurveTU990.a" "clipLibrary1.cel[0].cev[263].cevr";
connectAttr "animCurveTA988.a" "clipLibrary1.cel[0].cev[264].cevr";
connectAttr "animCurveTA989.a" "clipLibrary1.cel[0].cev[265].cevr";
connectAttr "animCurveTA990.a" "clipLibrary1.cel[0].cev[266].cevr";
connectAttr "animCurveTL988.a" "clipLibrary1.cel[0].cev[267].cevr";
connectAttr "animCurveTL989.a" "clipLibrary1.cel[0].cev[268].cevr";
connectAttr "animCurveTL990.a" "clipLibrary1.cel[0].cev[269].cevr";
// End of bat_get_hit_from_front.ma
