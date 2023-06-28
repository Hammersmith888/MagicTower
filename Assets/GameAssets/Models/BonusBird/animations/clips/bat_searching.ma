//Maya ASCII 2013 scene
//Name: bat_searching.ma
//Last modified: Sat, Jul 12, 2014 03:57:09 PM
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
createNode animClip -n "searchingSource";
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
	setAttr ".ss" 418;
	setAttr ".se" 517;
	setAttr ".ci" no;
createNode animCurveTU -n "animCurveTU181";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU182";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU183";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA181";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  418 0 421 4.8213415145874023 429 4.1335635185241699
		 432 14.06214427947998 441 15.531326293945314 446 12.028477668762207 455 7.767996311187745
		 465 5.0410537719726563 477 5.2159795761108398 495 4.0883874893188477 507 2.6524460315704346
		 517 0;
	setAttr -s 12 ".ktl[0:11]" no yes yes yes yes yes yes yes yes yes yes 
		no;
	setAttr -s 12 ".kix[0:11]"  1 0.98783725500106812 0.94330161809921265 
		0.92916172742843628 0.99815398454666138 0.97406816482543945 0.98834186792373657 0.99882155656814575 
		0.99991154670715332 0.99936008453369141 0.99698400497436523 1;
	setAttr -s 12 ".kiy[0:11]"  0 0.15549106895923615 0.33193689584732056 
		0.3696734607219696 -0.060734778642654419 -0.2262546718120575 -0.15225081145763397 
		-0.048533063381910324 -0.013300550170242786 -0.035770770162343979 -0.077608004212379456 
		0;
	setAttr -s 12 ".kox[0:11]"  1 0.98783725500106812 0.94330161809921265 
		0.92916172742843628 0.99815398454666138 0.97406816482543945 0.98834186792373657 0.99882155656814575 
		0.99991154670715332 0.99936008453369141 0.99698400497436523 1;
	setAttr -s 12 ".koy[0:11]"  0 0.15549106895923615 0.33193689584732056 
		0.3696734607219696 -0.060734778642654419 -0.2262546718120575 -0.15225081145763397 
		-0.048533063381910324 -0.013300550170242786 -0.035770770162343979 -0.077608004212379456 
		0;
createNode animCurveTA -n "animCurveTA182";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0 421 31.773591995239258 429 23.252832412719727
		 432 20.257234573364258 441 31.707742691040039 446 45.705177307128906 455 37.067329406738281
		 465 25.937152862548828 477 22.002861022949219 517 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.74868094921112061 0.91580688953399658 
		0.95910167694091797 0.79562538862228394 0.98738539218902588 0.91672486066818237 0.96124094724655151 
		0.97886300086975098 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.66293048858642578 -0.40161904692649841 
		0.283061683177948 0.60578900575637817 0.15833540260791779 -0.39951914548873901 -0.27570989727973938 
		-0.20451708137989044 0;
	setAttr -s 10 ".kox[0:9]"  1 0.74868094921112061 0.91580688953399658 
		0.95910167694091797 0.79562538862228394 0.98738539218902588 0.91672486066818237 0.96124094724655151 
		0.97886300086975098 1;
	setAttr -s 10 ".koy[0:9]"  0 0.66293048858642578 -0.40161904692649841 
		0.283061683177948 0.60578900575637817 0.15833540260791779 -0.39951914548873901 -0.27570989727973938 
		-0.20451708137989044 0;
createNode animCurveTA -n "animCurveTA183";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  418 0 421 10.378559112548828 429 0.22596044838428497
		 432 -16.867368698120117 441 17.496425628662109 446 17.357364654541016 455 7.5343036651611328
		 465 -5.9098196029663086 477 -10.897102355957031 495 5.2814364433288574 507 6.7280769348144531
		 517 0;
	setAttr -s 12 ".ktl[0:11]" no yes yes yes yes yes yes yes yes yes yes 
		no;
	setAttr -s 12 ".kix[0:11]"  1 0.99996298551559448 0.69396775960922241 
		0.85641312599182129 0.6986728310585022 0.95833498239517212 0.88976895809173584 0.94358342885971069 
		0.98801058530807495 0.97102832794189453 0.99498206377029419 1;
	setAttr -s 12 ".kiy[0:11]"  0 0.0086042238399386406 -0.72000604867935181 
		0.51629114151000977 0.71544134616851807 -0.28564676642417908 -0.45641133189201355 
		-0.33113482594490051 0.15438595414161682 0.23896418511867523 -0.10005377978086472 
		0;
	setAttr -s 12 ".kox[0:11]"  1 0.99996298551559448 0.69396775960922241 
		0.85641312599182129 0.6986728310585022 0.95833498239517212 0.88976895809173584 0.94358342885971069 
		0.98801058530807495 0.97102832794189453 0.99498206377029419 1;
	setAttr -s 12 ".koy[0:11]"  0 0.0086042238399386406 -0.72000604867935181 
		0.51629114151000977 0.71544134616851807 -0.28564676642417908 -0.45641133189201355 
		-0.33113482594490051 0.15438595414161682 0.23896418511867523 -0.10005377978086472 
		0;
createNode animCurveTL -n "animCurveTL181";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -5.7247552871704102 517 -5.7247552871704102;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL182";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 12.644636154174805 517 12.644636154174805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL183";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 43.253993988037109 517 43.253993988037109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU184";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU185";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU186";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA184";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  418 0 433 9.0432758331298828 448 -17.765663146972656
		 517 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.97058498859405518 0.99898475408554077 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.24075886607170105 -0.045049920678138733 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.97058498859405518 0.99898475408554077 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.24075886607170105 -0.045049920678138733 
		0;
createNode animCurveTA -n "animCurveTA185";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  418 0 433 0.86088675260543823 448 -14.942700386047363
		 517 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.978920578956604 0.99999076128005981 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20424143970012665 -0.004292905330657959 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.978920578956604 0.99999076128005981 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20424143970012665 -0.004292905330657959 
		0;
createNode animCurveTA -n "animCurveTA186";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  418 0 433 -48.569595336914063 448 -6.2486042976379395
		 517 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9962155818939209 0.97189998626708984 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.086916804313659668 0.23539403080940247 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9962155818939209 0.97189998626708984 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.086916804313659668 0.23539403080940247 
		0;
createNode animCurveTL -n "animCurveTL184";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -1.9167585372924805 517 -1.9167585372924805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL185";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -5.0555992126464844 517 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL186";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 28.262805938720703 517 28.262805938720703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU187";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU188";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU189";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA187";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  418 0 421 18.352380752563477 428 4.1801977157592773
		 431 -7.4218602180480948 438 -3.5222210884094238 446 -4.8186869621276855 453 -3.7427723407745357
		 461 9.0608425140380859 475 15.630568504333496 489 5.5600481033325195 505 4.712714672088623
		 517 0;
	setAttr -s 12 ".ktl[0:11]" no yes yes yes yes yes yes yes yes yes yes 
		no;
	setAttr -s 12 ".kix[0:11]"  1 0.98501390218734741 0.67953485250473022 
		0.95169258117675781 0.9973682165145874 0.99998104572296143 0.93241328001022339 0.93820708990097046 
		0.99863135814666748 0.9885793924331665 0.9965585470199585 1;
	setAttr -s 12 ".kiy[0:11]"  0 0.17247512936592102 -0.73364323377609253 
		-0.30705273151397705 0.072502993047237396 -0.0061588315293192863 0.36139366030693054 
		0.3460744321346283 -0.05230012908577919 -0.15070103108882904 -0.082891926169395447 
		0;
	setAttr -s 12 ".kox[0:11]"  1 0.98501390218734741 0.67953485250473022 
		0.95169258117675781 0.9973682165145874 0.99998104572296143 0.93241328001022339 0.93820708990097046 
		0.99863135814666748 0.9885793924331665 0.9965585470199585 1;
	setAttr -s 12 ".koy[0:11]"  0 0.17247512936592102 -0.73364323377609253 
		-0.30705273151397705 0.072502993047237396 -0.0061588315293192863 0.36139366030693054 
		0.3460744321346283 -0.05230012908577919 -0.15070103108882904 -0.082891926169395447 
		0;
createNode animCurveTA -n "animCurveTA188";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  418 0 421 -24.421012878417969 428 -14.576563835144043
		 431 -14.687473297119141 438 -13.665263175964355 446 11.819466590881348 453 -0.37742221355438232
		 461 -16.612300872802734 475 -14.338242530822754 489 1.2866451740264893 505 1.6187169551849365
		 517 0;
	setAttr -s 12 ".ktl[0:11]" no yes yes yes yes yes yes yes yes yes yes 
		no;
	setAttr -s 12 ".kix[0:11]"  1 0.85348349809646606 0.92599242925643921 
		0.99927222728729248 0.8037598729133606 0.93753606081008911 0.7831692099571228 0.96643990278244019 
		0.96596962213516235 0.97606724500656128 0.99981474876403809 1;
	setAttr -s 12 ".kiy[0:11]"  0 -0.52111977338790894 0.37754210829734802 
		0.038144756108522415 0.59495377540588379 0.34788820147514343 -0.62180864810943604 
		-0.25689277052879333 0.25865551829338074 0.21746891736984253 -0.019244614988565445 
		0;
	setAttr -s 12 ".kox[0:11]"  1 0.85348349809646606 0.92599242925643921 
		0.99927222728729248 0.8037598729133606 0.93753606081008911 0.7831692099571228 0.96643990278244019 
		0.96596962213516235 0.97606724500656128 0.99981474876403809 1;
	setAttr -s 12 ".koy[0:11]"  0 -0.52111977338790894 0.37754210829734802 
		0.038144756108522415 0.59495377540588379 0.34788820147514343 -0.62180864810943604 
		-0.25689277052879333 0.25865551829338074 0.21746891736984253 -0.019244614988565445 
		0;
createNode animCurveTA -n "animCurveTA189";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  418 0 421 28.261690139770508 428 14.699428558349611
		 431 3.92168116569519 438 -1.8845199346542358 446 10.174643516540527 453 30.265302658081055
		 461 22.568632125854492 475 25.780160903930664 489 7.1695270538330069 505 6.6491103172302246
		 517 0;
	setAttr -s 12 ".ktl[0:11]" no yes yes yes yes yes yes yes yes yes yes 
		no;
	setAttr -s 12 ".kix[0:11]"  1 0.85152840614318848 0.70022934675216675 
		0.82128399610519409 0.98509472608566284 0.74411040544509888 0.94500023126602173 0.99637353420257568 
		0.97447627782821655 0.96612584590911865 0.99429726600646973 1;
	setAttr -s 12 ".kiy[0:11]"  0 0.52430850267410278 -0.71391791105270386 
		-0.57051956653594971 0.17201292514801025 0.6680566668510437 0.32706966996192932 -0.085087239742279053 
		-0.22449028491973877 -0.2580714225769043 -0.10664423555135727 0;
	setAttr -s 12 ".kox[0:11]"  1 0.85152840614318848 0.70022934675216675 
		0.82128399610519409 0.98509472608566284 0.74411040544509888 0.94500023126602173 0.99637353420257568 
		0.97447627782821655 0.96612584590911865 0.99429726600646973 1;
	setAttr -s 12 ".koy[0:11]"  0 0.52430850267410278 -0.71391791105270386 
		-0.57051956653594971 0.17201292514801025 0.6680566668510437 0.32706966996192932 -0.085087239742279053 
		-0.22449028491973877 -0.2580714225769043 -0.10664423555135727 0;
createNode animCurveTL -n "animCurveTL187";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -5.7247552871704102 517 -5.7247552871704102;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL188";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 12.644636154174805 517 12.644636154174805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL189";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -43.253993988037109 517 -43.253993988037109;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU190";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU191";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU192";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA190";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0.0048254411667585373 420 0 430 -1.5321379899978638
		 434 0.93315118551254272 441 0.8403509259223938 455 -4.9928140640258789 467 -5.2649822235107422
		 488 -0.47966757416725159 505 -4.4506721496582031 517 0.0048254411667585373;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.99856400489807129 0.99961048364639282 
		0.99594378471374512 0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 
		0.99997556209564209 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.053573101758956909 0.027908915653824806 
		0.089977577328681946 -0.11738576740026474 -0.097888924181461334 0.057192981243133545 
		0.0089758895337581635 0.0069979047402739525 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99856400489807129 0.99961048364639282 
		0.99594378471374512 0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 
		0.99997556209564209 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.053573101758956909 0.027908915653824806 
		0.089977577328681946 -0.11738576740026474 -0.097888924181461334 0.057192981243133545 
		0.0089758895337581635 0.0069979047402739525 0;
createNode animCurveTA -n "animCurveTA191";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  418 1.5292341709136963 420 0 423 31.770833969116207
		 430 23.676351547241211 434 -17.918659210205078 441 -16.291439056396484 455 31.085165023803714
		 467 33.996292114257813 488 -4.0022234916687012 505 30.884540557861328 517 1.5292341709136963;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes no;
	setAttr -s 11 ".kix[0:10]"  1 0.36714476346969604 0.71002805233001709 
		0.46725380420684814 0.54912036657333374 0.71512001752853394 0.77699851989746094 0.91349583864212036 
		0.9994121789932251 0.99682343006134033 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.93016374111175537 0.70417338609695435 
		-0.88412326574325562 -0.83574336767196655 0.69900166988372803 0.62950247526168823 
		-0.40684807300567627 -0.034281108528375626 0.079643234610557556 0;
	setAttr -s 11 ".kox[0:10]"  1 0.36714476346969604 0.71002805233001709 
		0.46725380420684814 0.54912036657333374 0.71512001752853394 0.77699851989746094 0.91349583864212036 
		0.9994121789932251 0.99682343006134033 1;
	setAttr -s 11 ".koy[0:10]"  0 0.93016374111175537 0.70417338609695435 
		-0.88412326574325562 -0.83574336767196655 0.69900166988372803 0.62950247526168823 
		-0.40684807300567627 -0.034281108528375626 0.079643234610557556 0;
createNode animCurveTA -n "animCurveTA192";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 15 ".ktv[0:14]"  418 1.0246820449829102 420 0.13983544707298279
		 430 1.8805303573608401 434 -5.2345595359802246 441 1.381087064743042 448 -9.3388757705688477
		 455 -4.5889029502868652 467 -0.45936030149459839 475 -8.0459089279174805 477 -9.0615434646606445
		 488 -6.1651921272277832 496 -1.1703490018844604 505 -6.1284337043762207 510 -10.451559066772461
		 517 1.0246820449829102;
	setAttr -s 15 ".ktl[0:14]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes no;
	setAttr -s 15 ".kix[0:14]"  1 0.99955403804779053 0.98731684684753418 
		0.99981921911239624 0.99254411458969116 0.98441910743713379 0.98137277364730835 0.99738913774490356 
		0.94078904390335083 0.9981689453125 0.98520201444625854 0.9999995231628418 0.9635390043258667 
		0.97021305561065674 1;
	setAttr -s 15 ".kiy[0:14]"  0 0.029861418530344963 -0.15876190364360809 
		-0.019015295431017876 -0.12188553810119629 -0.17583844065666199 0.19211336970329285 
		-0.07221444696187973 -0.33899253606796265 0.06048835813999176 0.17139706015586853 
		0.00090572616318240762 -0.26756784319877625 0.24225328862667084 0;
	setAttr -s 15 ".kox[0:14]"  1 0.99955403804779053 0.98731684684753418 
		0.99981921911239624 0.99254411458969116 0.98441910743713379 0.98137277364730835 0.99738913774490356 
		0.94078904390335083 0.9981689453125 0.98520201444625854 0.9999995231628418 0.9635390043258667 
		0.97021305561065674 1;
	setAttr -s 15 ".koy[0:14]"  0 0.029861418530344963 -0.15876190364360809 
		-0.019015295431017876 -0.12188553810119629 -0.17583844065666199 0.19211336970329285 
		-0.07221444696187973 -0.33899253606796265 0.06048835813999176 0.17139706015586853 
		0.00090572616318240762 -0.26756784319877625 0.24225328862667084 0;
createNode animCurveTL -n "animCurveTL190";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -0.72905689477920532 517 -0.72905689477920532;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL191";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -19.141372680664063 517 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL192";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 23.549764633178711 517 23.549764633178711;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU193";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU194";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU195";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA193";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0 426 -1.5321379899978638 430 0.93315118551254272
		 437 0.8403509259223938 451 -4.9928140640258789 463 -5.2649822235107422 484 -0.47966757416725159
		 501 -4.4506721496582031 515 0 517 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.99946993589401245 0.99594378471374512 
		0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 0.99997895956039429 
		0.99328005313873291 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.032555852085351944 0.089977577328681946 
		-0.11738576740026474 -0.097889117896556854 0.057192981243133545 0.0089758802205324173 
		0.0064812339842319489 0.11573544144630432 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99946993589401245 0.99594378471374512 
		0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 0.99997895956039429 
		0.99328005313873291 1;
	setAttr -s 10 ".koy[0:9]"  0 0.032555852085351944 0.089977577328681946 
		-0.11738576740026474 -0.097889117896556854 0.057192981243133545 0.0089758802205324173 
		0.0064812339842319489 0.11573544144630432 0;
createNode animCurveTA -n "animCurveTA194";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0 426 23.676351547241211 430 -17.918659210205078
		 437 -16.291439056396484 451 31.085165023803714 463 33.996292114257813 484 -4.0022234916687012
		 501 30.884540557861328 515 0 517 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.84781563282012939 0.54912036657333374 
		0.71512001752853394 0.77699804306030273 0.91349583864212036 0.9994121789932251 0.99854093790054321 
		0.77761280536651611 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.53029102087020874 -0.83574336767196655 
		0.69900166988372803 0.62950307130813599 -0.40684807300567627 -0.034281067550182343 
		0.053999975323677063 -0.62874352931976318 0;
	setAttr -s 10 ".kox[0:9]"  1 0.84781563282012939 0.54912036657333374 
		0.71512001752853394 0.77699804306030273 0.91349583864212036 0.9994121789932251 0.99854093790054321 
		0.77761280536651611 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.53029102087020874 -0.83574336767196655 
		0.69900166988372803 0.62950307130813599 -0.40684807300567627 -0.034281067550182343 
		0.053999975323677063 -0.62874352931976318 0;
createNode animCurveTA -n "animCurveTA195";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 16 ".ktv[0:15]"  418 12.527528762817383 426 -0.05761863291263581
		 430 -7.4068713188171387 437 -0.44974493980407715 444 -9.8721904754638672 448 -7.5068106651306161
		 451 -4.5804629325866699 463 -0.36630755662918091 473 -8.7783699035644531 475 -8.8146018981933594
		 484 -4.9779157638549805 492 0.25922513008117676 501 -4.8833713531494141 506 -9.5181407928466797
		 515 0.063529007136821747 517 12.527528762817383;
	setAttr -s 16 ".ktl[0:15]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes no;
	setAttr -s 16 ".kix[0:15]"  1 0.82083219289779663 0.99988847970962524 
		0.99729061126708984 0.96573632955551147 0.95334494113922119 0.98069357872009277 0.99682104587554932 
		0.95916181802749634 0.98968946933746338 0.97590601444244385 0.99999725818634033 0.95977491140365601 
		0.9892231822013855 0.76589351892471313 1;
	setAttr -s 16 ".kiy[0:15]"  0 -0.57116937637329102 -0.014930450357496738 
		-0.073562227189540863 -0.25952538847923279 0.30188325047492981 0.19555070996284485 
		-0.079673752188682556 -0.28285789489746094 0.14322920143604279 0.2181914895772934 
		0.0023295651189982891 -0.28077045083045959 0.14641566574573517 0.64296740293502808 
		0;
	setAttr -s 16 ".kox[0:15]"  1 0.82083219289779663 0.99988847970962524 
		0.99729061126708984 0.96573632955551147 0.95334494113922119 0.98069357872009277 0.99682104587554932 
		0.95916181802749634 0.98968946933746338 0.97590601444244385 0.99999725818634033 0.95977491140365601 
		0.9892231822013855 0.76589351892471313 1;
	setAttr -s 16 ".koy[0:15]"  0 -0.57116937637329102 -0.014930450357496738 
		-0.073562227189540863 -0.25952538847923279 0.30188325047492981 0.19555070996284485 
		-0.079673752188682556 -0.28285789489746094 0.14322920143604279 0.2181914895772934 
		0.0023295651189982891 -0.28077045083045959 0.14641566574573517 0.64296740293502808 
		0;
createNode animCurveTL -n "animCurveTL193";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -36.1805419921875 517 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL194";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 7.3658723831176758 517 7.3658723831176758;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL195";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 41.597393035888672 517 41.597393035888672;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU196";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU197";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU198";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA196";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0.0048254411667585373 420 0 430 -1.5321379899978638
		 434 0.93315118551254272 441 0.8403509259223938 455 -4.9928140640258789 467 -5.2649822235107422
		 488 -0.47966757416725159 505 -4.4506721496582031 517 0.0048254411667585373;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.99856400489807129 0.99961048364639282 
		0.99594378471374512 0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 
		0.99997556209564209 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.053573101758956909 0.027908915653824806 
		0.089977577328681946 -0.11738576740026474 -0.097888924181461334 0.057192981243133545 
		0.0089758895337581635 0.0069979047402739525 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99856400489807129 0.99961048364639282 
		0.99594378471374512 0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 
		0.99997556209564209 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.053573101758956909 0.027908915653824806 
		0.089977577328681946 -0.11738576740026474 -0.097888924181461334 0.057192981243133545 
		0.0089758895337581635 0.0069979047402739525 0;
createNode animCurveTA -n "animCurveTA197";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  418 1.5292341709136963 420 0 423 31.770833969116207
		 430 23.676351547241211 434 -17.918659210205078 441 -16.291439056396484 455 31.085165023803714
		 467 33.996292114257813 488 -4.0022234916687012 505 30.884540557861328 517 1.5292341709136963;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes no;
	setAttr -s 11 ".kix[0:10]"  1 0.36714476346969604 0.71002805233001709 
		0.46725380420684814 0.54912036657333374 0.71512001752853394 0.77699851989746094 0.91349583864212036 
		0.9994121789932251 0.99682343006134033 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.93016374111175537 0.70417338609695435 
		-0.88412326574325562 -0.83574336767196655 0.69900166988372803 0.62950247526168823 
		-0.40684807300567627 -0.034281108528375626 0.079643234610557556 0;
	setAttr -s 11 ".kox[0:10]"  1 0.36714476346969604 0.71002805233001709 
		0.46725380420684814 0.54912036657333374 0.71512001752853394 0.77699851989746094 0.91349583864212036 
		0.9994121789932251 0.99682343006134033 1;
	setAttr -s 11 ".koy[0:10]"  0 0.93016374111175537 0.70417338609695435 
		-0.88412326574325562 -0.83574336767196655 0.69900166988372803 0.62950247526168823 
		-0.40684807300567627 -0.034281108528375626 0.079643234610557556 0;
createNode animCurveTA -n "animCurveTA198";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 15 ".ktv[0:14]"  418 1.0246820449829102 420 0.13983544707298279
		 430 1.8805303573608401 434 -5.2345595359802246 441 1.381087064743042 448 -9.3388757705688477
		 455 -4.5889029502868652 467 -0.45936030149459839 475 -8.0459089279174805 477 -9.0615434646606445
		 488 -6.1651921272277832 496 -1.1703490018844604 505 -6.1284337043762207 510 -10.451559066772461
		 517 1.0246820449829102;
	setAttr -s 15 ".ktl[0:14]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes no;
	setAttr -s 15 ".kix[0:14]"  1 0.99955403804779053 0.98731684684753418 
		0.99981921911239624 0.99254411458969116 0.98441910743713379 0.98137277364730835 0.99738913774490356 
		0.94078904390335083 0.9981689453125 0.98520201444625854 0.9999995231628418 0.9635390043258667 
		0.97021305561065674 1;
	setAttr -s 15 ".kiy[0:14]"  0 0.029861418530344963 -0.15876190364360809 
		-0.019015295431017876 -0.12188553810119629 -0.17583844065666199 0.19211336970329285 
		-0.07221444696187973 -0.33899253606796265 0.06048835813999176 0.17139706015586853 
		0.00090572616318240762 -0.26756784319877625 0.24225328862667084 0;
	setAttr -s 15 ".kox[0:14]"  1 0.99955403804779053 0.98731684684753418 
		0.99981921911239624 0.99254411458969116 0.98441910743713379 0.98137277364730835 0.99738913774490356 
		0.94078904390335083 0.9981689453125 0.98520201444625854 0.9999995231628418 0.9635390043258667 
		0.97021305561065674 1;
	setAttr -s 15 ".koy[0:14]"  0 0.029861418530344963 -0.15876190364360809 
		-0.019015295431017876 -0.12188553810119629 -0.17583844065666199 0.19211336970329285 
		-0.07221444696187973 -0.33899253606796265 0.06048835813999176 0.17139706015586853 
		0.00090572616318240762 -0.26756784319877625 0.24225328862667084 0;
createNode animCurveTL -n "animCurveTL196";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -0.11375267058610916 517 -0.11375267058610916;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL197";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -0.067464433610439301 517 -0.067464433610439301;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL198";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 41.135360717773437 517 41.135360717773437;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU199";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU200";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU201";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA199";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0 426 -1.5321379899978638 430 0.93315118551254272
		 437 0.8403509259223938 451 -4.9928140640258789 463 -5.2649822235107422 484 -0.47966757416725159
		 501 -4.4506721496582031 515 0 517 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.99946993589401245 0.99594378471374512 
		0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 0.99997895956039429 
		0.99328005313873291 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.032555852085351944 0.089977577328681946 
		-0.11738576740026474 -0.097889117896556854 0.057192981243133545 0.0089758802205324173 
		0.0064812339842319489 0.11573544144630432 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99946993589401245 0.99594378471374512 
		0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 0.99997895956039429 
		0.99328005313873291 1;
	setAttr -s 10 ".koy[0:9]"  0 0.032555852085351944 0.089977577328681946 
		-0.11738576740026474 -0.097889117896556854 0.057192981243133545 0.0089758802205324173 
		0.0064812339842319489 0.11573544144630432 0;
createNode animCurveTA -n "animCurveTA200";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0 426 23.676351547241211 430 -17.918659210205078
		 437 -16.291439056396484 451 31.085165023803714 463 33.996292114257813 484 -4.0022234916687012
		 501 30.884540557861328 515 0 517 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.84781563282012939 0.54912036657333374 
		0.71512001752853394 0.77699804306030273 0.91349583864212036 0.9994121789932251 0.99854093790054321 
		0.77761280536651611 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.53029102087020874 -0.83574336767196655 
		0.69900166988372803 0.62950307130813599 -0.40684807300567627 -0.034281067550182343 
		0.053999975323677063 -0.62874352931976318 0;
	setAttr -s 10 ".kox[0:9]"  1 0.84781563282012939 0.54912036657333374 
		0.71512001752853394 0.77699804306030273 0.91349583864212036 0.9994121789932251 0.99854093790054321 
		0.77761280536651611 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.53029102087020874 -0.83574336767196655 
		0.69900166988372803 0.62950307130813599 -0.40684807300567627 -0.034281067550182343 
		0.053999975323677063 -0.62874352931976318 0;
createNode animCurveTA -n "animCurveTA201";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 16 ".ktv[0:15]"  418 12.527528762817383 426 -0.05761863291263581
		 430 -7.4068713188171387 437 -0.44974493980407715 444 -9.8721904754638672 448 -7.5068106651306161
		 451 -4.5804629325866699 463 -0.36630755662918091 473 -8.7783699035644531 475 -8.8146018981933594
		 484 -4.9779157638549805 492 0.25922513008117676 501 -4.8833713531494141 506 -9.5181407928466797
		 515 0.063529007136821747 517 12.527528762817383;
	setAttr -s 16 ".ktl[0:15]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes no;
	setAttr -s 16 ".kix[0:15]"  1 0.82083219289779663 0.99988847970962524 
		0.99729061126708984 0.96573632955551147 0.95334494113922119 0.98069357872009277 0.99682104587554932 
		0.95916181802749634 0.98968946933746338 0.97590601444244385 0.99999725818634033 0.95977491140365601 
		0.9892231822013855 0.76589351892471313 1;
	setAttr -s 16 ".kiy[0:15]"  0 -0.57116937637329102 -0.014930450357496738 
		-0.073562227189540863 -0.25952538847923279 0.30188325047492981 0.19555070996284485 
		-0.079673752188682556 -0.28285789489746094 0.14322920143604279 0.2181914895772934 
		0.0023295651189982891 -0.28077045083045959 0.14641566574573517 0.64296740293502808 
		0;
	setAttr -s 16 ".kox[0:15]"  1 0.82083219289779663 0.99988847970962524 
		0.99729061126708984 0.96573632955551147 0.95334494113922119 0.98069357872009277 0.99682104587554932 
		0.95916181802749634 0.98968946933746338 0.97590601444244385 0.99999725818634033 0.95977491140365601 
		0.9892231822013855 0.76589351892471313 1;
	setAttr -s 16 ".koy[0:15]"  0 -0.57116937637329102 -0.014930450357496738 
		-0.073562227189540863 -0.25952538847923279 0.30188325047492981 0.19555070996284485 
		-0.079673752188682556 -0.28285789489746094 0.14322920143604279 0.2181914895772934 
		0.0023295651189982891 -0.28077045083045959 0.14641566574573517 0.64296740293502808 
		0;
createNode animCurveTL -n "animCurveTL199";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -54.695327758789062 517 -54.695327758789062;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL200";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 3.2521772384643555 517 3.2521772384643555;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL201";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU202";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU203";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU204";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA202";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0.0048254411667585373 420 0 430 -1.5321379899978638
		 434 0.93315118551254272 441 0.8403509259223938 455 -4.9928140640258789 467 -5.2649822235107422
		 488 -0.47966757416725159 505 -4.4506721496582031 517 0.0048254411667585373;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes no;
	setAttr -s 10 ".kix[0:9]"  1 0.99856400489807129 0.99961048364639282 
		0.99594378471374512 0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 
		0.99997556209564209 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.053573101758956909 0.027908915653824806 
		0.089977577328681946 -0.11738576740026474 -0.097888924181461334 0.057192981243133545 
		0.0089758895337581635 0.0069979047402739525 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99856400489807129 0.99961048364639282 
		0.99594378471374512 0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 
		0.99997556209564209 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.053573101758956909 0.027908915653824806 
		0.089977577328681946 -0.11738576740026474 -0.097888924181461334 0.057192981243133545 
		0.0089758895337581635 0.0069979047402739525 0;
createNode animCurveTA -n "animCurveTA203";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  418 1.5292341709136963 420 0 423 31.770833969116207
		 430 23.676351547241211 434 -17.918659210205078 441 -16.291439056396484 455 31.085165023803714
		 467 33.996292114257813 488 -4.0022234916687012 505 30.884540557861328 517 1.5292341709136963;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes no;
	setAttr -s 11 ".kix[0:10]"  1 0.36714476346969604 0.71002805233001709 
		0.46725380420684814 0.54912036657333374 0.71512001752853394 0.77699851989746094 0.91349583864212036 
		0.9994121789932251 0.99682343006134033 1;
	setAttr -s 11 ".kiy[0:10]"  0 0.93016374111175537 0.70417338609695435 
		-0.88412326574325562 -0.83574336767196655 0.69900166988372803 0.62950247526168823 
		-0.40684807300567627 -0.034281108528375626 0.079643234610557556 0;
	setAttr -s 11 ".kox[0:10]"  1 0.36714476346969604 0.71002805233001709 
		0.46725380420684814 0.54912036657333374 0.71512001752853394 0.77699851989746094 0.91349583864212036 
		0.9994121789932251 0.99682343006134033 1;
	setAttr -s 11 ".koy[0:10]"  0 0.93016374111175537 0.70417338609695435 
		-0.88412326574325562 -0.83574336767196655 0.69900166988372803 0.62950247526168823 
		-0.40684807300567627 -0.034281108528375626 0.079643234610557556 0;
createNode animCurveTA -n "animCurveTA204";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 15 ".ktv[0:14]"  418 1.0246820449829102 420 0.13983544707298279
		 430 1.8805303573608401 434 -5.2345595359802246 441 1.381087064743042 448 -9.3388757705688477
		 455 -4.5889029502868652 467 -0.45936030149459839 475 -8.0459089279174805 477 -9.0615434646606445
		 488 -6.1651921272277832 496 -1.1703490018844604 505 -6.1284337043762207 510 -10.451559066772461
		 517 1.0246820449829102;
	setAttr -s 15 ".ktl[0:14]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes no;
	setAttr -s 15 ".kix[0:14]"  1 0.99955403804779053 0.98731684684753418 
		0.99981921911239624 0.99254411458969116 0.98441910743713379 0.98137277364730835 0.99738913774490356 
		0.94078904390335083 0.9981689453125 0.98520201444625854 0.9999995231628418 0.9635390043258667 
		0.97021305561065674 1;
	setAttr -s 15 ".kiy[0:14]"  0 0.029861418530344963 -0.15876190364360809 
		-0.019015295431017876 -0.12188553810119629 -0.17583844065666199 0.19211336970329285 
		-0.07221444696187973 -0.33899253606796265 0.06048835813999176 0.17139706015586853 
		0.00090572616318240762 -0.26756784319877625 0.24225328862667084 0;
	setAttr -s 15 ".kox[0:14]"  1 0.99955403804779053 0.98731684684753418 
		0.99981921911239624 0.99254411458969116 0.98441910743713379 0.98137277364730835 0.99738913774490356 
		0.94078904390335083 0.9981689453125 0.98520201444625854 0.9999995231628418 0.9635390043258667 
		0.97021305561065674 1;
	setAttr -s 15 ".koy[0:14]"  0 0.029861418530344963 -0.15876190364360809 
		-0.019015295431017876 -0.12188553810119629 -0.17583844065666199 0.19211336970329285 
		-0.07221444696187973 -0.33899253606796265 0.06048835813999176 0.17139706015586853 
		0.00090572616318240762 -0.26756784319877625 0.24225328862667084 0;
createNode animCurveTL -n "animCurveTL202";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -2.6052179336547852 517 -2.6052179336547852;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL203";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -19.141372680664063 517 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL204";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 23.227632522583008 517 23.227632522583008;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU205";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU206";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU207";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA205";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0 426 -1.5321379899978638 430 0.93315118551254272
		 437 0.8403509259223938 451 -4.9928140640258789 463 -5.2649822235107422 484 -0.47966757416725159
		 501 -4.4506721496582031 515 0 517 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.99946993589401245 0.99594378471374512 
		0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 0.99997895956039429 
		0.99328005313873291 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.032555852085351944 0.089977577328681946 
		-0.11738576740026474 -0.097889117896556854 0.057192981243133545 0.0089758802205324173 
		0.0064812339842319489 0.11573544144630432 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99946993589401245 0.99594378471374512 
		0.99308633804321289 0.99519729614257813 0.998363196849823 0.99995970726013184 0.99997895956039429 
		0.99328005313873291 1;
	setAttr -s 10 ".koy[0:9]"  0 0.032555852085351944 0.089977577328681946 
		-0.11738576740026474 -0.097889117896556854 0.057192981243133545 0.0089758802205324173 
		0.0064812339842319489 0.11573544144630432 0;
createNode animCurveTA -n "animCurveTA206";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0 426 23.676351547241211 430 -17.918659210205078
		 437 -16.291439056396484 451 31.085165023803714 463 33.996292114257813 484 -4.0022234916687012
		 501 30.884540557861328 515 0 517 0;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.84781563282012939 0.54912036657333374 
		0.71512001752853394 0.77699804306030273 0.91349583864212036 0.9994121789932251 0.99854093790054321 
		0.77761280536651611 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.53029102087020874 -0.83574336767196655 
		0.69900166988372803 0.62950307130813599 -0.40684807300567627 -0.034281067550182343 
		0.053999975323677063 -0.62874352931976318 0;
	setAttr -s 10 ".kox[0:9]"  1 0.84781563282012939 0.54912036657333374 
		0.71512001752853394 0.77699804306030273 0.91349583864212036 0.9994121789932251 0.99854093790054321 
		0.77761280536651611 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.53029102087020874 -0.83574336767196655 
		0.69900166988372803 0.62950307130813599 -0.40684807300567627 -0.034281067550182343 
		0.053999975323677063 -0.62874352931976318 0;
createNode animCurveTA -n "animCurveTA207";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 16 ".ktv[0:15]"  418 12.527528762817383 426 -0.05761863291263581
		 430 -7.4068713188171387 437 -0.44974493980407715 444 -9.8721904754638672 448 -7.5068106651306161
		 451 -4.5804629325866699 463 -0.36630755662918091 473 -8.7783699035644531 475 -8.8146018981933594
		 484 -4.9779157638549805 492 0.25922513008117676 501 -4.8833713531494141 506 -9.5181407928466797
		 515 0.063529007136821747 517 12.527528762817383;
	setAttr -s 16 ".ktl[0:15]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes no;
	setAttr -s 16 ".kix[0:15]"  1 0.82083219289779663 0.99988847970962524 
		0.99729061126708984 0.96573632955551147 0.95334494113922119 0.98069357872009277 0.99682104587554932 
		0.95916181802749634 0.98968946933746338 0.97590601444244385 0.99999725818634033 0.95977491140365601 
		0.9892231822013855 0.76589351892471313 1;
	setAttr -s 16 ".kiy[0:15]"  0 -0.57116937637329102 -0.014930450357496738 
		-0.073562227189540863 -0.25952538847923279 0.30188325047492981 0.19555070996284485 
		-0.079673752188682556 -0.28285789489746094 0.14322920143604279 0.2181914895772934 
		0.0023295651189982891 -0.28077045083045959 0.14641566574573517 0.64296740293502808 
		0;
	setAttr -s 16 ".kox[0:15]"  1 0.82083219289779663 0.99988847970962524 
		0.99729061126708984 0.96573632955551147 0.95334494113922119 0.98069357872009277 0.99682104587554932 
		0.95916181802749634 0.98968946933746338 0.97590601444244385 0.99999725818634033 0.95977491140365601 
		0.9892231822013855 0.76589351892471313 1;
	setAttr -s 16 ".koy[0:15]"  0 -0.57116937637329102 -0.014930450357496738 
		-0.073562227189540863 -0.25952538847923279 0.30188325047492981 0.19555070996284485 
		-0.079673752188682556 -0.28285789489746094 0.14322920143604279 0.2181914895772934 
		0.0023295651189982891 -0.28077045083045959 0.14641566574573517 0.64296740293502808 
		0;
createNode animCurveTL -n "animCurveTL205";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -36.1805419921875 517 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL206";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 7.3658723831176758 517 7.3658723831176758;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL207";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -41.399761199951172 517 -41.399761199951172;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU208";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU209";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU210";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA208";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA209";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA210";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL208";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 22.400806427001953 517 22.400806427001953;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL209";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 10.647112846374512 517 10.647112846374512;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL210";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU211";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU212";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU213";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA211";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA212";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA213";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL211";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 35.083248138427734 517 35.083248138427734;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL212";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 30.643020629882813 517 30.643020629882813;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL213";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 36.804916381835937 517 36.804916381835937;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU214";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU215";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU216";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA214";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA215";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA216";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL214";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 35.083248138427734 517 35.083248138427734;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL215";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 30.643020629882813 517 30.643020629882813;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL216";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -36.361770629882813 517 -36.361770629882813;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU217";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU218";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU219";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA217";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA218";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA219";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL217";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -5.8221402168273926 517 -5.8221402168273926;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL218";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -10.433219909667969 517 -10.433219909667969;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL219";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -28.427871704101563 517 -28.427871704101563;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU220";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU221";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU222";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA220";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 22 ".ktv[0:21]"  418 0 421 16.21827507019043 424 21.10291862487793
		 429 6.3519806861877441 433 -18.106809616088867 438 20.347024917602539 443 -18.106809616088867
		 448 20.347024917602539 453 -18.106809616088867 458 20.347024917602539 463 -18.106809616088867
		 468 20.347024917602539 473 -18.106809616088867 478 20.347024917602539 483 -18.106809616088867
		 488 20.347024917602539 493 -18.106809616088867 498 20.347024917602539 503 -18.106809616088867
		 508 20.347024917602539 513 -15.951205253601072 517 0;
	setAttr -s 22 ".ktl[0:21]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes no;
	setAttr -s 22 ".kix[0:21]"  1 0.5616115927696228 0.8884512186050415 
		0.48055413365364075 0.83792293071746826 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99594831466674805 
		0.72608858346939087 1;
	setAttr -s 22 ".kiy[0:21]"  0 0.82740098237991333 -0.45897117257118225 
		-0.87696510553359985 0.54578858613967896 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.089928016066551208 
		-0.68760114908218384 0;
	setAttr -s 22 ".kox[0:21]"  1 0.5616115927696228 0.8884512186050415 
		0.48055413365364075 0.83792293071746826 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99594831466674805 
		0.72608858346939087 1;
	setAttr -s 22 ".koy[0:21]"  0 0.82740098237991333 -0.45897117257118225 
		-0.87696510553359985 0.54578858613967896 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.089928016066551208 
		-0.68760114908218384 0;
createNode animCurveTA -n "animCurveTA221";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 22 ".ktv[0:21]"  418 0 421 9.7227239608764648 424 9.9817295074462891
		 429 11.125818252563477 433 16.056190490722656 438 8.6761045455932617 443 16.056190490722656
		 448 8.6761045455932617 453 16.056190490722656 458 8.6761045455932617 463 16.056190490722656
		 468 8.6761045455932617 473 16.056190490722656 478 8.6761045455932617 483 16.056190490722656
		 488 8.6761045455932617 493 16.056190490722656 498 8.6761045455932617 503 16.056190490722656
		 508 8.6761045455932617 513 20.091135025024414 517 0;
	setAttr -s 22 ".ktl[0:21]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes no;
	setAttr -s 22 ".kix[0:21]"  1 0.82044190168380737 0.99731224775314331 
		0.96228176355361938 0.99356299638748169 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.98601573705673218 
		0.92725527286529541 1;
	setAttr -s 22 ".kiy[0:21]"  0 0.57172989845275879 0.073268227279186249 
		0.272054523229599 -0.11328092962503433 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.16665208339691162 
		-0.3744296133518219 0;
	setAttr -s 22 ".kox[0:21]"  1 0.82044190168380737 0.99731224775314331 
		0.96228176355361938 0.99356299638748169 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.98601573705673218 
		0.92725527286529541 1;
	setAttr -s 22 ".koy[0:21]"  0 0.57172989845275879 0.073268227279186249 
		0.272054523229599 -0.11328092962503433 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.16665208339691162 
		-0.3744296133518219 0;
createNode animCurveTA -n "animCurveTA222";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 22 ".ktv[0:21]"  418 0 421 18.709156036376953 424 17.896600723266602
		 429 16.763090133666992 433 6.1861891746520996 438 18.350570678710938 443 6.1861891746520996
		 448 18.350570678710938 453 6.1861891746520996 458 18.350570678710938 463 6.1861891746520996
		 468 18.350570678710938 473 6.1861891746520996 478 18.350570678710938 483 6.1861891746520996
		 488 18.350570678710938 493 6.1861891746520996 498 18.350570678710938 503 6.1861891746520996
		 508 18.350570678710938 513 5.0850110054016113 517 0;
	setAttr -s 22 ".ktl[0:21]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes no;
	setAttr -s 22 ".kix[0:21]"  1 0.62487226724624634 0.99484878778457642 
		0.87805324792861938 0.99728167057037354 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99893790483474731 
		0.76040834188461304 1;
	setAttr -s 22 ".kiy[0:21]"  0 0.78072690963745117 -0.1013706848025322 
		-0.47856301069259644 0.073683805763721466 0 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.046077128499746323 
		-0.6494452953338623 0;
	setAttr -s 22 ".kox[0:21]"  1 0.62487226724624634 0.99484878778457642 
		0.87805324792861938 0.99728167057037354 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99893790483474731 
		0.76040834188461304 1;
	setAttr -s 22 ".koy[0:21]"  0 0.78072690963745117 -0.1013706848025322 
		-0.47856301069259644 0.073683805763721466 0 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.046077128499746323 
		-0.6494452953338623 0;
createNode animCurveTL -n "animCurveTL220";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 11.41090202331543 517 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL221";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -0.91886520385742188 517 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL222";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -13.740226745605469 517 -13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU223";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU224";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU225";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA223";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 22 ".ktv[0:21]"  418 0 420 17.156778335571289 423 22.041421890258789
		 428 7.2904853820800781 432 -17.168304443359375 437 21.285530090332031 442 -17.168304443359375
		 447 21.285530090332031 452 -17.168304443359375 457 21.285530090332031 462 -17.168304443359375
		 467 21.285530090332031 472 -17.168304443359375 477 21.285530090332031 482 -17.168304443359375
		 487 21.285530090332031 492 -17.168304443359375 497 21.285530090332031 502 -17.168304443359375
		 507 21.285530090332031 512 -15.012700080871582 517 0;
	setAttr -s 22 ".ktl[0:21]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes no;
	setAttr -s 22 ".kix[0:21]"  1 0.47620764374732971 0.8884512186050415 
		0.48055413365364075 0.83792293071746826 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99594831466674805 
		0.74640083312988281 1;
	setAttr -s 22 ".kiy[0:21]"  0 0.87933284044265747 -0.45897117257118225 
		-0.87696510553359985 0.54578858613967896 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.089927591383457184 
		-0.66549664735794067 0;
	setAttr -s 22 ".kox[0:21]"  1 0.47620764374732971 0.8884512186050415 
		0.48055413365364075 0.83792293071746826 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99594831466674805 
		0.74640083312988281 1;
	setAttr -s 22 ".koy[0:21]"  0 0.87933284044265747 -0.45897117257118225 
		-0.87696510553359985 0.54578858613967896 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.089927591383457184 
		-0.66549664735794067 0;
createNode animCurveTA -n "animCurveTA224";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 22 ".ktv[0:21]"  418 0 420 6.0180997848510742 423 6.2771053314208984
		 428 7.421194076538085 432 12.351565361022949 437 4.9714803695678711 442 12.351565361022949
		 447 4.9714803695678711 452 12.351565361022949 457 4.9714803695678711 462 12.351565361022949
		 467 4.9714803695678711 472 12.351565361022949 477 4.9714803695678711 482 12.351565361022949
		 487 4.9714803695678711 492 12.351565361022949 497 4.9714803695678711 502 12.351565361022949
		 507 4.9714803695678711 512 16.386510848999023 517 0;
	setAttr -s 22 ".ktl[0:21]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes no;
	setAttr -s 22 ".kix[0:21]"  1 0.88508152961730957 0.99731224775314331 
		0.96228176355361938 0.99356299638748169 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.98601585626602173 
		0.97899758815765381 1;
	setAttr -s 22 ".kiy[0:21]"  0 0.46543604135513306 0.073268227279186249 
		0.272054523229599 -0.11328092962503433 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.16665135324001312 
		-0.20387151837348938 0;
	setAttr -s 22 ".kox[0:21]"  1 0.88508152961730957 0.99731224775314331 
		0.96228176355361938 0.99356299638748169 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.98601585626602173 
		0.97899758815765381 1;
	setAttr -s 22 ".koy[0:21]"  0 0.46543604135513306 0.073268227279186249 
		0.272054523229599 -0.11328092962503433 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.16665135324001312 
		-0.20387151837348938 0;
createNode animCurveTA -n "animCurveTA225";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 22 ".ktv[0:21]"  418 0 420 18.709156036376953 423 17.896600723266602
		 428 16.763090133666992 432 6.1861891746520996 437 18.350570678710938 442 6.1861891746520996
		 447 18.350570678710938 452 6.1861891746520996 457 18.350570678710938 462 6.1861891746520996
		 467 18.350570678710938 472 6.1861891746520996 477 18.350570678710938 482 6.1861891746520996
		 487 18.350570678710938 492 6.1861891746520996 497 18.350570678710938 502 6.1861891746520996
		 507 18.350570678710938 512 5.0850110054016113 517 0;
	setAttr -s 22 ".ktl[0:21]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes yes no;
	setAttr -s 22 ".kix[0:21]"  1 0.55488002300262451 0.99484878778457642 
		0.87805324792861938 0.99728167057037354 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99893796443939209 
		0.7928396463394165 1;
	setAttr -s 22 ".kiy[0:21]"  0 0.83193033933639526 -0.1013706848025322 
		-0.47856301069259644 0.073683805763721466 0 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.046076927334070206 
		-0.60943031311035156 0;
	setAttr -s 22 ".kox[0:21]"  1 0.55488002300262451 0.99484878778457642 
		0.87805324792861938 0.99728167057037354 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99893796443939209 
		0.7928396463394165 1;
	setAttr -s 22 ".koy[0:21]"  0 0.83193033933639526 -0.1013706848025322 
		-0.47856301069259644 0.073683805763721466 0 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.046076927334070206 
		-0.60943031311035156 0;
createNode animCurveTL -n "animCurveTL223";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0.057151313871145248 517 0.057151313871145248;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL224";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 23.729547500610352 517 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL225";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -53.338920593261719 517 -53.338920593261719;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU226";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU227";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU228";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA226";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA227";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA228";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL226";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -5.8221402168273926 517 -5.8221402168273926;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL227";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -10.433219909667969 517 -10.433219909667969;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL228";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 28.427871704101563 517 28.427871704101563;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU229";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU230";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU231";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA229";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 21 ".ktv[0:20]"  418 0 422 -25.103096008300781 428 -21.790447235107422
		 432 4.5649971961975098 438 -30.099355697631839 443 -0.18246038258075714 448 -30.099355697631839
		 453 -0.18246038258075714 458 -30.099355697631839 463 -0.18246038258075714 468 -30.099355697631839
		 473 -0.18246038258075714 478 -30.099355697631839 483 -0.18246038258075714 488 -30.099355697631839
		 493 -0.18246038258075714 498 -30.099355697631839 503 -0.18246038258075714 508 -30.099355697631839
		 513 7.5570344924926758 517 0;
	setAttr -s 21 ".ktl[0:20]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes no;
	setAttr -s 21 ".kix[0:20]"  1 0.73859220743179321 0.62691396474838257 
		0.94443309307098389 0.98404884338378906 1 1 1 1 1 1 1 1 1 1 1 1 1 0.95125973224639893 
		0.58099424839019775 1;
	setAttr -s 21 ".kiy[0:20]"  0 -0.6741524338722229 0.77908855676651001 
		-0.3287036120891571 -0.1778988391160965 0 0 0 0 0 0 0 0 0 0 0 0 0 0.30839049816131592 
		0.81390762329101563 0;
	setAttr -s 21 ".kox[0:20]"  1 0.73859220743179321 0.62691396474838257 
		0.94443309307098389 0.98404884338378906 1 1 1 1 1 1 1 1 1 1 1 1 1 0.95125973224639893 
		0.58099424839019775 1;
	setAttr -s 21 ".koy[0:20]"  0 -0.6741524338722229 0.77908855676651001 
		-0.3287036120891571 -0.1778988391160965 0 0 0 0 0 0 0 0 0 0 0 0 0 0.30839049816131592 
		0.81390762329101563 0;
createNode animCurveTA -n "animCurveTA230";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 20 ".ktv[0:19]"  418 0 428 -8.7489471435546875 432 7.9688925743103027
		 438 -8.3322410583496094 443 4.1215848922729492 448 -8.3322410583496094 453 4.1215848922729492
		 458 -8.3322410583496094 463 4.1215848922729492 468 -8.3322410583496094 473 4.1215848922729492
		 478 -8.3322410583496094 483 4.1215848922729492 488 -8.3322410583496094 493 4.1215848922729492
		 498 -8.3322410583496094 503 4.1215848922729492 508 -8.3322410583496094 513 7.0657639503479004
		 517 0;
	setAttr -s 20 ".ktl[0:19]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes no;
	setAttr -s 20 ".kix[0:19]"  1 0.97273313999176025 0.99984776973724365 
		0.98943781852722168 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99248099327087402 0.93234717845916748 
		1;
	setAttr -s 20 ".kiy[0:19]"  0 0.23192721605300903 0.017452294006943703 
		-0.14495748281478882 0 0 0 0 0 0 0 0 0 0 0 0 0 0.12239839881658554 0.3615642786026001 
		0;
	setAttr -s 20 ".kox[0:19]"  1 0.97273313999176025 0.99984776973724365 
		0.98943781852722168 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99248099327087402 0.93234717845916748 
		1;
	setAttr -s 20 ".koy[0:19]"  0 0.23192721605300903 0.017452294006943703 
		-0.14495748281478882 0 0 0 0 0 0 0 0 0 0 0 0 0 0.12239839881658554 0.3615642786026001 
		0;
createNode animCurveTA -n "animCurveTA231";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 21 ".ktv[0:20]"  418 0 422 4.6348147392272949 428 16.190708160400391
		 432 5.1851391792297363 438 14.326798439025877 443 11.771653175354004 448 14.326798439025877
		 453 11.771653175354004 458 14.326798439025877 463 11.771653175354004 468 14.326798439025877
		 473 11.771653175354004 478 14.326798439025877 483 11.771653175354004 488 14.326798439025877
		 493 11.771653175354004 498 14.326798439025877 503 11.771653175354004 508 14.326798439025877
		 513 10.354403495788574 517 0;
	setAttr -s 21 ".ktl[0:20]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes no;
	setAttr -s 21 ".kix[0:20]"  1 0.82762134075164795 0.99973440170288086 
		0.99696600437164307 0.96995657682418823 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99824249744415283 
		0.83199924230575562 1;
	setAttr -s 21 ".kiy[0:20]"  0 0.5612868070602417 0.023045854642987251 
		-0.077838502824306488 0.24327822029590607 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.059261370450258255 
		-0.55477672815322876 0;
	setAttr -s 21 ".kox[0:20]"  1 0.82762134075164795 0.99973440170288086 
		0.99696600437164307 0.96995657682418823 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99824249744415283 
		0.83199924230575562 1;
	setAttr -s 21 ".koy[0:20]"  0 0.5612868070602417 0.023045854642987251 
		-0.077838502824306488 0.24327822029590607 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.059261370450258255 
		-0.55477672815322876 0;
createNode animCurveTL -n "animCurveTL229";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 11.41090202331543 517 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL230";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -0.91886520385742188 517 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL231";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 13.740226745605469 517 13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU232";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU233";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU234";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA232";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 21 ".ktv[0:20]"  418 0 421 -7.7407565116882315 427 -4.4281091690063477
		 431 21.927335739135742 437 -12.737016677856445 442 17.179878234863281 447 -12.737016677856445
		 452 17.179878234863281 457 -12.737016677856445 462 17.179878234863281 467 -12.737016677856445
		 472 17.179878234863281 477 -12.737016677856445 482 17.179878234863281 487 -12.737016677856445
		 492 17.179878234863281 497 -12.737016677856445 502 17.179878234863281 507 -12.737016677856445
		 512 24.91937255859375 517 0;
	setAttr -s 21 ".ktl[0:20]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes no;
	setAttr -s 21 ".kix[0:20]"  1 0.97941619157791138 0.62691569328308105 
		0.94443356990814209 0.98404866456985474 1 1 1 1 1 1 1 1 1 1 1 1 1 0.9512602686882019 
		0.88228178024291992 1;
	setAttr -s 21 ".kiy[0:20]"  0 -0.20185133814811707 0.77908706665039063 
		-0.32870230078697205 -0.1778995543718338 0 0 0 0 0 0 0 0 0 0 0 0 0 0.30838921666145325 
		0.47072172164916992 0;
	setAttr -s 21 ".kox[0:20]"  1 0.97941619157791138 0.62691569328308105 
		0.94443356990814209 0.98404866456985474 1 1 1 1 1 1 1 1 1 1 1 1 1 0.9512602686882019 
		0.88228178024291992 1;
	setAttr -s 21 ".koy[0:20]"  0 -0.20185133814811707 0.77908706665039063 
		-0.32870230078697205 -0.1778995543718338 0 0 0 0 0 0 0 0 0 0 0 0 0 0.30838921666145325 
		0.47072172164916992 0;
createNode animCurveTA -n "animCurveTA233";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 20 ".ktv[0:19]"  418 0 427 -8.7489471435546875 431 7.9688925743103027
		 437 -8.3322410583496094 442 4.1215848922729492 447 -8.3322410583496094 452 4.1215848922729492
		 457 -8.3322410583496094 462 4.1215848922729492 467 -8.3322410583496094 472 4.1215848922729492
		 477 -8.3322410583496094 482 4.1215848922729492 487 -8.3322410583496094 492 4.1215848922729492
		 497 -8.3322410583496094 502 4.1215848922729492 507 -8.3322410583496094 512 7.0657639503479004
		 517 0;
	setAttr -s 20 ".ktl[0:19]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes no;
	setAttr -s 20 ".kix[0:19]"  1 0.96858024597167969 0.99984776973724365 
		0.9894377589225769 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99248111248016357 0.94414627552032471 
		1;
	setAttr -s 20 ".kiy[0:19]"  0 0.24870109558105469 0.017452210187911987 
		-0.14495810866355896 0 0 0 0 0 0 0 0 0 0 0 0 0 0.12239784002304077 0.32952654361724854 
		0;
	setAttr -s 20 ".kox[0:19]"  1 0.96858024597167969 0.99984776973724365 
		0.9894377589225769 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99248111248016357 0.94414627552032471 
		1;
	setAttr -s 20 ".koy[0:19]"  0 0.24870109558105469 0.017452210187911987 
		-0.14495810866355896 0 0 0 0 0 0 0 0 0 0 0 0 0 0.12239784002304077 0.32952654361724854 
		0;
createNode animCurveTA -n "animCurveTA234";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 21 ".ktv[0:20]"  418 0 421 4.6348147392272949 427 16.190708160400391
		 431 5.1851391792297363 437 14.326798439025877 442 11.771653175354004 447 14.326798439025877
		 452 11.771653175354004 457 14.326798439025877 462 11.771653175354004 467 14.326798439025877
		 472 11.771653175354004 477 14.326798439025877 482 11.771653175354004 487 14.326798439025877
		 492 11.771653175354004 497 14.326798439025877 502 11.771653175354004 507 14.326798439025877
		 512 10.354403495788574 517 0;
	setAttr -s 21 ".ktl[0:20]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes yes yes yes yes yes yes no;
	setAttr -s 21 ".kix[0:20]"  1 0.79863709211349487 0.99973440170288086 
		0.99696600437164307 0.96995633840560913 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99824249744415283 
		0.85744732618331909 1;
	setAttr -s 21 ".kiy[0:20]"  0 0.60181283950805664 0.023045748472213745 
		-0.07783816009759903 0.24327914416790009 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.059261094778776169 
		-0.51457172632217407 0;
	setAttr -s 21 ".kox[0:20]"  1 0.79863709211349487 0.99973440170288086 
		0.99696600437164307 0.96995633840560913 1 1 1 1 1 1 1 1 1 1 1 1 1 0.99824249744415283 
		0.85744732618331909 1;
	setAttr -s 21 ".koy[0:20]"  0 0.60181283950805664 0.023045748472213745 
		-0.07783816009759903 0.24327914416790009 0 0 0 0 0 0 0 0 0 0 0 0 0 -0.059261094778776169 
		-0.51457172632217407 0;
createNode animCurveTL -n "animCurveTL232";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0.057151321321725845 517 0.057151321321725845;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL233";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 23.729547500610352 517 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL234";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 53.782066345214844 517 53.782066345214844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU235";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 481 1 489 1 498 1 504 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU236";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 481 1 489 1 498 1 504 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU237";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 481 1 489 1 498 1 504 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA235";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 -3.8097078800201416 432 6.1367754936218262
		 444 -1.0281301736831665 481 0 483 5.1744508743286133 485 -2.6380045413970947 487 -1.8125016689300537
		 489 0 498 0 499 2.7334904670715332 501 0.63091939687728882 504 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.9999813437461853 0.99998784065246582 
		0.99999803304672241 0.99778831005096436 0.96389687061309814 0.80704283714294434 0.96389615535736084 
		0.99762660264968872 0.99350857734680176 0.99614220857620239 0.97476768493652344 0.99995940923690796 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 -0.0061007188633084297 0.0049254451878368855 
		-0.0019969688728451729 0.066471405327320099 -0.26627561450004578 -0.590492844581604 
		0.26627859473228455 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.0090036550536751747 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99998784065246582 0.99999803304672241 
		1 0.97949254512786865 0.96389687061309814 0.80704283714294434 0.96389615535736084 
		0.99762660264968872 0.99350857734680176 0.99614220857620239 0.97476768493652344 0.99986362457275391 
		1;
	setAttr -s 14 ".koy[0:13]"  0 0.0049254451878368855 -0.0019969688728451729 
		-2.7379996026866138e-005 0.201480433344841 -0.26627561450004578 -0.590492844581604 
		0.26627859473228455 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.016515195369720459 0;
createNode animCurveTA -n "animCurveTA236";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 9.5209207534790039 432 -9.0663366317749023
		 444 8.0568571090698242 481 0 483 -4.8541984558105469 485 12.202020645141602 487 3.8002567291259761
		 489 0 498 0 499 0.74843138456344604 501 10.108014106750488 504 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.99988377094268799 0.99995768070220947 
		0.99998867511749268 0.99052166938781738 0.6163068413734436 0.74097001552581787 0.61630237102508545 
		0.98969072103500366 0.99950891733169556 0.57813185453414917 0.99804013967514038 0.98378574848175049 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.015244949609041214 -0.0092040356248617172 
		0.0047724517062306404 -0.13735666871070862 0.787506103515625 0.67153811454772949 
		-0.78750962018966675 -0.14322136342525482 0.031334873288869858 0.81594341993331909 
		-0.062577374279499054 -0.17934779822826385 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99995768070220947 0.99998867511749268 
		1 0.97884935140609741 0.6163068413734436 0.74097001552581787 0.61630237102508545 
		0.98969072103500366 0.99950891733169556 0.57813185453414917 0.99804013967514038 0.9667239785194397 
		1;
	setAttr -s 14 ".koy[0:13]"  0 -0.0092040356248617172 0.0047724517062306404 
		-0.0001166772999567911 -0.20458222925662994 0.787506103515625 0.67153811454772949 
		-0.78750962018966675 -0.14322136342525482 0.031334873288869858 0.81594341993331909 
		-0.062577374279499054 -0.25582167506217957 0;
createNode animCurveTA -n "animCurveTA237";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 4.0786728858947754 432 7.6916141510009766
		 444 12.225897789001465 481 0 483 7.0496621131896973 485 -7.5172376632690421 487 -4.8886275291442871
		 489 0 498 0 499 -3.6848833560943608 501 5.9696779251098633 504 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.96501302719116211 0.99147385358810425 
		0.9999995231628418 0.9984581470489502 0.78575193881988525 0.62464034557342529 0.78574848175048828 
		0.98311024904251099 0.98829632997512817 0.76814913749694824 0.95550709962844849 0.99386155605316162 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.26220214366912842 0.13030540943145752 
		0.00091401144163683057 -0.055509559810161591 -0.61854183673858643 -0.78091257810592651 
		0.61854606866836548 0.18301410973072052 -0.15254579484462738 0.6402708888053894 0.29496803879737854 
		-0.11063116788864136 0;
	setAttr -s 14 ".kox[0:13]"  1 0.96590864658355713 0.99138921499252319 
		1 0.96127051115036011 0.78575193881988525 0.62464034557342529 0.78574848175048828 
		0.98311024904251099 0.98829632997512817 0.76814913749694824 0.95550709962844849 0.988006591796875 
		1;
	setAttr -s 14 ".koy[0:13]"  0 0.25888320803642273 0.13094791769981384 
		-0.00031082530040293932 0.27560672163963318 -0.61854183673858643 -0.78091257810592651 
		0.61854606866836548 0.18301410973072052 -0.15254579484462738 0.6402708888053894 0.29496803879737854 
		-0.15441152453422546 0;
createNode animCurveTL -n "animCurveTL235";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 -1.1630247831344604 481 -1.1630247831344604
		 489 -1.1630247831344604 498 -1.1630247831344604 504 -1.1630247831344604 517 -1.1630247831344604;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL236";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1.228269100189209 481 1.2282689809799194
		 489 1.2282689809799194 498 1.2282689809799194 504 1.2282689809799194 517 1.228269100189209;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL237";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  418 27.684015274047852 487 27.684015274047852
		 517 27.684015274047852;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU238";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 479 1 487 1 496 1 502 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU239";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 479 1 487 1 496 1 502 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU240";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 479 1 487 1 496 1 502 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA238";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 -3.9521522521972661 432 5.8013877868652344
		 444 -1.5114952325820923 479 0 481 5.1744508743286133 483 -2.6380045413970947 485 -1.8125016689300537
		 487 0 496 0 497 2.7334904670715332 499 0.63091939687728882 502 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.99998003244400024 0.99998831748962402 
		0.99999797344207764 0.99714767932891846 0.96389615535736084 0.80704605579376221 0.96389615535736084 
		0.99762660264968872 0.99350863695144653 0.99614220857620239 0.97476732730865479 0.99996417760848999 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 -0.0063288151286542416 0.0048299035988748074 
		-0.002038212725892663 0.075476080179214478 -0.26627859473228455 -0.5904884934425354 
		0.26627859473228455 0.068856269121170044 0.11375657469034195 0.087753124535083771 
		-0.22322343289852142 -0.0084648309275507927 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99998831748962402 0.99999797344207764 
		1 0.97440946102142334 0.96389615535736084 0.80704605579376221 0.96389615535736084 
		0.99762660264968872 0.99350863695144653 0.99614220857620239 0.97476732730865479 0.99989217519760132 
		1;
	setAttr -s 14 ".koy[0:13]"  0 0.0048299035988748074 -0.002038212725892663 
		0 0.22478032112121582 -0.26627859473228455 -0.5904884934425354 0.26627859473228455 
		0.068856269121170044 0.11375657469034195 0.087753124535083771 -0.22322343289852142 
		-0.014680578373372555 0;
createNode animCurveTA -n "animCurveTA239";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 -1.0682097673416138 432 -10.378499031066895
		 444 -8.7559137344360352 479 -6.0245368693756518e-009 481 -4.8541984558105469 483 12.202020645141602
		 485 3.8002567291259761 487 -6.0245368693756518e-009 496 -6.0245368693756518e-009
		 497 0.74843138456344604 499 10.108014106750488 502 -6.0245368693756518e-009 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.98224115371704102 0.99999231100082397 
		0.99290668964385986 0.99902582168579102 0.61630237102508545 0.7409738302230835 0.61630237102508545 
		0.98969054222106934 0.99950891733169556 0.57813185453414917 0.99804008007049561 0.9852520227432251 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 -0.18762272596359253 -0.0039311256259679794 
		0.11889663338661194 0.04412851482629776 0.78750962018966675 0.67153394222259521 -0.78750962018966675 
		-0.14322192966938019 0.031334724277257919 0.81594341993331909 -0.062577933073043823 
		-0.17110921442508698 0;
	setAttr -s 14 ".kox[0:13]"  1 0.98151308298110962 1 0.99288153648376465 
		0.97403299808502197 0.61630237102508545 0.7409738302230835 0.61630237102508545 0.98969054222106934 
		0.99950891733169556 0.57813185453414917 0.99804008007049561 0.97343236207962036 1;
	setAttr -s 14 ".koy[0:13]"  0 -0.19139517843723297 0.00013329614012036473 
		0.11910627037286758 -0.22640606760978699 0.78750962018966675 0.67153394222259521 
		-0.78750962018966675 -0.14322192966938019 0.031334724277257919 0.81594341993331909 
		-0.062577933073043823 -0.22897481918334961 0;
createNode animCurveTA -n "animCurveTA240";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 10.307165145874023 432 -7.6067657470703125
		 444 10.631178855895996 479 4.9320249217998935e-008 481 7.0496621131896973 483 -7.5172376632690421
		 485 -4.8886275291442871 487 4.9320249217998935e-008 496 4.9320249217998935e-008 497 -3.6848833560943608
		 499 5.9696779251098633 502 4.9320249217998935e-008 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.99986380338668823 0.99996066093444824 
		0.99998706579208374 0.99917900562286377 0.78574848175048828 0.62464475631713867 0.78574848175048828 
		0.98311012983322144 0.9882965087890625 0.76814913749694824 0.95550632476806641 0.99440634250640869 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.016503551974892616 -0.0088706417009234428 
		0.0050831376574933529 -0.040513280779123306 -0.61854606866836548 -0.78090900182723999 
		0.61854606866836548 0.18301482498645782 -0.15254507958889008 0.6402708888053894 0.29497048258781433 
		-0.10562168806791306 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99996066093444824 0.99998706579208374 
		1 0.9522165060043335 0.78574848175048828 0.62464475631713867 0.78574848175048828 
		0.98311012983322144 0.9882965087890625 0.76814913749694824 0.95550632476806641 0.99048799276351929 
		1;
	setAttr -s 14 ".koy[0:13]"  0 -0.0088706417009234428 0.0050831376574933529 
		-0.00031168825807981193 0.30542382597923279 -0.61854606866836548 -0.78090900182723999 
		0.61854606866836548 0.18301482498645782 -0.15254507958889008 0.6402708888053894 0.29497048258781433 
		-0.13759928941726685 0;
createNode animCurveTL -n "animCurveTL238";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 4.9883952140808105 479 4.9883952140808105
		 487 4.9883952140808105 496 4.9883952140808105 502 4.9883952140808105 517 4.9883952140808105;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL239";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  418 41.4617919921875 487 41.4617919921875
		 517 41.4617919921875;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL240";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  418 38.623714447021484 487 38.623714447021484
		 517 38.623714447021484;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU241";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 483 1 491 1 500 1 506 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU242";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 483 1 491 1 500 1 506 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU243";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 483 1 491 1 500 1 506 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA241";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 -3.8299729824066162 432 6.259192943572998
		 444 -1.2545945644378662 483 0 485 5.1744508743286133 487 -2.6380045413970947 489 -1.8125016689300537
		 491 0 500 0 501 2.7334904670715332 503 0.63091939687728882 506 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.99998122453689575 0.99998754262924194 
		0.99999785423278809 0.99784982204437256 0.96389615535736084 0.80704283714294434 0.96389687061309814 
		0.99762660264968872 0.99350857734680176 0.99614220857620239 0.97476768493652344 0.99995368719100952 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 -0.0061331694014370441 0.004996100440621376 
		-0.002094207564368844 0.065541483461856842 -0.26627859473228455 -0.590492844581604 
		0.26627561450004578 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.0096194185316562653 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99998754262924194 0.99999785423278809 
		1 0.98296785354614258 0.96389615535736084 0.80704283714294434 0.96389687061309814 
		0.99762660264968872 0.99350857734680176 0.99614220857620239 0.97476768493652344 0.99982184171676636 
		1;
	setAttr -s 14 ".koy[0:13]"  0 0.004996100440621376 -0.002094207564368844 
		-2.0695306375273503e-005 0.18377760052680969 -0.26627859473228455 -0.590492844581604 
		0.26627561450004578 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.018873736262321472 0;
createNode animCurveTA -n "animCurveTA242";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 9.4997262954711914 432 -8.9795331954956055
		 444 7.6643218994140616 483 0 485 -4.8541984558105469 487 12.202020645141602 489 3.8002567291259761
		 491 0 500 0 501 0.74843138456344604 503 10.108014106750488 506 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.99988430738449097 0.9999580979347229 
		0.99998921155929565 0.99192023277282715 0.61630237102508545 0.74097001552581787 0.6163068413734436 
		0.98969072103500366 0.99950891733169556 0.57813185453414917 0.99804013967514038 0.98203146457672119 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.015211016871035099 -0.0091505590826272964 
		0.0046388553455471992 -0.12686283886432648 0.78750962018966675 0.67153811454772949 
		-0.787506103515625 -0.14322136342525482 0.031334873288869858 0.81594341993331909 
		-0.062577374279499054 -0.18871723115444183 0;
	setAttr -s 14 ".kox[0:13]"  1 0.9999580979347229 0.99998921155929565 
		1 0.98216670751571655 0.61630237102508545 0.74097001552581787 0.6163068413734436 
		0.98969072103500366 0.99950891733169556 0.57813185453414917 0.99804013967514038 0.95718324184417725 
		1;
	setAttr -s 14 ".koy[0:13]"  0 -0.0091505590826272964 0.0046388553455471992 
		-9.7650918178260326e-005 -0.18801200389862061 0.78750962018966675 0.67153811454772949 
		-0.787506103515625 -0.14322136342525482 0.031334873288869858 0.81594341993331909 
		-0.062577374279499054 -0.28948262333869934 0;
createNode animCurveTA -n "animCurveTA243";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 4.1008920669555664 432 7.6274089813232431
		 444 12.564093589782715 483 0 485 7.0496621131896973 487 -7.5172376632690421 489 -4.8886275291442871
		 491 0 500 0 501 -3.6848833560943608 503 5.9696779251098633 506 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.96600985527038574 0.99107277393341064 
		0.99999946355819702 0.9984167218208313 0.78574848175048828 0.62464034557342529 0.78575193881988525 
		0.98311024904251099 0.98829632997512817 0.76814913749694824 0.95550709962844849 0.99320876598358154 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.25850528478622437 0.13332206010818481 
		0.001017797039821744 -0.056249316781759262 -0.61854606866836548 -0.78091257810592651 
		0.61854183673858643 0.18301410973072052 -0.15254579484462738 0.6402708888053894 0.29496803879737854 
		-0.11634597927331924 0;
	setAttr -s 14 ".kox[0:13]"  1 0.96692156791687012 0.99096709489822388 
		1 0.96754294633865356 0.78574848175048828 0.62464034557342529 0.78575193881988525 
		0.98311024904251099 0.98829632997512817 0.76814913749694824 0.95550709962844849 0.98442047834396362 
		1;
	setAttr -s 14 ".koy[0:13]"  0 0.25507372617721558 0.13410553336143494 
		-0.00028575939359143376 0.25270664691925049 -0.61854606866836548 -0.78091257810592651 
		0.61854183673858643 0.18301410973072052 -0.15254579484462738 0.6402708888053894 0.29496803879737854 
		-0.17582999169826508 0;
createNode animCurveTL -n "animCurveTL241";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1.1630247831344604 483 1.1630247831344604
		 491 1.1630247831344604 500 1.1630247831344604 506 1.1630247831344604 517 1.1630247831344604;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL242";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 2.0187394618988037 483 2.0187394618988037
		 491 2.0187394618988037 500 2.0187394618988037 506 2.0187394618988037 517 2.0187394618988037;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL243";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  418 27.637619018554688 487 27.637619018554688
		 517 27.637619018554688;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU244";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 481 1 489 1 498 1 504 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU245";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 481 1 489 1 498 1 504 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU246";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 481 1 489 1 498 1 504 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA244";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 4.2311644554138184 432 -5.9216394424438477
		 444 0.11722784489393234 481 2.9530831113788736e-008 483 5.1744508743286133 485 -2.6380045413970947
		 487 -1.8125016689300537 489 2.9530831113788736e-008 498 2.9530831113788736e-008 499 2.7334904670715332
		 501 0.63091939687728882 504 2.9530831113788736e-008 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.9999769926071167 0.99998730421066284 
		0.99999850988388062 0.9985281229019165 0.96389687061309814 0.80704283714294434 0.96389615535736084 
		0.99762660264968872 0.99350857734680176 0.99614220857620239 0.97476768493652344 0.99995940923690796 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.0067755943164229393 -0.0050276122055947781 
		0.0016831263201311231 0.054237108677625656 -0.26627561450004578 -0.590492844581604 
		0.26627859473228455 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.0090036550536751747 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99998730421066284 0.99999850988388062 
		1 0.97949254512786865 0.96389687061309814 0.80704283714294434 0.96389615535736084 
		0.99762660264968872 0.99350857734680176 0.99614220857620239 0.97476768493652344 0.99986362457275391 
		1;
	setAttr -s 14 ".koy[0:13]"  0 -0.0050276122055947781 0.0016831263201311231 
		-5.0370403187116608e-005 0.201480433344841 -0.26627561450004578 -0.590492844581604 
		0.26627859473228455 0.068856008350849152 0.11375708878040314 0.087753117084503174 
		-0.22322149574756622 -0.016515195369720459 0;
createNode animCurveTA -n "animCurveTA245";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 7.1821823120117187 432 4.184504508972168
		 444 15.016930580139158 481 0 483 -4.8541984558105469 485 12.202020645141602 487 3.8002567291259761
		 489 0 498 0 499 0.74843138456344604 501 10.108014106750488 504 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.99993383884429932 0.99999892711639404 
		0.99999547004699707 0.97797441482543945 0.6163068413734436 0.74097001552581787 0.61630237102508545 
		0.98969072103500366 0.99950891733169556 0.57813185453414917 0.99804013967514038 0.98378574848175049 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.011500721797347069 -0.0014844505349174142 
		0.0030191550031304359 -0.20872479677200317 0.787506103515625 0.67153811454772949 
		-0.78750962018966675 -0.14322136342525482 0.031334873288869858 0.81594341993331909 
		-0.062577374279499054 -0.17934779822826385 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99999892711639404 0.99999547004699707 
		1 0.97884935140609741 0.6163068413734436 0.74097001552581787 0.61630237102508545 
		0.98969072103500366 0.99950891733169556 0.57813185453414917 0.99804013967514038 0.9667239785194397 
		1;
	setAttr -s 14 ".koy[0:13]"  0 -0.0014844505349174142 0.0030191550031304359 
		-0.00025638463557697833 -0.20458222925662994 0.787506103515625 0.67153811454772949 
		-0.78750962018966675 -0.14322136342525482 0.031334873288869858 0.81594341993331909 
		-0.062577374279499054 -0.25582167506217957 0;
createNode animCurveTA -n "animCurveTA246";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 14 ".ktv[0:13]"  418 0 423 7.5799884796142587 432 -12.374588012695313
		 444 2.4220359325408936 481 0 483 7.0496621131896973 485 -7.5172376632690421 487 -4.8886275291442871
		 489 0 498 0 499 -3.6848833560943608 501 5.9696779251098633 504 0 517 0;
	setAttr -s 14 ".ktl[0:13]" no yes yes yes yes yes yes yes yes yes yes 
		yes yes yes;
	setAttr -s 14 ".kix[0:13]"  1 0.99992632865905762 0.99995124340057373 
		0.99999147653579712 0.99876707792282104 0.78575193881988525 0.62464034557342529 0.78574848175048828 
		0.98311024904251099 0.98829632997512817 0.76814913749694824 0.95550709962844849 0.99386155605316162 
		1;
	setAttr -s 14 ".kiy[0:13]"  0 0.012137632817029953 -0.0098810382187366486 
		0.0041240178979933262 0.0496416836977005 -0.61854183673858643 -0.78091257810592651 
		0.61854606866836548 0.18301410973072052 -0.15254579484462738 0.6402708888053894 0.29496803879737854 
		-0.11063116788864136 0;
	setAttr -s 14 ".kox[0:13]"  1 0.99995124340057373 0.99999147653579712 
		1 0.96127051115036011 0.78575193881988525 0.62464034557342529 0.78574848175048828 
		0.98311024904251099 0.98829632997512817 0.76814913749694824 0.95550709962844849 0.988006591796875 
		1;
	setAttr -s 14 ".koy[0:13]"  0 -0.0098810382187366486 0.0041240178979933262 
		-0.00011403548705857247 0.27560672163963318 -0.61854183673858643 -0.78091257810592651 
		0.61854606866836548 0.18301410973072052 -0.15254579484462738 0.6402708888053894 0.29496803879737854 
		-0.15441152453422546 0;
createNode animCurveTL -n "animCurveTL244";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 4.9883952140808105 481 4.9883952140808105
		 489 4.9883952140808105 498 4.9883952140808105 504 4.9883952140808105 517 4.9883952140808105;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL245";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  418 41.4617919921875 487 41.4617919921875
		 517 41.4617919921875;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL246";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  418 -38.180568695068359 487 -38.180568695068359
		 517 -38.180568695068359;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU247";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 1 425 1 451 1 455 1 480 1 490 1 517 1;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU248";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 1 425 1 451 1 455 1 480 1 490 1 517 1;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU249";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 1 425 1 451 1 455 1 480 1 490 1 517 1;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA247";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 -9.5584049224853516 420 -9.3701152801513672
		 425 -9.3701152801513672 427 -10.179580688476562 451 -10.179580688476562 455 -8.4355812072753906
		 480 -8.4355812072753906 485 -9.8850908279418945 490 -9.5584049224853516 517 -9.5584049224853516;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.99993652105331421 0.99882888793945313 
		0.99991500377655029 0.99965989589691162 0.99968290328979492 0.99979525804519653 0.99889576435089111 
		0.99999088048934937 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.01126642432063818 -0.048381663858890533 
		-0.013039982877671719 0.02608126774430275 0.025182504206895828 -0.020234826952219009 
		-0.046980846673250198 0.0042762812227010727 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99993652105331421 0.99882888793945313 
		0.99991500377655029 0.99965989589691162 0.99968290328979492 0.99979525804519653 0.99889576435089111 
		0.99999088048934937 1;
	setAttr -s 10 ".koy[0:9]"  0 0.01126642432063818 -0.048381663858890533 
		-0.013039982877671719 0.02608126774430275 0.025182504206895828 -0.020234826952219009 
		-0.046980846673250198 0.0042762812227010727 0;
createNode animCurveTA -n "animCurveTA248";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 -14.087939262390137 420 -15.794679641723633
		 425 -15.794679641723633 427 12.481014251708984 451 12.481014251708984 455 -14.625900268554689
		 480 -14.625900268554689 485 -12.135453224182129 490 -14.087939262390137 517 -14.087939262390137;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.99482506513595581 0.50879400968551636 
		0.91002434492111206 0.92670285701751709 0.93116992712020874 0.99939602613449097 0.99974620342254639 
		0.99967354536056519 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.10160214453935623 0.86088830232620239 
		0.41455486416816711 -0.37579473853111267 -0.3645855188369751 0.034752205014228821 
		0.022528385743498802 -0.025549661368131638 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99482506513595581 0.50879400968551636 
		0.91002434492111206 0.92670285701751709 0.93116992712020874 0.99939602613449097 0.99974620342254639 
		0.99967354536056519 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.10160214453935623 0.86088830232620239 
		0.41455486416816711 -0.37579473853111267 -0.3645855188369751 0.034752205014228821 
		0.022528385743498802 -0.025549661368131638 0;
createNode animCurveTA -n "animCurveTA249";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 -2.2710940837860107 420 0.42690414190292358
		 425 0.42690414190292358 427 -1.6496734619140625 451 -1.6496734619140625 455 4.5873622894287109
		 480 4.5873622894287109 485 4.4857473373413086 490 -2.2710940837860107 517 -2.2710940837860107;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.9872167706489563 0.99236774444580078 
		0.99944078922271729 0.99567520618438721 0.99596655368804932 0.99999898672103882 0.96112364530563354 
		0.99611139297485352 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.15938331186771393 -0.12331397831439972 
		-0.03343651071190834 0.092902220785617828 0.089724980294704437 -0.001418810454197228 
		-0.27611821889877319 -0.08810298889875412 0;
	setAttr -s 10 ".kox[0:9]"  1 0.9872167706489563 0.99236774444580078 
		0.99944078922271729 0.99567520618438721 0.99596655368804932 0.99999898672103882 0.96112364530563354 
		0.99611139297485352 1;
	setAttr -s 10 ".koy[0:9]"  0 0.15938331186771393 -0.12331397831439972 
		-0.03343651071190834 0.092902220785617828 0.089724980294704437 -0.001418810454197228 
		-0.27611821889877319 -0.08810298889875412 0;
createNode animCurveTL -n "animCurveTL247";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 32.845657348632812 425 32.845657348632812
		 451 32.845657348632812 455 34.140541076660156 480 34.140541076660156 490 32.845657348632812
		 517 32.845657348632812;
	setAttr -s 7 ".kix[0:6]"  1 1 0.69452732801437378 0.68225020170211792 
		0.7477683424949646 0.76573288440704346 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0.71946626901626587 0.73111867904663086 
		-0.66395974159240723 -0.64315873384475708 0;
	setAttr -s 7 ".kox[0:6]"  1 1 0.69452732801437378 0.68225020170211792 
		0.7477683424949646 0.76573288440704346 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0.71946626901626587 0.73111867904663086 
		-0.66395974159240723 -0.64315873384475708 0;
createNode animCurveTL -n "animCurveTL248";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 17.186578750610352 425 17.186578750610352
		 451 17.186578750610352 455 17.129936218261719 480 17.129936218261719 490 17.186578750610352
		 517 17.186578750610352;
	setAttr -s 7 ".kix[0:6]"  1 1 0.99897491931915283 0.99890309572219849 
		0.99924653768539429 0.99932569265365601 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 -0.04526776447892189 -0.046825330704450607 
		0.038811523467302322 0.03671649843454361 0;
	setAttr -s 7 ".kox[0:6]"  1 1 0.99897491931915283 0.99890309572219849 
		0.99924653768539429 0.99932569265365601 1;
	setAttr -s 7 ".koy[0:6]"  0 0 -0.04526776447892189 -0.046825330704450607 
		0.038811523467302322 0.03671649843454361 0;
createNode animCurveTL -n "animCurveTL249";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 11.930496215820313 425 11.930496215820313
		 451 11.930496215820313 455 11.580482482910156 480 11.580482482910156 490 11.930496215820313
		 517 11.930496215820313;
	setAttr -s 7 ".kix[0:6]"  1 1 0.96296137571334839 0.96051484346389771 
		0.97238528728485107 0.97518271207809448 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 -0.26963946223258972 -0.27822864055633545 
		0.23338152468204498 0.22140136361122131 0;
	setAttr -s 7 ".kox[0:6]"  1 1 0.96296137571334839 0.96051484346389771 
		0.97238528728485107 0.97518271207809448 1;
	setAttr -s 7 ".koy[0:6]"  0 0 -0.26963946223258972 -0.27822864055633545 
		0.23338152468204498 0.22140136361122131 0;
createNode animCurveTU -n "animCurveTU250";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 1 425 1 451 1 455 1 480 1 490 1 517 1;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU251";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 1 425 1 451 1 455 1 480 1 490 1 517 1;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU252";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 1 425 1 451 1 455 1 480 1 490 1 517 1;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA250";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 -0.89352136850357056 420 -2.8088624477386475
		 425 -2.8088624477386475 427 0.75180423259735107 451 0.75180423259735107 455 1.4775087833404541
		 480 1.4775087833404541 485 -1.6765773296356201 490 -0.89352136850357056 517 -0.89352136850357056;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.99349594116210938 0.97804522514343262 
		0.99835866689682007 0.99994099140167236 0.99994516372680664 0.999031662940979 0.99510413408279419 
		0.99994742870330811 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.11386783421039581 0.20839233696460724 
		0.05727086216211319 0.010855864733457565 0.010481573641300201 -0.043996702879667282 
		-0.098831377923488617 0.010249651037156582 0;
	setAttr -s 10 ".kox[0:9]"  1 0.99349594116210938 0.97804522514343262 
		0.99835866689682007 0.99994099140167236 0.99994516372680664 0.999031662940979 0.99510413408279419 
		0.99994742870330811 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.11386783421039581 0.20839233696460724 
		0.05727086216211319 0.010855864733457565 0.010481573641300201 -0.043996702879667282 
		-0.098831377923488617 0.010249651037156582 0;
createNode animCurveTA -n "animCurveTA251";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 11.041102409362793 420 -12.713404655456543
		 425 -12.713404655456543 427 17.068014144897461 451 17.068014144897461 455 -2.5452852249145508
		 480 -2.5452852249145508 485 6.4155979156494141 490 11.041102409362793 517 11.041102409362793;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.57538306713104248 0.48935306072235107 
		0.90159302949905396 0.95954805612564087 0.96213597059249878 0.9922635555267334 0.86911129951477051 
		0.99817204475402832 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.81788408756256104 0.8720858097076416 
		0.43258523941040039 -0.28154480457305908 -0.27256971597671509 0.12414956092834473 
		0.49461659789085388 0.060437090694904327 0;
	setAttr -s 10 ".kox[0:9]"  1 0.57538306713104248 0.48935306072235107 
		0.90159302949905396 0.95954805612564087 0.96213597059249878 0.9922635555267334 0.86911129951477051 
		0.99817204475402832 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.81788408756256104 0.8720858097076416 
		0.43258523941040039 -0.28154480457305908 -0.27256971597671509 0.12414956092834473 
		0.49461659789085388 0.060437090694904327 0;
createNode animCurveTA -n "animCurveTA252";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0.32489952445030212 420 9.498225212097168
		 425 9.498225212097168 427 7.0900783538818359 451 7.0900783538818359 455 4.3264288902282715
		 480 4.3264288902282715 485 10.812978744506836 490 0.32489952445030212 517 0.32489952445030212;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.87661236524581909 0.98977607488632202 
		0.999248206615448 0.99914640188217163 0.99920421838760376 0.99592369794845581 0.98624163866043091 
		0.99070709943771362 1;
	setAttr -s 10 ".kiy[0:9]"  0 0.48119717836380005 -0.1426301896572113 
		-0.038767892867326736 -0.041308760643005371 -0.039886645972728729 0.090200133621692657 
		-0.16530983150005341 -0.13601294159889221 0;
	setAttr -s 10 ".kox[0:9]"  1 0.87661236524581909 0.98977607488632202 
		0.999248206615448 0.99914640188217163 0.99920421838760376 0.99592369794845581 0.98624163866043091 
		0.99070709943771362 1;
	setAttr -s 10 ".koy[0:9]"  0 0.48119717836380005 -0.1426301896572113 
		-0.038767892867326736 -0.041308760643005371 -0.039886645972728729 0.090200133621692657 
		-0.16530983150005341 -0.13601294159889221 0;
createNode animCurveTL -n "animCurveTL250";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 32.845657348632812 425 32.845657348632812
		 451 32.845657348632812 455 32.845657348632812 480 32.845657348632812 490 32.845657348632812
		 517 32.845657348632812;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL251";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 17.186578750610352 425 17.186578750610352
		 451 17.186578750610352 455 17.186578750610352 480 17.186578750610352 490 17.186578750610352
		 517 17.186578750610352;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL252";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 -11.48735237121582 425 -11.48735237121582
		 451 -11.48735237121582 455 -11.48735237121582 480 -11.48735237121582 490 -11.48735237121582
		 517 -11.48735237121582;
	setAttr -s 7 ".kix[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".kiy[0:6]"  0 0 0 0 0 0 0;
	setAttr -s 7 ".kox[0:6]"  1 1 1 1 1 1 1;
	setAttr -s 7 ".koy[0:6]"  0 0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU253";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 427 1 450 1 483 1 490 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU254";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 427 1 450 1 483 1 490 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTU -n "animCurveTU255";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 1 427 1 450 1 483 1 490 1 517 1;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA253";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  418 0 422 -13.434542655944824 427 -13.434542655944824
		 431 15.94196891784668 450 15.94196891784668 462 -10.759511947631836 483 -0.42762655019760132
		 490 0 517 0;
	setAttr -s 9 ".ktl[0:8]" no yes yes yes yes yes yes yes yes;
	setAttr -s 9 ".kix[0:8]"  1 0.84789460897445679 0.59034734964370728 
		0.88173890113830566 0.94064831733703613 0.97908759117126465 0.98729205131530762 0.99998611211776733 
		1;
	setAttr -s 9 ".kiy[0:8]"  0 -0.53016477823257446 0.80714935064315796 
		0.47173774242401123 -0.33938279747962952 -0.20343898236751556 0.15891651809215546 
		0.0052682762034237385 0;
	setAttr -s 9 ".kox[0:8]"  1 0.84789460897445679 0.59034734964370728 
		0.88173890113830566 0.94064831733703613 0.97908759117126465 0.98729205131530762 0.99998611211776733 
		1;
	setAttr -s 9 ".koy[0:8]"  0 -0.53016477823257446 0.80714935064315796 
		0.47173774242401123 -0.33938279747962952 -0.20343898236751556 0.15891651809215546 
		0.0052682762034237385 0;
createNode animCurveTA -n "animCurveTA254";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 0 427 0 450 0 483 0 490 0 517 0;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTA -n "animCurveTA255";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 0 427 0 450 0 483 0 490 0 517 0;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL253";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 47.368160247802734 427 47.368160247802734
		 450 47.368160247802734 483 47.368160247802734 490 47.368160247802734 517 47.368160247802734;
	setAttr -s 6 ".kix[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".kiy[0:5]"  0 0 0 0 0 0;
	setAttr -s 6 ".kox[0:5]"  1 1 1 1 1 1;
	setAttr -s 6 ".koy[0:5]"  0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL254";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  418 26.913848876953125 422 17.519794464111328
		 427 17.519794464111328 431 2.1741843223571777 450 12.840606689453125 454 6.3034543991088867
		 462 23.935386657714844 477 23.738334655761719 483 10.838005065917969 490 26.913848876953125
		 517 26.913848876953125;
	setAttr -s 11 ".ktl[0:10]" no yes yes yes yes yes yes yes yes yes yes;
	setAttr -s 11 ".kix[0:10]"  1 0.03988710418343544 0.024429662153124809 
		0.20064286887645721 0.22607406973838806 0.045020543038845062 0.054883629083633423 
		0.066658653318881989 0.16814716160297394 0.087783694267272949 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.99920415878295898 -0.99970149993896484 
		-0.97966444492340088 0.97411006689071655 0.99898606538772583 0.9984927773475647 -0.9977758526802063 
		0.98576188087463379 0.9961395263671875 0;
	setAttr -s 11 ".kox[0:10]"  1 0.03988710418343544 0.024429662153124809 
		0.20064286887645721 0.22607406973838806 0.045020543038845062 0.054883629083633423 
		0.066658653318881989 0.16814716160297394 0.087783694267272949 1;
	setAttr -s 11 ".koy[0:10]"  0 -0.99920415878295898 -0.99970149993896484 
		-0.97966444492340088 0.97411006689071655 0.99898606538772583 0.9984927773475647 -0.9977758526802063 
		0.98576188087463379 0.9961395263671875 0;
createNode animCurveTL -n "animCurveTL255";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  418 0.22157172858715057 422 -1.601474404335022
		 427 -1.601474404335022 431 6.5124449729919434 450 3.4655857086181641 454 0.60157817602157593
		 477 -1.992306113243103 483 -0.316865473985672 490 0.22157172858715057 517 0.22157172858715057;
	setAttr -s 10 ".ktl[0:9]" no yes yes yes yes yes yes yes yes yes;
	setAttr -s 10 ".kix[0:9]"  1 0.20148129761219025 0.04616759717464447 
		0.18583568930625916 0.16004075109958649 0.20187953114509583 0.79612737894058228 0.23765839636325836 
		0.93476080894470215 1;
	setAttr -s 10 ".kiy[0:9]"  0 -0.9794924259185791 0.99893373250961304 
		0.98258084058761597 -0.98711037635803223 -0.97941035032272339 -0.60512912273406982 
		0.97134882211685181 0.35527780652046204 0;
	setAttr -s 10 ".kox[0:9]"  1 0.20148129761219025 0.04616759717464447 
		0.18583568930625916 0.16004075109958649 0.20187953114509583 0.79612737894058228 0.23765839636325836 
		0.93476080894470215 1;
	setAttr -s 10 ".koy[0:9]"  0 -0.9794924259185791 0.99893373250961304 
		0.98258084058761597 -0.98711037635803223 -0.97941035032272339 -0.60512912273406982 
		0.97134882211685181 0.35527780652046204 0;
createNode animCurveTU -n "animCurveTU256";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU257";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU258";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA256";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  418 0 420 2.7669055461883545 428 2.2511858940124512
		 431 -3.0108215808868408 449 -0.83418542146682739 463 0.68260711431503296 495 -2.1506502628326416
		 517 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99558341503143311 0.97664147615432739 
		0.99811160564422607 0.99883335828781128 0.99992811679840088 0.99998599290847778 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.093880705535411835 -0.21487581729888916 
		-0.061426512897014618 0.048290509730577469 -0.011986956931650639 -0.0052949222736060619 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99558341503143311 0.97664147615432739 
		0.99811160564422607 0.99883335828781128 0.99992811679840088 0.99998599290847778 1;
	setAttr -s 8 ".koy[0:7]"  0 0.093880705535411835 -0.21487581729888916 
		-0.061426512897014618 0.048290509730577469 -0.011986956931650639 -0.0052949222736060619 
		0;
createNode animCurveTA -n "animCurveTA257";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  418 0 420 -7.4300370216369629 428 -9.4605426788330078
		 431 23.034152984619141 449 20.748838424682617 463 -12.584556579589844 495 5.6143102645874023
		 517 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.92966413497924805 0.6529163122177124 
		0.85651826858520508 0.90632843971252441 0.99063652753829956 0.9952690601348877 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.36840835213661194 0.75743013620376587 
		0.5161166787147522 -0.42257401347160339 -0.13652561604976654 0.097156815230846405 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.92966413497924805 0.6529163122177124 
		0.85651826858520508 0.90632843971252441 0.99063652753829956 0.9952690601348877 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.36840835213661194 0.75743013620376587 
		0.5161166787147522 -0.42257401347160339 -0.13652561604976654 0.097156815230846405 
		0;
createNode animCurveTA -n "animCurveTA258";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  418 0 420 -0.18468128144741058 428 -0.038327895104885101
		 431 2.4339675903320313 449 0.41737216711044312 463 2.7138121128082275 495 2.7241580486297607
		 517 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99999868869781494 0.99506497383117676 
		0.99995869398117065 0.99999332427978516 0.99977946281433105 0.99977850914001465 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.0016054681036621332 0.099225640296936035 
		0.0090893013402819633 0.0036631347611546516 0.021001113578677177 -0.021046428009867668 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99999868869781494 0.99506497383117676 
		0.99995869398117065 0.99999332427978516 0.99977946281433105 0.99977850914001465 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.0016054681036621332 0.099225640296936035 
		0.0090893013402819633 0.0036631347611546516 0.021001113578677177 -0.021046428009867668 
		0;
createNode animCurveTL -n "animCurveTL256";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0.55634701251983643 517 0.55634701251983643;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL257";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 28.874954223632813 517 28.874954223632813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL258";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU259";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU260";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU261";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA259";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA260";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA261";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL259";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -1.4725730419158936 517 -1.4725730419158936;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL260";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 25.007797241210938 517 25.007797241210938;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL261";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU262";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU263";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU264";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA262";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA263";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA264";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL262";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -0.28501001000404358 517 -0.28501001000404358;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL263";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL264";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU265";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU266";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU267";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA265";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA266";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 0 422 -11.295269966125488 430 -14.119087219238281
		 434 7.2918925285339347 454 12.644637107849121 487 -11.295269966125488 517 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.89697819948196411 0.83889788389205933 
		0.90602737665176392 0.98938155174255371 0.99648451805114746 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.44207486510276794 0.5442889928817749 
		0.42321905493736267 -0.14534157514572144 -0.08377702534198761 0;
	setAttr -s 7 ".kox[0:6]"  1 0.89697819948196411 0.83889788389205933 
		0.90602737665176392 0.98938155174255371 0.99648451805114746 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.44207486510276794 0.5442889928817749 
		0.42321905493736267 -0.14534157514572144 -0.08377702534198761 0;
createNode animCurveTA -n "animCurveTA267";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL265";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 0 422 -0.11524292081594467 430 -0.14405365288257599
		 434 1.8689652681350708 454 1.5097658634185791 487 -0.11524292081594467 517 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.96091413497924805 0.2443510890007019 
		0.51742541790008545 0.74384504556655884 0.86685049533843994 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.27684637904167175 0.96968686580657959 
		0.85572832822799683 -0.66835206747055054 -0.4985680878162384 0;
	setAttr -s 7 ".kox[0:6]"  1 0.96091413497924805 0.2443510890007019 
		0.51742541790008545 0.74384504556655884 0.86685049533843994 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.27684637904167175 0.96968686580657959 
		0.85572832822799683 -0.66835206747055054 -0.4985680878162384 0;
createNode animCurveTL -n "animCurveTL266";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 0 517 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL267";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  418 0 422 -7.6558980941772461 430 -9.5698728561401367
		 434 -1.3011295795440674 454 4.6103830337524414 487 -7.6558980941772461 517 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.052176129072904587 0.078438654541969299 
		0.070345878601074219 0.32825243473052979 0.49478781223297119 1;
	setAttr -s 7 ".kiy[0:6]"  0 -0.998637855052948 0.99691897630691528 
		0.99752265214920044 -0.94459003210067749 -0.86901384592056274 0;
	setAttr -s 7 ".kox[0:6]"  1 0.052176129072904587 0.078438654541969299 
		0.070345878601074219 0.32825243473052979 0.49478781223297119 1;
	setAttr -s 7 ".koy[0:6]"  0 -0.998637855052948 0.99691897630691528 
		0.99752265214920044 -0.94459003210067749 -0.86901384592056274 0;
createNode animCurveTU -n "animCurveTU268";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU269";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU270";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 1 517 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA268";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 0 424 13.654136657714844 434 -35.549167633056641
		 452 11.849706649780273 480 -9.5792245864868164 517 0;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.73202580213546753 0.99963581562042236 
		0.97315835952758789 0.99709701538085938 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.68127691745758057 -0.026984341442584991 
		0.23013646900653839 -0.076141327619552612 0;
	setAttr -s 6 ".kox[0:5]"  1 0.73202580213546753 0.99963581562042236 
		0.97315835952758789 0.99709701538085938 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.68127691745758057 -0.026984341442584991 
		0.23013646900653839 -0.076141327619552612 0;
createNode animCurveTA -n "animCurveTA269";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 0 424 9.5164518356323242 434 -14.255007743835449
		 452 30.15358924865723 480 16.980428695678711 517 0;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.93688410520553589 0.95549982786178589 
		0.96184909343719482 0.98163849115371704 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.34964004158973694 0.29499191045761108 
		0.27358067035675049 -0.1907506138086319 0;
	setAttr -s 6 ".kox[0:5]"  1 0.93688410520553589 0.95549982786178589 
		0.96184909343719482 0.98163849115371704 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.34964004158973694 0.29499191045761108 
		0.27358067035675049 -0.1907506138086319 0;
createNode animCurveTA -n "animCurveTA270";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  418 0 424 10.520803451538086 434 -8.1382226943969727
		 452 8.7900295257568359 480 -11.919341087341309 517 0;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.97804772853851318 0.99966490268707275 
		0.99940770864486694 0.99839955568313599 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.20838066935539246 -0.025883615016937256 
		-0.034410726279020309 -0.056554894894361496 0;
	setAttr -s 6 ".kox[0:5]"  1 0.97804772853851318 0.99966490268707275 
		0.99940770864486694 0.99839955568313599 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.20838066935539246 -0.025883615016937256 
		-0.034410726279020309 -0.056554894894361496 0;
createNode animCurveTL -n "animCurveTL268";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 2.0856802463531494 517 2.0856802463531494;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL269";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 -5.0555992126464844 517 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL270";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  418 28.250843048095703 517 28.250843048095703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
select -ne :time1;
	setAttr ".o" 517;
	setAttr ".unw" 517;
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
connectAttr "searchingSource.cl" "clipLibrary1.sc[0]";
connectAttr "animCurveTU181.a" "clipLibrary1.cel[0].cev[0].cevr";
connectAttr "animCurveTU182.a" "clipLibrary1.cel[0].cev[1].cevr";
connectAttr "animCurveTU183.a" "clipLibrary1.cel[0].cev[2].cevr";
connectAttr "animCurveTA181.a" "clipLibrary1.cel[0].cev[3].cevr";
connectAttr "animCurveTA182.a" "clipLibrary1.cel[0].cev[4].cevr";
connectAttr "animCurveTA183.a" "clipLibrary1.cel[0].cev[5].cevr";
connectAttr "animCurveTL181.a" "clipLibrary1.cel[0].cev[6].cevr";
connectAttr "animCurveTL182.a" "clipLibrary1.cel[0].cev[7].cevr";
connectAttr "animCurveTL183.a" "clipLibrary1.cel[0].cev[8].cevr";
connectAttr "animCurveTU184.a" "clipLibrary1.cel[0].cev[9].cevr";
connectAttr "animCurveTU185.a" "clipLibrary1.cel[0].cev[10].cevr";
connectAttr "animCurveTU186.a" "clipLibrary1.cel[0].cev[11].cevr";
connectAttr "animCurveTA184.a" "clipLibrary1.cel[0].cev[12].cevr";
connectAttr "animCurveTA185.a" "clipLibrary1.cel[0].cev[13].cevr";
connectAttr "animCurveTA186.a" "clipLibrary1.cel[0].cev[14].cevr";
connectAttr "animCurveTL184.a" "clipLibrary1.cel[0].cev[15].cevr";
connectAttr "animCurveTL185.a" "clipLibrary1.cel[0].cev[16].cevr";
connectAttr "animCurveTL186.a" "clipLibrary1.cel[0].cev[17].cevr";
connectAttr "animCurveTU187.a" "clipLibrary1.cel[0].cev[18].cevr";
connectAttr "animCurveTU188.a" "clipLibrary1.cel[0].cev[19].cevr";
connectAttr "animCurveTU189.a" "clipLibrary1.cel[0].cev[20].cevr";
connectAttr "animCurveTA187.a" "clipLibrary1.cel[0].cev[21].cevr";
connectAttr "animCurveTA188.a" "clipLibrary1.cel[0].cev[22].cevr";
connectAttr "animCurveTA189.a" "clipLibrary1.cel[0].cev[23].cevr";
connectAttr "animCurveTL187.a" "clipLibrary1.cel[0].cev[24].cevr";
connectAttr "animCurveTL188.a" "clipLibrary1.cel[0].cev[25].cevr";
connectAttr "animCurveTL189.a" "clipLibrary1.cel[0].cev[26].cevr";
connectAttr "animCurveTU190.a" "clipLibrary1.cel[0].cev[27].cevr";
connectAttr "animCurveTU191.a" "clipLibrary1.cel[0].cev[28].cevr";
connectAttr "animCurveTU192.a" "clipLibrary1.cel[0].cev[29].cevr";
connectAttr "animCurveTA190.a" "clipLibrary1.cel[0].cev[30].cevr";
connectAttr "animCurveTA191.a" "clipLibrary1.cel[0].cev[31].cevr";
connectAttr "animCurveTA192.a" "clipLibrary1.cel[0].cev[32].cevr";
connectAttr "animCurveTL190.a" "clipLibrary1.cel[0].cev[33].cevr";
connectAttr "animCurveTL191.a" "clipLibrary1.cel[0].cev[34].cevr";
connectAttr "animCurveTL192.a" "clipLibrary1.cel[0].cev[35].cevr";
connectAttr "animCurveTU193.a" "clipLibrary1.cel[0].cev[36].cevr";
connectAttr "animCurveTU194.a" "clipLibrary1.cel[0].cev[37].cevr";
connectAttr "animCurveTU195.a" "clipLibrary1.cel[0].cev[38].cevr";
connectAttr "animCurveTA193.a" "clipLibrary1.cel[0].cev[39].cevr";
connectAttr "animCurveTA194.a" "clipLibrary1.cel[0].cev[40].cevr";
connectAttr "animCurveTA195.a" "clipLibrary1.cel[0].cev[41].cevr";
connectAttr "animCurveTL193.a" "clipLibrary1.cel[0].cev[42].cevr";
connectAttr "animCurveTL194.a" "clipLibrary1.cel[0].cev[43].cevr";
connectAttr "animCurveTL195.a" "clipLibrary1.cel[0].cev[44].cevr";
connectAttr "animCurveTU196.a" "clipLibrary1.cel[0].cev[45].cevr";
connectAttr "animCurveTU197.a" "clipLibrary1.cel[0].cev[46].cevr";
connectAttr "animCurveTU198.a" "clipLibrary1.cel[0].cev[47].cevr";
connectAttr "animCurveTA196.a" "clipLibrary1.cel[0].cev[48].cevr";
connectAttr "animCurveTA197.a" "clipLibrary1.cel[0].cev[49].cevr";
connectAttr "animCurveTA198.a" "clipLibrary1.cel[0].cev[50].cevr";
connectAttr "animCurveTL196.a" "clipLibrary1.cel[0].cev[51].cevr";
connectAttr "animCurveTL197.a" "clipLibrary1.cel[0].cev[52].cevr";
connectAttr "animCurveTL198.a" "clipLibrary1.cel[0].cev[53].cevr";
connectAttr "animCurveTU199.a" "clipLibrary1.cel[0].cev[54].cevr";
connectAttr "animCurveTU200.a" "clipLibrary1.cel[0].cev[55].cevr";
connectAttr "animCurveTU201.a" "clipLibrary1.cel[0].cev[56].cevr";
connectAttr "animCurveTA199.a" "clipLibrary1.cel[0].cev[57].cevr";
connectAttr "animCurveTA200.a" "clipLibrary1.cel[0].cev[58].cevr";
connectAttr "animCurveTA201.a" "clipLibrary1.cel[0].cev[59].cevr";
connectAttr "animCurveTL199.a" "clipLibrary1.cel[0].cev[60].cevr";
connectAttr "animCurveTL200.a" "clipLibrary1.cel[0].cev[61].cevr";
connectAttr "animCurveTL201.a" "clipLibrary1.cel[0].cev[62].cevr";
connectAttr "animCurveTU202.a" "clipLibrary1.cel[0].cev[63].cevr";
connectAttr "animCurveTU203.a" "clipLibrary1.cel[0].cev[64].cevr";
connectAttr "animCurveTU204.a" "clipLibrary1.cel[0].cev[65].cevr";
connectAttr "animCurveTA202.a" "clipLibrary1.cel[0].cev[66].cevr";
connectAttr "animCurveTA203.a" "clipLibrary1.cel[0].cev[67].cevr";
connectAttr "animCurveTA204.a" "clipLibrary1.cel[0].cev[68].cevr";
connectAttr "animCurveTL202.a" "clipLibrary1.cel[0].cev[69].cevr";
connectAttr "animCurveTL203.a" "clipLibrary1.cel[0].cev[70].cevr";
connectAttr "animCurveTL204.a" "clipLibrary1.cel[0].cev[71].cevr";
connectAttr "animCurveTU205.a" "clipLibrary1.cel[0].cev[72].cevr";
connectAttr "animCurveTU206.a" "clipLibrary1.cel[0].cev[73].cevr";
connectAttr "animCurveTU207.a" "clipLibrary1.cel[0].cev[74].cevr";
connectAttr "animCurveTA205.a" "clipLibrary1.cel[0].cev[75].cevr";
connectAttr "animCurveTA206.a" "clipLibrary1.cel[0].cev[76].cevr";
connectAttr "animCurveTA207.a" "clipLibrary1.cel[0].cev[77].cevr";
connectAttr "animCurveTL205.a" "clipLibrary1.cel[0].cev[78].cevr";
connectAttr "animCurveTL206.a" "clipLibrary1.cel[0].cev[79].cevr";
connectAttr "animCurveTL207.a" "clipLibrary1.cel[0].cev[80].cevr";
connectAttr "animCurveTU208.a" "clipLibrary1.cel[0].cev[81].cevr";
connectAttr "animCurveTU209.a" "clipLibrary1.cel[0].cev[82].cevr";
connectAttr "animCurveTU210.a" "clipLibrary1.cel[0].cev[83].cevr";
connectAttr "animCurveTA208.a" "clipLibrary1.cel[0].cev[84].cevr";
connectAttr "animCurveTA209.a" "clipLibrary1.cel[0].cev[85].cevr";
connectAttr "animCurveTA210.a" "clipLibrary1.cel[0].cev[86].cevr";
connectAttr "animCurveTL208.a" "clipLibrary1.cel[0].cev[87].cevr";
connectAttr "animCurveTL209.a" "clipLibrary1.cel[0].cev[88].cevr";
connectAttr "animCurveTL210.a" "clipLibrary1.cel[0].cev[89].cevr";
connectAttr "animCurveTU211.a" "clipLibrary1.cel[0].cev[90].cevr";
connectAttr "animCurveTU212.a" "clipLibrary1.cel[0].cev[91].cevr";
connectAttr "animCurveTU213.a" "clipLibrary1.cel[0].cev[92].cevr";
connectAttr "animCurveTA211.a" "clipLibrary1.cel[0].cev[93].cevr";
connectAttr "animCurveTA212.a" "clipLibrary1.cel[0].cev[94].cevr";
connectAttr "animCurveTA213.a" "clipLibrary1.cel[0].cev[95].cevr";
connectAttr "animCurveTL211.a" "clipLibrary1.cel[0].cev[96].cevr";
connectAttr "animCurveTL212.a" "clipLibrary1.cel[0].cev[97].cevr";
connectAttr "animCurveTL213.a" "clipLibrary1.cel[0].cev[98].cevr";
connectAttr "animCurveTU214.a" "clipLibrary1.cel[0].cev[99].cevr";
connectAttr "animCurveTU215.a" "clipLibrary1.cel[0].cev[100].cevr";
connectAttr "animCurveTU216.a" "clipLibrary1.cel[0].cev[101].cevr";
connectAttr "animCurveTA214.a" "clipLibrary1.cel[0].cev[102].cevr";
connectAttr "animCurveTA215.a" "clipLibrary1.cel[0].cev[103].cevr";
connectAttr "animCurveTA216.a" "clipLibrary1.cel[0].cev[104].cevr";
connectAttr "animCurveTL214.a" "clipLibrary1.cel[0].cev[105].cevr";
connectAttr "animCurveTL215.a" "clipLibrary1.cel[0].cev[106].cevr";
connectAttr "animCurveTL216.a" "clipLibrary1.cel[0].cev[107].cevr";
connectAttr "animCurveTU217.a" "clipLibrary1.cel[0].cev[108].cevr";
connectAttr "animCurveTU218.a" "clipLibrary1.cel[0].cev[109].cevr";
connectAttr "animCurveTU219.a" "clipLibrary1.cel[0].cev[110].cevr";
connectAttr "animCurveTA217.a" "clipLibrary1.cel[0].cev[111].cevr";
connectAttr "animCurveTA218.a" "clipLibrary1.cel[0].cev[112].cevr";
connectAttr "animCurveTA219.a" "clipLibrary1.cel[0].cev[113].cevr";
connectAttr "animCurveTL217.a" "clipLibrary1.cel[0].cev[114].cevr";
connectAttr "animCurveTL218.a" "clipLibrary1.cel[0].cev[115].cevr";
connectAttr "animCurveTL219.a" "clipLibrary1.cel[0].cev[116].cevr";
connectAttr "animCurveTU220.a" "clipLibrary1.cel[0].cev[117].cevr";
connectAttr "animCurveTU221.a" "clipLibrary1.cel[0].cev[118].cevr";
connectAttr "animCurveTU222.a" "clipLibrary1.cel[0].cev[119].cevr";
connectAttr "animCurveTA220.a" "clipLibrary1.cel[0].cev[120].cevr";
connectAttr "animCurveTA221.a" "clipLibrary1.cel[0].cev[121].cevr";
connectAttr "animCurveTA222.a" "clipLibrary1.cel[0].cev[122].cevr";
connectAttr "animCurveTL220.a" "clipLibrary1.cel[0].cev[123].cevr";
connectAttr "animCurveTL221.a" "clipLibrary1.cel[0].cev[124].cevr";
connectAttr "animCurveTL222.a" "clipLibrary1.cel[0].cev[125].cevr";
connectAttr "animCurveTU223.a" "clipLibrary1.cel[0].cev[126].cevr";
connectAttr "animCurveTU224.a" "clipLibrary1.cel[0].cev[127].cevr";
connectAttr "animCurveTU225.a" "clipLibrary1.cel[0].cev[128].cevr";
connectAttr "animCurveTA223.a" "clipLibrary1.cel[0].cev[129].cevr";
connectAttr "animCurveTA224.a" "clipLibrary1.cel[0].cev[130].cevr";
connectAttr "animCurveTA225.a" "clipLibrary1.cel[0].cev[131].cevr";
connectAttr "animCurveTL223.a" "clipLibrary1.cel[0].cev[132].cevr";
connectAttr "animCurveTL224.a" "clipLibrary1.cel[0].cev[133].cevr";
connectAttr "animCurveTL225.a" "clipLibrary1.cel[0].cev[134].cevr";
connectAttr "animCurveTU226.a" "clipLibrary1.cel[0].cev[135].cevr";
connectAttr "animCurveTU227.a" "clipLibrary1.cel[0].cev[136].cevr";
connectAttr "animCurveTU228.a" "clipLibrary1.cel[0].cev[137].cevr";
connectAttr "animCurveTA226.a" "clipLibrary1.cel[0].cev[138].cevr";
connectAttr "animCurveTA227.a" "clipLibrary1.cel[0].cev[139].cevr";
connectAttr "animCurveTA228.a" "clipLibrary1.cel[0].cev[140].cevr";
connectAttr "animCurveTL226.a" "clipLibrary1.cel[0].cev[141].cevr";
connectAttr "animCurveTL227.a" "clipLibrary1.cel[0].cev[142].cevr";
connectAttr "animCurveTL228.a" "clipLibrary1.cel[0].cev[143].cevr";
connectAttr "animCurveTU229.a" "clipLibrary1.cel[0].cev[144].cevr";
connectAttr "animCurveTU230.a" "clipLibrary1.cel[0].cev[145].cevr";
connectAttr "animCurveTU231.a" "clipLibrary1.cel[0].cev[146].cevr";
connectAttr "animCurveTA229.a" "clipLibrary1.cel[0].cev[147].cevr";
connectAttr "animCurveTA230.a" "clipLibrary1.cel[0].cev[148].cevr";
connectAttr "animCurveTA231.a" "clipLibrary1.cel[0].cev[149].cevr";
connectAttr "animCurveTL229.a" "clipLibrary1.cel[0].cev[150].cevr";
connectAttr "animCurveTL230.a" "clipLibrary1.cel[0].cev[151].cevr";
connectAttr "animCurveTL231.a" "clipLibrary1.cel[0].cev[152].cevr";
connectAttr "animCurveTU232.a" "clipLibrary1.cel[0].cev[153].cevr";
connectAttr "animCurveTU233.a" "clipLibrary1.cel[0].cev[154].cevr";
connectAttr "animCurveTU234.a" "clipLibrary1.cel[0].cev[155].cevr";
connectAttr "animCurveTA232.a" "clipLibrary1.cel[0].cev[156].cevr";
connectAttr "animCurveTA233.a" "clipLibrary1.cel[0].cev[157].cevr";
connectAttr "animCurveTA234.a" "clipLibrary1.cel[0].cev[158].cevr";
connectAttr "animCurveTL232.a" "clipLibrary1.cel[0].cev[159].cevr";
connectAttr "animCurveTL233.a" "clipLibrary1.cel[0].cev[160].cevr";
connectAttr "animCurveTL234.a" "clipLibrary1.cel[0].cev[161].cevr";
connectAttr "animCurveTU235.a" "clipLibrary1.cel[0].cev[162].cevr";
connectAttr "animCurveTU236.a" "clipLibrary1.cel[0].cev[163].cevr";
connectAttr "animCurveTU237.a" "clipLibrary1.cel[0].cev[164].cevr";
connectAttr "animCurveTA235.a" "clipLibrary1.cel[0].cev[165].cevr";
connectAttr "animCurveTA236.a" "clipLibrary1.cel[0].cev[166].cevr";
connectAttr "animCurveTA237.a" "clipLibrary1.cel[0].cev[167].cevr";
connectAttr "animCurveTL235.a" "clipLibrary1.cel[0].cev[168].cevr";
connectAttr "animCurveTL236.a" "clipLibrary1.cel[0].cev[169].cevr";
connectAttr "animCurveTL237.a" "clipLibrary1.cel[0].cev[170].cevr";
connectAttr "animCurveTU238.a" "clipLibrary1.cel[0].cev[171].cevr";
connectAttr "animCurveTU239.a" "clipLibrary1.cel[0].cev[172].cevr";
connectAttr "animCurveTU240.a" "clipLibrary1.cel[0].cev[173].cevr";
connectAttr "animCurveTA238.a" "clipLibrary1.cel[0].cev[174].cevr";
connectAttr "animCurveTA239.a" "clipLibrary1.cel[0].cev[175].cevr";
connectAttr "animCurveTA240.a" "clipLibrary1.cel[0].cev[176].cevr";
connectAttr "animCurveTL238.a" "clipLibrary1.cel[0].cev[177].cevr";
connectAttr "animCurveTL239.a" "clipLibrary1.cel[0].cev[178].cevr";
connectAttr "animCurveTL240.a" "clipLibrary1.cel[0].cev[179].cevr";
connectAttr "animCurveTU241.a" "clipLibrary1.cel[0].cev[180].cevr";
connectAttr "animCurveTU242.a" "clipLibrary1.cel[0].cev[181].cevr";
connectAttr "animCurveTU243.a" "clipLibrary1.cel[0].cev[182].cevr";
connectAttr "animCurveTA241.a" "clipLibrary1.cel[0].cev[183].cevr";
connectAttr "animCurveTA242.a" "clipLibrary1.cel[0].cev[184].cevr";
connectAttr "animCurveTA243.a" "clipLibrary1.cel[0].cev[185].cevr";
connectAttr "animCurveTL241.a" "clipLibrary1.cel[0].cev[186].cevr";
connectAttr "animCurveTL242.a" "clipLibrary1.cel[0].cev[187].cevr";
connectAttr "animCurveTL243.a" "clipLibrary1.cel[0].cev[188].cevr";
connectAttr "animCurveTU244.a" "clipLibrary1.cel[0].cev[189].cevr";
connectAttr "animCurveTU245.a" "clipLibrary1.cel[0].cev[190].cevr";
connectAttr "animCurveTU246.a" "clipLibrary1.cel[0].cev[191].cevr";
connectAttr "animCurveTA244.a" "clipLibrary1.cel[0].cev[192].cevr";
connectAttr "animCurveTA245.a" "clipLibrary1.cel[0].cev[193].cevr";
connectAttr "animCurveTA246.a" "clipLibrary1.cel[0].cev[194].cevr";
connectAttr "animCurveTL244.a" "clipLibrary1.cel[0].cev[195].cevr";
connectAttr "animCurveTL245.a" "clipLibrary1.cel[0].cev[196].cevr";
connectAttr "animCurveTL246.a" "clipLibrary1.cel[0].cev[197].cevr";
connectAttr "animCurveTU247.a" "clipLibrary1.cel[0].cev[198].cevr";
connectAttr "animCurveTU248.a" "clipLibrary1.cel[0].cev[199].cevr";
connectAttr "animCurveTU249.a" "clipLibrary1.cel[0].cev[200].cevr";
connectAttr "animCurveTA247.a" "clipLibrary1.cel[0].cev[201].cevr";
connectAttr "animCurveTA248.a" "clipLibrary1.cel[0].cev[202].cevr";
connectAttr "animCurveTA249.a" "clipLibrary1.cel[0].cev[203].cevr";
connectAttr "animCurveTL247.a" "clipLibrary1.cel[0].cev[204].cevr";
connectAttr "animCurveTL248.a" "clipLibrary1.cel[0].cev[205].cevr";
connectAttr "animCurveTL249.a" "clipLibrary1.cel[0].cev[206].cevr";
connectAttr "animCurveTU250.a" "clipLibrary1.cel[0].cev[207].cevr";
connectAttr "animCurveTU251.a" "clipLibrary1.cel[0].cev[208].cevr";
connectAttr "animCurveTU252.a" "clipLibrary1.cel[0].cev[209].cevr";
connectAttr "animCurveTA250.a" "clipLibrary1.cel[0].cev[210].cevr";
connectAttr "animCurveTA251.a" "clipLibrary1.cel[0].cev[211].cevr";
connectAttr "animCurveTA252.a" "clipLibrary1.cel[0].cev[212].cevr";
connectAttr "animCurveTL250.a" "clipLibrary1.cel[0].cev[213].cevr";
connectAttr "animCurveTL251.a" "clipLibrary1.cel[0].cev[214].cevr";
connectAttr "animCurveTL252.a" "clipLibrary1.cel[0].cev[215].cevr";
connectAttr "animCurveTU253.a" "clipLibrary1.cel[0].cev[216].cevr";
connectAttr "animCurveTU254.a" "clipLibrary1.cel[0].cev[217].cevr";
connectAttr "animCurveTU255.a" "clipLibrary1.cel[0].cev[218].cevr";
connectAttr "animCurveTA253.a" "clipLibrary1.cel[0].cev[219].cevr";
connectAttr "animCurveTA254.a" "clipLibrary1.cel[0].cev[220].cevr";
connectAttr "animCurveTA255.a" "clipLibrary1.cel[0].cev[221].cevr";
connectAttr "animCurveTL253.a" "clipLibrary1.cel[0].cev[222].cevr";
connectAttr "animCurveTL254.a" "clipLibrary1.cel[0].cev[223].cevr";
connectAttr "animCurveTL255.a" "clipLibrary1.cel[0].cev[224].cevr";
connectAttr "animCurveTU256.a" "clipLibrary1.cel[0].cev[225].cevr";
connectAttr "animCurveTU257.a" "clipLibrary1.cel[0].cev[226].cevr";
connectAttr "animCurveTU258.a" "clipLibrary1.cel[0].cev[227].cevr";
connectAttr "animCurveTA256.a" "clipLibrary1.cel[0].cev[228].cevr";
connectAttr "animCurveTA257.a" "clipLibrary1.cel[0].cev[229].cevr";
connectAttr "animCurveTA258.a" "clipLibrary1.cel[0].cev[230].cevr";
connectAttr "animCurveTL256.a" "clipLibrary1.cel[0].cev[231].cevr";
connectAttr "animCurveTL257.a" "clipLibrary1.cel[0].cev[232].cevr";
connectAttr "animCurveTL258.a" "clipLibrary1.cel[0].cev[233].cevr";
connectAttr "animCurveTU259.a" "clipLibrary1.cel[0].cev[234].cevr";
connectAttr "animCurveTU260.a" "clipLibrary1.cel[0].cev[235].cevr";
connectAttr "animCurveTU261.a" "clipLibrary1.cel[0].cev[236].cevr";
connectAttr "animCurveTA259.a" "clipLibrary1.cel[0].cev[237].cevr";
connectAttr "animCurveTA260.a" "clipLibrary1.cel[0].cev[238].cevr";
connectAttr "animCurveTA261.a" "clipLibrary1.cel[0].cev[239].cevr";
connectAttr "animCurveTL259.a" "clipLibrary1.cel[0].cev[240].cevr";
connectAttr "animCurveTL260.a" "clipLibrary1.cel[0].cev[241].cevr";
connectAttr "animCurveTL261.a" "clipLibrary1.cel[0].cev[242].cevr";
connectAttr "animCurveTU262.a" "clipLibrary1.cel[0].cev[243].cevr";
connectAttr "animCurveTU263.a" "clipLibrary1.cel[0].cev[244].cevr";
connectAttr "animCurveTU264.a" "clipLibrary1.cel[0].cev[245].cevr";
connectAttr "animCurveTA262.a" "clipLibrary1.cel[0].cev[246].cevr";
connectAttr "animCurveTA263.a" "clipLibrary1.cel[0].cev[247].cevr";
connectAttr "animCurveTA264.a" "clipLibrary1.cel[0].cev[248].cevr";
connectAttr "animCurveTL262.a" "clipLibrary1.cel[0].cev[249].cevr";
connectAttr "animCurveTL263.a" "clipLibrary1.cel[0].cev[250].cevr";
connectAttr "animCurveTL264.a" "clipLibrary1.cel[0].cev[251].cevr";
connectAttr "animCurveTU265.a" "clipLibrary1.cel[0].cev[252].cevr";
connectAttr "animCurveTU266.a" "clipLibrary1.cel[0].cev[253].cevr";
connectAttr "animCurveTU267.a" "clipLibrary1.cel[0].cev[254].cevr";
connectAttr "animCurveTA265.a" "clipLibrary1.cel[0].cev[255].cevr";
connectAttr "animCurveTA266.a" "clipLibrary1.cel[0].cev[256].cevr";
connectAttr "animCurveTA267.a" "clipLibrary1.cel[0].cev[257].cevr";
connectAttr "animCurveTL265.a" "clipLibrary1.cel[0].cev[258].cevr";
connectAttr "animCurveTL266.a" "clipLibrary1.cel[0].cev[259].cevr";
connectAttr "animCurveTL267.a" "clipLibrary1.cel[0].cev[260].cevr";
connectAttr "animCurveTU268.a" "clipLibrary1.cel[0].cev[261].cevr";
connectAttr "animCurveTU269.a" "clipLibrary1.cel[0].cev[262].cevr";
connectAttr "animCurveTU270.a" "clipLibrary1.cel[0].cev[263].cevr";
connectAttr "animCurveTA268.a" "clipLibrary1.cel[0].cev[264].cevr";
connectAttr "animCurveTA269.a" "clipLibrary1.cel[0].cev[265].cevr";
connectAttr "animCurveTA270.a" "clipLibrary1.cel[0].cev[266].cevr";
connectAttr "animCurveTL268.a" "clipLibrary1.cel[0].cev[267].cevr";
connectAttr "animCurveTL269.a" "clipLibrary1.cel[0].cev[268].cevr";
connectAttr "animCurveTL270.a" "clipLibrary1.cel[0].cev[269].cevr";
// End of bat_searching.ma
