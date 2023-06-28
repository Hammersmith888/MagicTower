//Maya ASCII 2013 scene
//Name: bat_get_hit_from_right.ma
//Last modified: Sat, Jul 12, 2014 02:47:09 PM
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
createNode animClip -n "get_hit_from_rightSource";
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
	setAttr ".ss" 131;
	setAttr ".se" 150;
	setAttr ".ci" no;
createNode animCurveTU -n "animCurveTU1621";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 1 134 1 150 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1622";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 1 134 1 150 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1623";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 1 134 1 150 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1621";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  131 0 133 39.619606018066406 134 32.245456695556641
		 136 35.355297088623047 137 35.464763641357422 138 35.242599487304688 139 34.608230590820312
		 140 33.595489501953125 141 32.230609893798828 142 30.544742584228512 143 28.584892272949219
		 146 16.884159088134766 150 0;
	setAttr -s 13 ".ktl[0:12]" no yes yes yes yes yes yes yes yes yes yes 
		yes no;
	setAttr -s 13 ".kix[0:12]"  1 0.21682421863079071 0.85922819375991821 
		0.91209203004837036 0.99972152709960938 0.98428744077682495 0.94533169269561768 0.89515411853790283 
		0.84267306327819824 0.79479861259460449 0.57293504476547241 0.50469863414764404 1;
	setAttr -s 13 ".kiy[0:12]"  0 0.97621071338653564 -0.5115925669670105 
		0.40998539328575134 -0.023596569895744324 -0.17657364904880524 -0.32611045241355896 
		-0.44575667381286621 -0.53842568397521973 -0.6068732738494873 -0.81960082054138184 
		-0.86329555511474609 0;
	setAttr -s 13 ".kox[0:12]"  1 0.21682421863079071 0.85922819375991821 
		0.91209203004837036 0.99972152709960938 0.98428744077682495 0.94533169269561768 0.89515411853790283 
		0.84267306327819824 0.79479861259460449 0.57293504476547241 0.50469863414764404 1;
	setAttr -s 13 ".koy[0:12]"  0 0.97621071338653564 -0.5115925669670105 
		0.40998539328575134 -0.023596569895744324 -0.17657364904880524 -0.32611045241355896 
		-0.44575667381286621 -0.53842568397521973 -0.6068732738494873 -0.81960082054138184 
		-0.86329555511474609 0;
createNode animCurveTA -n "animCurveTA1622";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  131 0 133 24.502923965454102 134 33.460456848144531
		 136 30.12101936340332 137 29.987369537353512 138 30.257314682006832 139 31.000873565673828
		 140 32.110897064208984 141 33.474544525146484 142 34.978790283203125 143 36.515987396240234
		 150 0;
	setAttr -s 12 ".ktl[0:11]" no yes yes yes yes yes yes yes yes yes yes 
		no;
	setAttr -s 12 ".kix[0:11]"  1 0.20930202305316925 0.78680741786956787 
		0.8997836709022522 0.99959284067153931 0.97820484638214111 0.93221741914749146 0.8879123330116272 
		0.8572460412979126 0.84341949224472046 0.47922459244728088 1;
	setAttr -s 12 ".kiy[0:11]"  0 0.97785109281539917 0.61719852685928345 
		-0.43633624911308289 0.028534065932035446 0.2076420783996582 0.36189854145050049 
		0.46001270413398743 0.51490700244903564 0.53725564479827881 -0.87769234180450439 
		0;
	setAttr -s 12 ".kox[0:11]"  1 0.20930202305316925 0.78680741786956787 
		0.8997836709022522 0.99959284067153931 0.97820484638214111 0.93221741914749146 0.8879123330116272 
		0.8572460412979126 0.84341949224472046 0.47922459244728088 1;
	setAttr -s 12 ".koy[0:11]"  0 0.97785109281539917 0.61719852685928345 
		-0.43633624911308289 0.028534065932035446 0.2076420783996582 0.36189854145050049 
		0.46001270413398743 0.51490700244903564 0.53725564479827881 -0.87769234180450439 
		0;
createNode animCurveTA -n "animCurveTA1623";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  131 0 133 34.427085876464844 134 26.923349380493164
		 136 32.786167144775391 137 33.003360748291016 138 32.563453674316406 139 31.325998306274414
		 140 29.402345657348633 141 26.896574020385742 142 23.915369033813477 143 20.577545166015625
		 150 0;
	setAttr -s 12 ".ktl[0:11]" no yes yes yes yes yes yes yes yes yes yes 
		no;
	setAttr -s 12 ".kix[0:11]"  1 0.25707334280014038 0.97474318742752075 
		0.76234167814254761 0.99891394376754761 0.943473219871521 0.83381873369216919 0.73311388492584229 
		0.65644079446792603 0.60285568237304688 0.62402361631393433 1;
	setAttr -s 12 ".kiy[0:11]"  0 0.966391921043396 -0.2233288437128067 
		0.64717471599578857 -0.046593755483627319 -0.3314487636089325 -0.55203825235366821 
		-0.68010592460632324 -0.75437760353088379 -0.79785025119781494 -0.78140544891357422 
		0;
	setAttr -s 12 ".kox[0:11]"  1 0.25707334280014038 0.97474318742752075 
		0.76234167814254761 0.99891394376754761 0.943473219871521 0.83381873369216919 0.73311388492584229 
		0.65644079446792603 0.60285568237304688 0.62402361631393433 1;
	setAttr -s 12 ".koy[0:11]"  0 0.966391921043396 -0.2233288437128067 
		0.64717471599578857 -0.046593755483627319 -0.3314487636089325 -0.55203825235366821 
		-0.68010592460632324 -0.75437760353088379 -0.79785025119781494 -0.78140544891357422 
		0;
createNode animCurveTL -n "animCurveTL1621";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 -5.7247552871704102 134 -5.7247552871704102
		 140 -5.7247552871704102 150 -5.7247552871704102;
	setAttr -s 4 ".kix[0:3]"  1 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  1 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL1622";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  131 12.644636154174805 133 18.10240364074707
		 134 24.688671112060547 136 29.429376602172852 137 30.167373657226563 138 30.610946655273437
		 139 30.673151016235352 140 30.228012084960937 141 29.118122100830078 142 26.733283996582031
		 143 22.900407791137695 146 16.791336059570313 150 12.644636154174805;
	setAttr -s 13 ".ktl[0:12]" no yes yes yes yes yes yes yes yes yes yes 
		yes no;
	setAttr -s 13 ".kix[0:12]"  1 0.010378020815551281 0.011034932918846607 
		0.02280968613922596 0.070352979004383087 0.16257080435752869 0.2126411497592926 0.053512923419475555 
		0.023838574066758156 0.013401391915977001 0.01676165871322155 0.028427764773368835 
		1;
	setAttr -s 13 ".kiy[0:12]"  0 0.99994611740112305 0.99993914365768433 
		0.99973982572555542 0.99752223491668701 0.98669689893722534 -0.97713029384613037 
		-0.99856710433959961 -0.99971580505371094 -0.99991023540496826 -0.9998595118522644 
		-0.99959582090377808 0;
	setAttr -s 13 ".kox[0:12]"  1 0.010378020815551281 0.011034932918846607 
		0.02280968613922596 0.070352979004383087 0.16257080435752869 0.2126411497592926 0.053512923419475555 
		0.023838574066758156 0.013401391915977001 0.01676165871322155 0.028427764773368835 
		1;
	setAttr -s 13 ".koy[0:12]"  0 0.99994611740112305 0.99993914365768433 
		0.99973982572555542 0.99752223491668701 0.98669689893722534 -0.97713029384613037 
		-0.99856710433959961 -0.99971580505371094 -0.99991023540496826 -0.9998595118522644 
		-0.99959582090377808 0;
createNode animCurveTL -n "animCurveTL1623";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  131 43.253993988037109 133 66.004104614257813
		 134 54.124992370605469 136 46.806781768798828 137 46.212406158447266 138 46.630016326904297
		 139 48.404182434082031 140 51.34222412109375 141 55.220218658447266 142 59.931079864501953
		 143 65.113739013671875 146 44.580551147460938 150 43.253993988037109;
	setAttr -s 13 ".ktl[0:12]" no yes yes yes yes yes yes yes yes yes yes 
		yes no;
	setAttr -s 13 ".kix[0:12]"  1 0.011497721076011658 0.0065111881121993065 
		0.015795644372701645 0.42642372846603394 0.037993282079696655 0.017681831493973732 
		0.012225181795656681 0.0097020063549280167 0.0084227370098233223 0.010856769979000092 
		0.013341438956558704 1;
	setAttr -s 13 ".kiy[0:12]"  0 0.99993389844894409 -0.99997884035110474 
		-0.99987518787384033 -0.90452355146408081 0.99927800893783569 0.99984365701675415 
		0.99992525577545166 0.99995291233062744 0.99996453523635864 -0.99994105100631714 
		-0.99991101026535034 0;
	setAttr -s 13 ".kox[0:12]"  1 0.011497721076011658 0.0065111881121993065 
		0.015795644372701645 0.42642372846603394 0.037993282079696655 0.017681831493973732 
		0.012225181795656681 0.0097020063549280167 0.0084227370098233223 0.010856769979000092 
		0.013341438956558704 1;
	setAttr -s 13 ".koy[0:12]"  0 0.99993389844894409 -0.99997884035110474 
		-0.99987518787384033 -0.90452355146408081 0.99927800893783569 0.99984365701675415 
		0.99992525577545166 0.99995291233062744 0.99996453523635864 -0.99994105100631714 
		-0.99991101026535034 0;
createNode animCurveTU -n "animCurveTU1624";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1625";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1626";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1624";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1625";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1626";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1624";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -1.9167585372924805 150 -1.9167585372924805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1625";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -5.0555992126464844 150 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1626";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 28.262805938720703 150 28.262805938720703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1627";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1628";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1629";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1627";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  131 0 133 37.736118316650391 137 -8.8350372314453125
		 140 -12.442283630371094 145 -7.5144972801208496 150 0;
	setAttr -s 6 ".ktl[0:5]" no yes yes yes yes no;
	setAttr -s 6 ".kix[0:5]"  1 0.85111945867538452 0.31597498059272766 
		0.99761813879013062 0.88678765296936035 1;
	setAttr -s 6 ".kiy[0:5]"  0 -0.52497208118438721 -0.94876748323440552 
		0.068978682160377502 0.46217706799507141 0;
	setAttr -s 6 ".kox[0:5]"  1 0.85111945867538452 0.31597498059272766 
		0.99761813879013062 0.88678765296936035 1;
	setAttr -s 6 ".koy[0:5]"  0 -0.52497208118438721 -0.94876748323440552 
		0.068978682160377502 0.46217706799507141 0;
createNode animCurveTA -n "animCurveTA1628";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1629";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1627";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -5.7247552871704102 150 -5.7247552871704102;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1628";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 12.644636154174805 133 11.685108184814453
		 145 12.531750679016113 150 12.644636154174805;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.9817853569984436 0.59391236305236816 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.18999342620372772 0.80452972650527954 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9817853569984436 0.59391236305236816 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.18999342620372772 0.80452972650527954 
		0;
createNode animCurveTL -n "animCurveTL1629";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 -43.253993988037109 133 -39.143344879150391
		 145 -42.770389556884766 150 -43.253993988037109;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.76984483003616333 0.16981405019760132 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.63823109865188599 -0.98547613620758057 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.76984483003616333 0.16981405019760132 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.63823109865188599 -0.98547613620758057 
		0;
createNode animCurveTU -n "animCurveTU1630";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1631";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1632";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1630";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0.0048254411667585373 132 0 133 0 150 0.0048254411667585373;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.0010106412228196859 0.00011229312804061919 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0010106412228196859 0.00011229312804061919 
		0;
createNode animCurveTA -n "animCurveTA1631";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 1.5292341709136963 132 0 133 0 150 1.5292341709136963;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.95234578847885132 0.99936741590499878 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.30502042174339294 0.035564377903938293 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.95234578847885132 0.99936741590499878 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.30502042174339294 0.035564377903938293 
		0;
createNode animCurveTA -n "animCurveTA1632";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 1.0246820449829102 132 0 133 0 150 1.0246820449829102;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.97773748636245728 0.99971580505371094 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20983199775218964 0.02383865974843502 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.97773748636245728 0.99971580505371094 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20983199775218964 0.02383865974843502 
		0;
createNode animCurveTL -n "animCurveTL1630";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -0.72905689477920532 150 -0.72905689477920532;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1631";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -19.141372680664063 150 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1632";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 23.549764633178711 150 23.549764633178711;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1633";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1634";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1635";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1633";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 135 48.803955078125 139 45.211563110351562
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99264174699783325 0.66618186235427856 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.12108851224184036 -0.74578922986984253 
		0;
	setAttr -s 4 ".kox[0:3]"  1 1 0.66030508279800415 1;
	setAttr -s 4 ".koy[0:3]"  0 0 -0.75099748373031616 0;
createNode animCurveTA -n "animCurveTA1634";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 135 7.8941469192504883 139 4.8596096038818359
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99980539083480835 0.87478643655776978 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.019727680832147598 -0.4845086932182312 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999493360519409 0.87484389543533325 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0031797292176634073 -0.48440492153167725 
		0;
createNode animCurveTA -n "animCurveTA1635";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 12.527528762817383 135 12.848789215087891
		 139 16.789255142211914 150 12.527528762817383;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99502593278884888 0.99995905160903931 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.099616475403308868 0.0090480344370007515 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99409466981887817 0.99999898672103882 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.10851606726646423 -0.0014143717708066106 
		0;
createNode animCurveTL -n "animCurveTL1633";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -36.1805419921875 150 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1634";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 7.3658723831176758 135 14.093894958496094
		 150 7.3658723831176758;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.72011595964431763 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.69385379552841187 0;
	setAttr -s 3 ".kox[0:2]"  1 0.99764251708984375 1;
	setAttr -s 3 ".koy[0:2]"  0 -0.068624839186668396 0;
createNode animCurveTL -n "animCurveTL1635";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 41.597393035888672 150 41.597393035888672;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1636";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1637";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1638";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1636";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0.0048254411667585373 132 0 133 0 150 0.0048254411667585373;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.0010106412228196859 0.00011229312804061919 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0010106412228196859 0.00011229312804061919 
		0;
createNode animCurveTA -n "animCurveTA1637";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 1.5292341709136963 132 0 133 0 150 1.5292341709136963;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.95234578847885132 0.99936741590499878 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.30502042174339294 0.035564377903938293 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.95234578847885132 0.99936741590499878 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.30502042174339294 0.035564377903938293 
		0;
createNode animCurveTA -n "animCurveTA1638";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 1.0246820449829102 132 0 133 0 150 1.0246820449829102;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.97773748636245728 0.99971580505371094 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20983199775218964 0.02383865974843502 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.97773748636245728 0.99971580505371094 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20983199775218964 0.02383865974843502 
		0;
createNode animCurveTL -n "animCurveTL1636";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -0.11375267058610916 150 -0.11375267058610916;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1637";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -0.067464433610439301 150 -0.067464433610439301;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1638";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 41.135360717773437 150 41.135360717773437;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1639";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1640";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1641";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1639";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 0 135 11.779682159423828 150 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1640";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 0 135 4.8939657211303711 150 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1641";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 12.527528762817383 135 6.8276810646057129
		 150 12.527528762817383;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1639";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -54.695327758789062 150 -54.695327758789062;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1640";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 3.2521772384643555 150 3.2521772384643555;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1641";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1642";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1643";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1644";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1642";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0.0048254411667585373 132 0 133 0 150 0.0048254411667585373;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.0010106412228196859 0.00011229312804061919 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999946355819702 1 1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0010106412228196859 0.00011229312804061919 
		0;
createNode animCurveTA -n "animCurveTA1643";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 1.5292341709136963 132 0 133 0 150 1.5292341709136963;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.95234578847885132 0.99936741590499878 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.30502042174339294 0.035564377903938293 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.95234578847885132 0.99936741590499878 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.30502042174339294 0.035564377903938293 
		0;
createNode animCurveTA -n "animCurveTA1644";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 1.0246820449829102 132 0 133 0 150 1.0246820449829102;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.97773748636245728 0.99971580505371094 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.20983199775218964 0.02383865974843502 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.97773748636245728 0.99971580505371094 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.20983199775218964 0.02383865974843502 
		0;
createNode animCurveTL -n "animCurveTL1642";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -2.6052179336547852 150 -2.6052179336547852;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1643";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -19.141372680664063 150 -19.141372680664063;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1644";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 23.227632522583008 150 23.227632522583008;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1645";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1646";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1647";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1645";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1646";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1647";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 12.527528762817383 150 12.527528762817383;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1645";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -36.1805419921875 150 -36.1805419921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1646";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 7.3658723831176758 150 7.3658723831176758;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1647";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -41.399761199951172 150 -41.399761199951172;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1648";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1649";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1650";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1648";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1649";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1650";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1648";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 22.400806427001953 150 22.400806427001953;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1649";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 10.647112846374512 150 10.647112846374512;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1650";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1651";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1652";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1653";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1651";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1652";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1653";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1651";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 35.083248138427734 150 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1652";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 30.643020629882813 150 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1653";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 36.804916381835937 150 36.804916381835937;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1654";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1655";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1656";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1654";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1655";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1656";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1654";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 35.083248138427734 150 35.083248138427734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1655";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 30.643020629882813 150 30.643020629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1656";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -36.361770629882813 150 -36.361770629882813;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1657";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1658";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1659";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1657";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1658";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1659";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1657";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -5.8221402168273926 150 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1658";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -10.433219909667969 150 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1659";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -28.427871704101563 150 -28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1660";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1661";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1662";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1660";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 133 22.765649795532227 136 -11.962922096252441
		 139 -16.684890747070312 141 -16.049772262573242 144 -12.950023651123047 147 0.82227158546447754
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.70632761716842651 0.34128627181053162 
		0.94608467817306519 0.95437353849411011 0.64719474315643311 0.74178659915924072 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.7078850269317627 -0.93995946645736694 
		-0.3239193856716156 0.2986152172088623 0.76232469081878662 0.67063599824905396 0;
	setAttr -s 8 ".kox[0:7]"  1 0.70632761716842651 0.34128627181053162 
		0.94608467817306519 0.95437353849411011 0.64719474315643311 0.74178659915924072 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.7078850269317627 -0.93995946645736694 
		-0.3239193856716156 0.2986152172088623 0.76232469081878662 0.67063599824905396 0;
createNode animCurveTA -n "animCurveTA1661";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 133 10.220004081726074 136 0.21278534829616547
		 139 -1.7370536327362061 141 -2.3446319103240967 144 -3.2371189594268799 147 0.67567956447601318
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99984121322631836 0.76768231391906738 
		0.97780966758728027 0.99219590425491333 0.9784843921661377 0.97540175914764404 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.017823461443185806 -0.6408306360244751 
		-0.20949527621269226 -0.12468836456537247 0.20632079243659973 0.22043450176715851 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99984121322631836 0.76768231391906738 
		0.97780966758728027 0.99219590425491333 0.9784843921661377 0.97540175914764404 1;
	setAttr -s 8 ".koy[0:7]"  0 0.017823461443185806 -0.6408306360244751 
		-0.20949527621269226 -0.12468836456537247 0.20632079243659973 0.22043450176715851 
		0;
createNode animCurveTA -n "animCurveTA1662";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 133 12.242433547973633 136 19.712648391723633
		 139 17.095508575439453 141 14.76383590698242 144 13.207479476928711 147 5.5054006576538086
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.51796972751617432 0.94711613655090332 
		0.92375636100769043 0.95083194971084595 0.83983749151229858 0.73517733812332153 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.85539889335632324 0.32089102268218994 
		-0.38298052549362183 -0.30970743298530579 -0.54283797740936279 -0.67787474393844604 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.51796972751617432 0.94711613655090332 
		0.92375636100769043 0.95083194971084595 0.83983749151229858 0.73517733812332153 1;
	setAttr -s 8 ".koy[0:7]"  0 0.85539889335632324 0.32089102268218994 
		-0.38298052549362183 -0.30970743298530579 -0.54283797740936279 -0.67787474393844604 
		0;
createNode animCurveTL -n "animCurveTL1660";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 11.41090202331543 136 10.480576515197754
		 150 11.41090202331543;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1661";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 -0.91886520385742188 136 -0.36813303828239441
		 150 -0.91886520385742188;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1662";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 -13.740226745605469 136 -18.447288513183594
		 150 -13.740226745605469;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1663";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1664";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1665";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1663";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 132 22.765649795532227 135 -11.962922096252441
		 138 -16.684890747070312 140 -16.049772262573242 143 -12.950023651123047 146 0.82227158546447754
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.62385618686676025 0.34128627181053162 
		0.94608467817306519 0.95437353849411011 0.64719474315643311 0.79044264554977417 1;
	setAttr -s 8 ".kiy[0:7]"  0 -0.7815392017364502 -0.93995946645736694 
		-0.3239193856716156 0.2986152172088623 0.76232469081878662 0.61253613233566284 0;
	setAttr -s 8 ".kox[0:7]"  1 0.62385618686676025 0.34128627181053162 
		0.94608467817306519 0.95437353849411011 0.64719474315643311 0.79044264554977417 1;
	setAttr -s 8 ".koy[0:7]"  0 -0.7815392017364502 -0.93995946645736694 
		-0.3239193856716156 0.2986152172088623 0.76232469081878662 0.61253613233566284 0;
createNode animCurveTA -n "animCurveTA1664";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 132 10.220004081726074 135 0.21278534829616547
		 138 -1.7370536327362061 140 -2.3446319103240967 143 -3.2371189594268799 146 0.67567956447601318
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99975186586380005 0.76768231391906738 
		0.97780966758728027 0.99219590425491333 0.9784843921661377 0.98175042867660522 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.022277319803833961 -0.6408306360244751 
		-0.20949527621269226 -0.12468836456537247 0.20632079243659973 0.19017377495765686 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99975186586380005 0.76768231391906738 
		0.97780966758728027 0.99219590425491333 0.9784843921661377 0.98175042867660522 1;
	setAttr -s 8 ".koy[0:7]"  0 0.022277319803833961 -0.6408306360244751 
		-0.20949527621269226 -0.12468836456537247 0.20632079243659973 0.19017377495765686 
		0;
createNode animCurveTA -n "animCurveTA1665";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 132 12.242433547973633 135 19.712648391723633
		 138 17.095508575439453 140 14.76383590698242 143 13.207479476928711 146 5.5054006576538086
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.435964435338974 0.94711613655090332 
		0.92375636100769043 0.95083194971084595 0.83983749151229858 0.78455436229705811 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.89996391534805298 0.32089102268218994 
		-0.38298052549362183 -0.30970743298530579 -0.54283797740936279 -0.6200600266456604 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.435964435338974 0.94711613655090332 
		0.92375636100769043 0.95083194971084595 0.83983749151229858 0.78455436229705811 1;
	setAttr -s 8 ".koy[0:7]"  0 0.89996391534805298 0.32089102268218994 
		-0.38298052549362183 -0.30970743298530579 -0.54283797740936279 -0.6200600266456604 
		0;
createNode animCurveTL -n "animCurveTL1663";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 0.057151313871145248 135 -0.87317442893981934
		 150 0.057151313871145248;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1664";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 23.729547500610352 135 24.280279159545898
		 150 23.729547500610352;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1665";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 -53.338920593261719 135 -58.045982360839844
		 150 -53.338920593261719;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU1666";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1667";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1668";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1666";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1667";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1668";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1666";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -5.8221402168273926 150 -5.8221402168273926;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1667";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -10.433219909667969 150 -10.433219909667969;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1668";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 28.427871704101563 150 28.427871704101563;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1669";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1670";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1671";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1669";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  131 0 132 -3.4822049140930176 134 28.589834213256836
		 136 27.184732437133789 139 3.9386708736419678 141 -1.8728444576263428 144 6.4158225059509277
		 147 -3.7560007572174077 150 0;
	setAttr -s 9 ".ktl[0:8]" no yes yes yes yes yes yes yes no;
	setAttr -s 9 ".kix[0:8]"  1 0.24299916625022888 0.29730686545372009 
		0.43581601977348328 0.3799806535243988 0.97913813591003418 0.99146842956542969 0.91263431310653687 
		1;
	setAttr -s 9 ".kiy[0:8]"  0 0.97002649307250977 0.95478194952011108 
		-0.9000357985496521 -0.92499440908432007 0.20319584012031555 -0.13034747540950775 
		-0.40877699851989746 0;
	setAttr -s 9 ".kox[0:8]"  1 0.24299916625022888 0.29730686545372009 
		0.43581601977348328 0.3799806535243988 0.97913813591003418 0.99146842956542969 0.91263431310653687 
		1;
	setAttr -s 9 ".koy[0:8]"  0 0.97002649307250977 0.95478194952011108 
		-0.9000357985496521 -0.92499440908432007 0.20319584012031555 -0.13034747540950775 
		-0.40877699851989746 0;
createNode animCurveTA -n "animCurveTA1670";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 134 -0.17859935760498047 136 0.18131028115749359
		 139 -1.9616516828536987 141 -2.4973921775817871 144 -6.8123245239257813 147 1.0975222587585449
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.99988466501235962 0.98902660608291626 
		0.97573280334472656 0.92642819881439209 0.96992015838623047 0.90307092666625977 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.015187686309218407 -0.14773769676685333 
		-0.21896451711654663 -0.37647145986557007 0.24342314898967743 0.42949151992797852 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.99988466501235962 0.98902660608291626 
		0.97573280334472656 0.92642819881439209 0.96992015838623047 0.90307092666625977 1;
	setAttr -s 8 ".koy[0:7]"  0 0.015187686309218407 -0.14773769676685333 
		-0.21896451711654663 -0.37647145986557007 0.24342314898967743 0.42949151992797852 
		0;
createNode animCurveTA -n "animCurveTA1671";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 8 ".ktv[0:7]"  131 0 134 9.4982233047485352 136 9.7092819213867188
		 139 5.0221700668334961 141 3.8503921031951904 144 7.9581441879272461 147 0.8807712197303772
		 150 0;
	setAttr -s 8 ".ktl[0:7]" no yes yes yes yes yes yes no;
	setAttr -s 8 ".kix[0:7]"  1 0.77577060461044312 0.93633359670639038 
		0.89769470691680908 0.97105777263641357 0.97917830944061279 0.87414693832397461 1;
	setAttr -s 8 ".kiy[0:7]"  0 0.63101506233215332 -0.35111153125762939 
		-0.44061803817749023 0.23884472250938416 -0.20300191640853882 -0.48566144704818726 
		0;
	setAttr -s 8 ".kox[0:7]"  1 0.77577060461044312 0.93633359670639038 
		0.89769470691680908 0.97105777263641357 0.97917830944061279 0.87414693832397461 1;
	setAttr -s 8 ".koy[0:7]"  0 0.63101506233215332 -0.35111153125762939 
		-0.44061803817749023 0.23884472250938416 -0.20300191640853882 -0.48566144704818726 
		0;
createNode animCurveTL -n "animCurveTL1669";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 11.41090202331543 150 11.41090202331543;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1670";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -0.91886520385742188 150 -0.91886520385742188;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1671";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 13.740226745605469 150 13.740226745605469;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1672";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1673";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1674";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1672";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 0 139 28.076295852661133 150 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1673";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 0 139 -0.91597795486450206 150 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1674";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 0 139 25.420085906982422 150 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1672";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0.057151321321725845 150 0.057151321321725845;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1673";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 23.729547500610352 150 23.729547500610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1674";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 53.782066345214844 150 53.782066345214844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1675";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1676";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1677";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1675";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -2.2864804267883301 139 1.4355851411819458
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99597698450088501 0.99999535083770752 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.089609161019325256 0.0030447933822870255 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999535083770752 0.99999988079071045 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.0030447933822870255 -0.00047643901780247688 
		0;
createNode animCurveTA -n "animCurveTA1676";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -19.85368537902832 139 26.865106582641602
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.78803342580795288 0.99927043914794922 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.61563241481781006 0.038190063089132309 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99927043914794922 0.99996024370193481 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.038190063089132309 -0.008915584534406662 
		0;
createNode animCurveTA -n "animCurveTA1677";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 25.199235916137695 139 20.798006057739258
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.71009373664855957 0.78603971004486084 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.70410716533660889 -0.61817604303359985 
		0;
	setAttr -s 4 ".kox[0:3]"  1 1 0.78367376327514648 1;
	setAttr -s 4 ".koy[0:3]"  0 0 -0.62117254734039307 0;
createNode animCurveTL -n "animCurveTL1675";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -1.1630247831344604 150 -1.1630247831344604;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1676";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1.228269100189209 150 1.228269100189209;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1677";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 27.684015274047852 150 27.684015274047852;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1678";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1679";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1680";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1678";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 7.0856752395629883 139 -3.1460318565368652
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.96325969696044922 0.99996495246887207 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.26857170462608337 -0.0083696786314249039 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99996495246887207 0.99999946355819702 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.0083696786314249039 0.001044098287820816 
		0;
createNode animCurveTA -n "animCurveTA1679";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -32.147499084472656 139 -19.573524475097656
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.62015348672866821 0.42878401279449463 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.7844805121421814 0.90340697765350342 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999982118606567 0.42812606692314148 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.00065818039001896977 0.90371900796890259 
		0;
createNode animCurveTA -n "animCurveTA1680";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -6.6503844261169434 139 33.487216949462891
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.96742385625839233 0.99946141242980957 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.25316241383552551 0.032816573977470398 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99946141242980957 0.9999382495880127 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.032816573977470398 -0.01111298706382513 
		0;
createNode animCurveTL -n "animCurveTL1678";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 4.9883952140808105 150 4.9883952140808105;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1679";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 41.4617919921875 150 41.4617919921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1680";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 38.623714447021484 150 38.623714447021484;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1681";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1682";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1683";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1681";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -2.2864804267883301 139 1.41950523853302
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99597698450088501 0.99999547004699707 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.089609161019325256 0.0030316396150738001 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99999547004699707 0.99999988079071045 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.0030316396150738001 -0.00047110256855376065 
		0;
createNode animCurveTA -n "animCurveTA1682";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -19.85368537902832 139 26.731874465942383
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.78803342580795288 0.9992746114730835 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.61563241481781006 0.038081314414739609 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9992746114730835 0.99996072053909302 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.038081314414739609 -0.008871372789144516 
		0;
createNode animCurveTA -n "animCurveTA1683";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 25.199235916137695 139 21.215654373168945
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.71009373664855957 0.81468439102172852 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.70410716533660889 -0.57990467548370361 
		0;
	setAttr -s 4 ".kox[0:3]"  1 1 0.81221985816955566 1;
	setAttr -s 4 ".koy[0:3]"  0 0 -0.58335137367248535 0;
createNode animCurveTL -n "animCurveTL1681";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1.1630247831344604 150 1.1630247831344604;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1682";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 2.0187394618988037 150 2.0187394618988037;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1683";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 27.637619018554688 150 27.637619018554688;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1684";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1685";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1686";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1684";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -10.053677558898926 139 1.2863543033599854
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.92987960577011108 0.99995696544647217 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.36786389350891113 0.0092762280255556107 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.99995696544647217 0.99999988079071045 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.0092762280255556107 -0.00042691276757977903 
		0;
createNode animCurveTA -n "animCurveTA1685";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 21.51133918762207 139 35.683124542236328
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.29751718044281006 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0.95471644401550293 0.00012086508650099859 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.37013229727745056 0.99992990493774414 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.92897903919219971 -0.011841613799333572 
		0;
createNode animCurveTA -n "animCurveTA1686";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 132 -25.317956924438477 139 14.669728279113771
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.70843702554702759 0.9994654655456543 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.70577400922775269 0.032694131135940552 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.9994654655456543 0.99998819828033447 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.032694131135940552 -0.0048685031943023205 
		0;
createNode animCurveTL -n "animCurveTL1684";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 4.9883952140808105 150 4.9883952140808105;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1685";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 41.4617919921875 150 41.4617919921875;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1686";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -38.180568695068359 150 -38.180568695068359;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1687";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1688";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1689";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1687";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 -9.5584049224853516 140 -10.821244239807129
		 150 -9.5584049224853516;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1688";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 -14.087939262390137 140 -16.20292854309082
		 150 -14.087939262390137;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1689";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 -2.2710940837860107 140 -18.338037490844727
		 150 -2.2710940837860107;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1687";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 32.845657348632812 150 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1688";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 17.186578750610352 150 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1689";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 11.930496215820313 150 11.930496215820313;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1690";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1691";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1692";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1690";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 -0.89352136850357056 140 -2.217106819152832
		 150 -0.89352136850357056;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1691";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 11.041102409362793 140 8.9770975112915039
		 150 11.041102409362793;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA1692";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 0.32489952445030212 140 -16.302146911621094
		 150 0.32489952445030212;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1690";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 32.845657348632812 150 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1691";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 17.186578750610352 150 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1692";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -11.48735237121582 150 -11.48735237121582;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1693";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1694";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1695";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1693";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1694";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1695";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1693";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 47.368160247802734 150 47.368160247802734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1694";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  131 26.913848876953125 135 69.189155578613281
		 150 26.913848876953125;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL1695";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0.22157172858715057 150 0.22157172858715057;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1696";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1697";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1698";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1696";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  131 0 132 9.5518589019775391 133 16.935991287231445
		 136 -6.2262749671936035 139 -8.9774618148803711 142 -7.338451862335206 150 0;
	setAttr -s 7 ".ktl[0:6]" no yes yes yes yes yes no;
	setAttr -s 7 ".kix[0:6]"  1 0.27134501934051514 0.51777744293212891 
		0.48377275466918945 0.99699920415878296 0.94623476266860962 1;
	setAttr -s 7 ".kiy[0:6]"  0 0.96248209476470947 -0.85551536083221436 
		-0.87519365549087524 -0.077411599457263947 0.32348057627677917 0;
	setAttr -s 7 ".kox[0:6]"  1 0.27134501934051514 0.51777744293212891 
		0.48377275466918945 0.99699920415878296 0.94623476266860962 1;
	setAttr -s 7 ".koy[0:6]"  0 0.96248209476470947 -0.85551536083221436 
		-0.87519365549087524 -0.077411599457263947 0.32348057627677917 0;
createNode animCurveTA -n "animCurveTA1697";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1698";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1696";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0.55634701251983643 150 0.55634701251983643;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1697";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  131 28.874954223632813 132 28.586336135864258
		 136 34.654804229736328 137 34.691616058349609 138 32.763950347900391 139 30.236442565917969
		 142 27.327857971191406 147 30.643697738647461 150 28.874954223632813;
	setAttr -s 9 ".ktl[0:8]" no yes yes yes yes yes yes yes no;
	setAttr -s 9 ".kix[0:8]"  1 0.03602132573723793 0.034103646874427795 
		0.04402913898229599 0.018701506778597832 0.030644854530692101 0.63338017463684082 
		0.21062418818473816 1;
	setAttr -s 9 ".kiy[0:8]"  0 0.99935108423233032 0.99941825866699219 
		-0.99903023242950439 -0.999825119972229 -0.99953031539916992 0.77384078502655029 
		0.97756707668304443 0;
	setAttr -s 9 ".kox[0:8]"  1 0.03602132573723793 0.034103646874427795 
		0.04402913898229599 0.018701506778597832 0.030644854530692101 0.63338017463684082 
		0.21062418818473816 1;
	setAttr -s 9 ".koy[0:8]"  0 0.99935108423233032 0.99941825866699219 
		-0.99903023242950439 -0.999825119972229 -0.99953031539916992 0.77384078502655029 
		0.97756707668304443 0;
createNode animCurveTL -n "animCurveTL1698";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  131 0 132 -3.9458138942718506 136 8.4793462753295898
		 137 10.837972640991211 138 11.414670944213867 139 9.3194961547851562 142 7.430762767791748
		 147 1.4415949583053589 150 0;
	setAttr -s 9 ".ktl[0:8]" no yes yes yes yes yes yes yes no;
	setAttr -s 9 ".kix[0:8]"  1 0.024562051519751549 0.014090627431869507 
		0.028378430753946304 0.054796881973743439 0.041798364371061325 0.042274650186300278 
		0.04481351375579834 1;
	setAttr -s 9 ".kiy[0:8]"  0 0.99969828128814697 0.9999006986618042 
		0.99959725141525269 -0.99849748611450195 -0.99912607669830322 -0.99910604953765869 
		-0.99899542331695557 0;
	setAttr -s 9 ".kox[0:8]"  1 0.024562051519751549 0.014090627431869507 
		0.028378430753946304 0.054796881973743439 0.041798364371061325 0.042274650186300278 
		0.04481351375579834 1;
	setAttr -s 9 ".koy[0:8]"  0 0.99969828128814697 0.9999006986618042 
		0.99959725141525269 -0.99849748611450195 -0.99912607669830322 -0.99910604953765869 
		-0.99899542331695557 0;
createNode animCurveTU -n "animCurveTU1699";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1700";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1701";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1699";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1700";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1701";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1699";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -1.4725730419158936 150 -1.4725730419158936;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1700";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 25.007797241210938 150 25.007797241210938;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1701";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1702";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1703";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1704";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1702";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1703";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1704";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1702";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -0.28501001000404358 150 -0.28501001000404358;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1703";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1704";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1705";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1706";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1707";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1705";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 134 -21.474340438842773 137 -27.701995849609375
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.45930466055870056 0.8716883659362793 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 -0.8882787823677063 0.49006059765815735 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.45930466055870056 0.8716883659362793 
		1;
	setAttr -s 4 ".koy[0:3]"  0 -0.8882787823677063 0.49006059765815735 
		0;
createNode animCurveTA -n "animCurveTA1706";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1707";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1705";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1706";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 141 -4.7826738357543945 146 1.406557559967041
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.40606430172920227 0.078168116509914398 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.91384446620941162 0.99694019556045532 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.40606430172920227 0.078168116509914398 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.91384446620941162 0.99694019556045532 
		0;
createNode animCurveTL -n "animCurveTL1707";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  131 0 134 27.000385284423828 137 31.466833114624023
		 150 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.0079446230083703995 0.024683473631739616 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.99996846914291382 -0.9996953010559082 
		0;
	setAttr -s 4 ".kox[0:3]"  1 0.0079446230083703995 0.024683473631739616 
		1;
	setAttr -s 4 ".koy[0:3]"  0 0.99996846914291382 -0.9996953010559082 
		0;
createNode animCurveTU -n "animCurveTU1708";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1709";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU1710";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 1 150 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1708";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1709";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA1710";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 0 150 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1708";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 2.0856802463531494 150 2.0856802463531494;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1709";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 -5.0555992126464844 150 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL1710";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  131 28.250843048095703 150 28.250843048095703;
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
connectAttr "get_hit_from_rightSource.cl" "clipLibrary1.sc[0]";
connectAttr "animCurveTU1621.a" "clipLibrary1.cel[0].cev[0].cevr";
connectAttr "animCurveTU1622.a" "clipLibrary1.cel[0].cev[1].cevr";
connectAttr "animCurveTU1623.a" "clipLibrary1.cel[0].cev[2].cevr";
connectAttr "animCurveTA1621.a" "clipLibrary1.cel[0].cev[3].cevr";
connectAttr "animCurveTA1622.a" "clipLibrary1.cel[0].cev[4].cevr";
connectAttr "animCurveTA1623.a" "clipLibrary1.cel[0].cev[5].cevr";
connectAttr "animCurveTL1621.a" "clipLibrary1.cel[0].cev[6].cevr";
connectAttr "animCurveTL1622.a" "clipLibrary1.cel[0].cev[7].cevr";
connectAttr "animCurveTL1623.a" "clipLibrary1.cel[0].cev[8].cevr";
connectAttr "animCurveTU1624.a" "clipLibrary1.cel[0].cev[9].cevr";
connectAttr "animCurveTU1625.a" "clipLibrary1.cel[0].cev[10].cevr";
connectAttr "animCurveTU1626.a" "clipLibrary1.cel[0].cev[11].cevr";
connectAttr "animCurveTA1624.a" "clipLibrary1.cel[0].cev[12].cevr";
connectAttr "animCurveTA1625.a" "clipLibrary1.cel[0].cev[13].cevr";
connectAttr "animCurveTA1626.a" "clipLibrary1.cel[0].cev[14].cevr";
connectAttr "animCurveTL1624.a" "clipLibrary1.cel[0].cev[15].cevr";
connectAttr "animCurveTL1625.a" "clipLibrary1.cel[0].cev[16].cevr";
connectAttr "animCurveTL1626.a" "clipLibrary1.cel[0].cev[17].cevr";
connectAttr "animCurveTU1627.a" "clipLibrary1.cel[0].cev[18].cevr";
connectAttr "animCurveTU1628.a" "clipLibrary1.cel[0].cev[19].cevr";
connectAttr "animCurveTU1629.a" "clipLibrary1.cel[0].cev[20].cevr";
connectAttr "animCurveTA1627.a" "clipLibrary1.cel[0].cev[21].cevr";
connectAttr "animCurveTA1628.a" "clipLibrary1.cel[0].cev[22].cevr";
connectAttr "animCurveTA1629.a" "clipLibrary1.cel[0].cev[23].cevr";
connectAttr "animCurveTL1627.a" "clipLibrary1.cel[0].cev[24].cevr";
connectAttr "animCurveTL1628.a" "clipLibrary1.cel[0].cev[25].cevr";
connectAttr "animCurveTL1629.a" "clipLibrary1.cel[0].cev[26].cevr";
connectAttr "animCurveTU1630.a" "clipLibrary1.cel[0].cev[27].cevr";
connectAttr "animCurveTU1631.a" "clipLibrary1.cel[0].cev[28].cevr";
connectAttr "animCurveTU1632.a" "clipLibrary1.cel[0].cev[29].cevr";
connectAttr "animCurveTA1630.a" "clipLibrary1.cel[0].cev[30].cevr";
connectAttr "animCurveTA1631.a" "clipLibrary1.cel[0].cev[31].cevr";
connectAttr "animCurveTA1632.a" "clipLibrary1.cel[0].cev[32].cevr";
connectAttr "animCurveTL1630.a" "clipLibrary1.cel[0].cev[33].cevr";
connectAttr "animCurveTL1631.a" "clipLibrary1.cel[0].cev[34].cevr";
connectAttr "animCurveTL1632.a" "clipLibrary1.cel[0].cev[35].cevr";
connectAttr "animCurveTU1633.a" "clipLibrary1.cel[0].cev[36].cevr";
connectAttr "animCurveTU1634.a" "clipLibrary1.cel[0].cev[37].cevr";
connectAttr "animCurveTU1635.a" "clipLibrary1.cel[0].cev[38].cevr";
connectAttr "animCurveTA1633.a" "clipLibrary1.cel[0].cev[39].cevr";
connectAttr "animCurveTA1634.a" "clipLibrary1.cel[0].cev[40].cevr";
connectAttr "animCurveTA1635.a" "clipLibrary1.cel[0].cev[41].cevr";
connectAttr "animCurveTL1633.a" "clipLibrary1.cel[0].cev[42].cevr";
connectAttr "animCurveTL1634.a" "clipLibrary1.cel[0].cev[43].cevr";
connectAttr "animCurveTL1635.a" "clipLibrary1.cel[0].cev[44].cevr";
connectAttr "animCurveTU1636.a" "clipLibrary1.cel[0].cev[45].cevr";
connectAttr "animCurveTU1637.a" "clipLibrary1.cel[0].cev[46].cevr";
connectAttr "animCurveTU1638.a" "clipLibrary1.cel[0].cev[47].cevr";
connectAttr "animCurveTA1636.a" "clipLibrary1.cel[0].cev[48].cevr";
connectAttr "animCurveTA1637.a" "clipLibrary1.cel[0].cev[49].cevr";
connectAttr "animCurveTA1638.a" "clipLibrary1.cel[0].cev[50].cevr";
connectAttr "animCurveTL1636.a" "clipLibrary1.cel[0].cev[51].cevr";
connectAttr "animCurveTL1637.a" "clipLibrary1.cel[0].cev[52].cevr";
connectAttr "animCurveTL1638.a" "clipLibrary1.cel[0].cev[53].cevr";
connectAttr "animCurveTU1639.a" "clipLibrary1.cel[0].cev[54].cevr";
connectAttr "animCurveTU1640.a" "clipLibrary1.cel[0].cev[55].cevr";
connectAttr "animCurveTU1641.a" "clipLibrary1.cel[0].cev[56].cevr";
connectAttr "animCurveTA1639.a" "clipLibrary1.cel[0].cev[57].cevr";
connectAttr "animCurveTA1640.a" "clipLibrary1.cel[0].cev[58].cevr";
connectAttr "animCurveTA1641.a" "clipLibrary1.cel[0].cev[59].cevr";
connectAttr "animCurveTL1639.a" "clipLibrary1.cel[0].cev[60].cevr";
connectAttr "animCurveTL1640.a" "clipLibrary1.cel[0].cev[61].cevr";
connectAttr "animCurveTL1641.a" "clipLibrary1.cel[0].cev[62].cevr";
connectAttr "animCurveTU1642.a" "clipLibrary1.cel[0].cev[63].cevr";
connectAttr "animCurveTU1643.a" "clipLibrary1.cel[0].cev[64].cevr";
connectAttr "animCurveTU1644.a" "clipLibrary1.cel[0].cev[65].cevr";
connectAttr "animCurveTA1642.a" "clipLibrary1.cel[0].cev[66].cevr";
connectAttr "animCurveTA1643.a" "clipLibrary1.cel[0].cev[67].cevr";
connectAttr "animCurveTA1644.a" "clipLibrary1.cel[0].cev[68].cevr";
connectAttr "animCurveTL1642.a" "clipLibrary1.cel[0].cev[69].cevr";
connectAttr "animCurveTL1643.a" "clipLibrary1.cel[0].cev[70].cevr";
connectAttr "animCurveTL1644.a" "clipLibrary1.cel[0].cev[71].cevr";
connectAttr "animCurveTU1645.a" "clipLibrary1.cel[0].cev[72].cevr";
connectAttr "animCurveTU1646.a" "clipLibrary1.cel[0].cev[73].cevr";
connectAttr "animCurveTU1647.a" "clipLibrary1.cel[0].cev[74].cevr";
connectAttr "animCurveTA1645.a" "clipLibrary1.cel[0].cev[75].cevr";
connectAttr "animCurveTA1646.a" "clipLibrary1.cel[0].cev[76].cevr";
connectAttr "animCurveTA1647.a" "clipLibrary1.cel[0].cev[77].cevr";
connectAttr "animCurveTL1645.a" "clipLibrary1.cel[0].cev[78].cevr";
connectAttr "animCurveTL1646.a" "clipLibrary1.cel[0].cev[79].cevr";
connectAttr "animCurveTL1647.a" "clipLibrary1.cel[0].cev[80].cevr";
connectAttr "animCurveTU1648.a" "clipLibrary1.cel[0].cev[81].cevr";
connectAttr "animCurveTU1649.a" "clipLibrary1.cel[0].cev[82].cevr";
connectAttr "animCurveTU1650.a" "clipLibrary1.cel[0].cev[83].cevr";
connectAttr "animCurveTA1648.a" "clipLibrary1.cel[0].cev[84].cevr";
connectAttr "animCurveTA1649.a" "clipLibrary1.cel[0].cev[85].cevr";
connectAttr "animCurveTA1650.a" "clipLibrary1.cel[0].cev[86].cevr";
connectAttr "animCurveTL1648.a" "clipLibrary1.cel[0].cev[87].cevr";
connectAttr "animCurveTL1649.a" "clipLibrary1.cel[0].cev[88].cevr";
connectAttr "animCurveTL1650.a" "clipLibrary1.cel[0].cev[89].cevr";
connectAttr "animCurveTU1651.a" "clipLibrary1.cel[0].cev[90].cevr";
connectAttr "animCurveTU1652.a" "clipLibrary1.cel[0].cev[91].cevr";
connectAttr "animCurveTU1653.a" "clipLibrary1.cel[0].cev[92].cevr";
connectAttr "animCurveTA1651.a" "clipLibrary1.cel[0].cev[93].cevr";
connectAttr "animCurveTA1652.a" "clipLibrary1.cel[0].cev[94].cevr";
connectAttr "animCurveTA1653.a" "clipLibrary1.cel[0].cev[95].cevr";
connectAttr "animCurveTL1651.a" "clipLibrary1.cel[0].cev[96].cevr";
connectAttr "animCurveTL1652.a" "clipLibrary1.cel[0].cev[97].cevr";
connectAttr "animCurveTL1653.a" "clipLibrary1.cel[0].cev[98].cevr";
connectAttr "animCurveTU1654.a" "clipLibrary1.cel[0].cev[99].cevr";
connectAttr "animCurveTU1655.a" "clipLibrary1.cel[0].cev[100].cevr";
connectAttr "animCurveTU1656.a" "clipLibrary1.cel[0].cev[101].cevr";
connectAttr "animCurveTA1654.a" "clipLibrary1.cel[0].cev[102].cevr";
connectAttr "animCurveTA1655.a" "clipLibrary1.cel[0].cev[103].cevr";
connectAttr "animCurveTA1656.a" "clipLibrary1.cel[0].cev[104].cevr";
connectAttr "animCurveTL1654.a" "clipLibrary1.cel[0].cev[105].cevr";
connectAttr "animCurveTL1655.a" "clipLibrary1.cel[0].cev[106].cevr";
connectAttr "animCurveTL1656.a" "clipLibrary1.cel[0].cev[107].cevr";
connectAttr "animCurveTU1657.a" "clipLibrary1.cel[0].cev[108].cevr";
connectAttr "animCurveTU1658.a" "clipLibrary1.cel[0].cev[109].cevr";
connectAttr "animCurveTU1659.a" "clipLibrary1.cel[0].cev[110].cevr";
connectAttr "animCurveTA1657.a" "clipLibrary1.cel[0].cev[111].cevr";
connectAttr "animCurveTA1658.a" "clipLibrary1.cel[0].cev[112].cevr";
connectAttr "animCurveTA1659.a" "clipLibrary1.cel[0].cev[113].cevr";
connectAttr "animCurveTL1657.a" "clipLibrary1.cel[0].cev[114].cevr";
connectAttr "animCurveTL1658.a" "clipLibrary1.cel[0].cev[115].cevr";
connectAttr "animCurveTL1659.a" "clipLibrary1.cel[0].cev[116].cevr";
connectAttr "animCurveTU1660.a" "clipLibrary1.cel[0].cev[117].cevr";
connectAttr "animCurveTU1661.a" "clipLibrary1.cel[0].cev[118].cevr";
connectAttr "animCurveTU1662.a" "clipLibrary1.cel[0].cev[119].cevr";
connectAttr "animCurveTA1660.a" "clipLibrary1.cel[0].cev[120].cevr";
connectAttr "animCurveTA1661.a" "clipLibrary1.cel[0].cev[121].cevr";
connectAttr "animCurveTA1662.a" "clipLibrary1.cel[0].cev[122].cevr";
connectAttr "animCurveTL1660.a" "clipLibrary1.cel[0].cev[123].cevr";
connectAttr "animCurveTL1661.a" "clipLibrary1.cel[0].cev[124].cevr";
connectAttr "animCurveTL1662.a" "clipLibrary1.cel[0].cev[125].cevr";
connectAttr "animCurveTU1663.a" "clipLibrary1.cel[0].cev[126].cevr";
connectAttr "animCurveTU1664.a" "clipLibrary1.cel[0].cev[127].cevr";
connectAttr "animCurveTU1665.a" "clipLibrary1.cel[0].cev[128].cevr";
connectAttr "animCurveTA1663.a" "clipLibrary1.cel[0].cev[129].cevr";
connectAttr "animCurveTA1664.a" "clipLibrary1.cel[0].cev[130].cevr";
connectAttr "animCurveTA1665.a" "clipLibrary1.cel[0].cev[131].cevr";
connectAttr "animCurveTL1663.a" "clipLibrary1.cel[0].cev[132].cevr";
connectAttr "animCurveTL1664.a" "clipLibrary1.cel[0].cev[133].cevr";
connectAttr "animCurveTL1665.a" "clipLibrary1.cel[0].cev[134].cevr";
connectAttr "animCurveTU1666.a" "clipLibrary1.cel[0].cev[135].cevr";
connectAttr "animCurveTU1667.a" "clipLibrary1.cel[0].cev[136].cevr";
connectAttr "animCurveTU1668.a" "clipLibrary1.cel[0].cev[137].cevr";
connectAttr "animCurveTA1666.a" "clipLibrary1.cel[0].cev[138].cevr";
connectAttr "animCurveTA1667.a" "clipLibrary1.cel[0].cev[139].cevr";
connectAttr "animCurveTA1668.a" "clipLibrary1.cel[0].cev[140].cevr";
connectAttr "animCurveTL1666.a" "clipLibrary1.cel[0].cev[141].cevr";
connectAttr "animCurveTL1667.a" "clipLibrary1.cel[0].cev[142].cevr";
connectAttr "animCurveTL1668.a" "clipLibrary1.cel[0].cev[143].cevr";
connectAttr "animCurveTU1669.a" "clipLibrary1.cel[0].cev[144].cevr";
connectAttr "animCurveTU1670.a" "clipLibrary1.cel[0].cev[145].cevr";
connectAttr "animCurveTU1671.a" "clipLibrary1.cel[0].cev[146].cevr";
connectAttr "animCurveTA1669.a" "clipLibrary1.cel[0].cev[147].cevr";
connectAttr "animCurveTA1670.a" "clipLibrary1.cel[0].cev[148].cevr";
connectAttr "animCurveTA1671.a" "clipLibrary1.cel[0].cev[149].cevr";
connectAttr "animCurveTL1669.a" "clipLibrary1.cel[0].cev[150].cevr";
connectAttr "animCurveTL1670.a" "clipLibrary1.cel[0].cev[151].cevr";
connectAttr "animCurveTL1671.a" "clipLibrary1.cel[0].cev[152].cevr";
connectAttr "animCurveTU1672.a" "clipLibrary1.cel[0].cev[153].cevr";
connectAttr "animCurveTU1673.a" "clipLibrary1.cel[0].cev[154].cevr";
connectAttr "animCurveTU1674.a" "clipLibrary1.cel[0].cev[155].cevr";
connectAttr "animCurveTA1672.a" "clipLibrary1.cel[0].cev[156].cevr";
connectAttr "animCurveTA1673.a" "clipLibrary1.cel[0].cev[157].cevr";
connectAttr "animCurveTA1674.a" "clipLibrary1.cel[0].cev[158].cevr";
connectAttr "animCurveTL1672.a" "clipLibrary1.cel[0].cev[159].cevr";
connectAttr "animCurveTL1673.a" "clipLibrary1.cel[0].cev[160].cevr";
connectAttr "animCurveTL1674.a" "clipLibrary1.cel[0].cev[161].cevr";
connectAttr "animCurveTU1675.a" "clipLibrary1.cel[0].cev[162].cevr";
connectAttr "animCurveTU1676.a" "clipLibrary1.cel[0].cev[163].cevr";
connectAttr "animCurveTU1677.a" "clipLibrary1.cel[0].cev[164].cevr";
connectAttr "animCurveTA1675.a" "clipLibrary1.cel[0].cev[165].cevr";
connectAttr "animCurveTA1676.a" "clipLibrary1.cel[0].cev[166].cevr";
connectAttr "animCurveTA1677.a" "clipLibrary1.cel[0].cev[167].cevr";
connectAttr "animCurveTL1675.a" "clipLibrary1.cel[0].cev[168].cevr";
connectAttr "animCurveTL1676.a" "clipLibrary1.cel[0].cev[169].cevr";
connectAttr "animCurveTL1677.a" "clipLibrary1.cel[0].cev[170].cevr";
connectAttr "animCurveTU1678.a" "clipLibrary1.cel[0].cev[171].cevr";
connectAttr "animCurveTU1679.a" "clipLibrary1.cel[0].cev[172].cevr";
connectAttr "animCurveTU1680.a" "clipLibrary1.cel[0].cev[173].cevr";
connectAttr "animCurveTA1678.a" "clipLibrary1.cel[0].cev[174].cevr";
connectAttr "animCurveTA1679.a" "clipLibrary1.cel[0].cev[175].cevr";
connectAttr "animCurveTA1680.a" "clipLibrary1.cel[0].cev[176].cevr";
connectAttr "animCurveTL1678.a" "clipLibrary1.cel[0].cev[177].cevr";
connectAttr "animCurveTL1679.a" "clipLibrary1.cel[0].cev[178].cevr";
connectAttr "animCurveTL1680.a" "clipLibrary1.cel[0].cev[179].cevr";
connectAttr "animCurveTU1681.a" "clipLibrary1.cel[0].cev[180].cevr";
connectAttr "animCurveTU1682.a" "clipLibrary1.cel[0].cev[181].cevr";
connectAttr "animCurveTU1683.a" "clipLibrary1.cel[0].cev[182].cevr";
connectAttr "animCurveTA1681.a" "clipLibrary1.cel[0].cev[183].cevr";
connectAttr "animCurveTA1682.a" "clipLibrary1.cel[0].cev[184].cevr";
connectAttr "animCurveTA1683.a" "clipLibrary1.cel[0].cev[185].cevr";
connectAttr "animCurveTL1681.a" "clipLibrary1.cel[0].cev[186].cevr";
connectAttr "animCurveTL1682.a" "clipLibrary1.cel[0].cev[187].cevr";
connectAttr "animCurveTL1683.a" "clipLibrary1.cel[0].cev[188].cevr";
connectAttr "animCurveTU1684.a" "clipLibrary1.cel[0].cev[189].cevr";
connectAttr "animCurveTU1685.a" "clipLibrary1.cel[0].cev[190].cevr";
connectAttr "animCurveTU1686.a" "clipLibrary1.cel[0].cev[191].cevr";
connectAttr "animCurveTA1684.a" "clipLibrary1.cel[0].cev[192].cevr";
connectAttr "animCurveTA1685.a" "clipLibrary1.cel[0].cev[193].cevr";
connectAttr "animCurveTA1686.a" "clipLibrary1.cel[0].cev[194].cevr";
connectAttr "animCurveTL1684.a" "clipLibrary1.cel[0].cev[195].cevr";
connectAttr "animCurveTL1685.a" "clipLibrary1.cel[0].cev[196].cevr";
connectAttr "animCurveTL1686.a" "clipLibrary1.cel[0].cev[197].cevr";
connectAttr "animCurveTU1687.a" "clipLibrary1.cel[0].cev[198].cevr";
connectAttr "animCurveTU1688.a" "clipLibrary1.cel[0].cev[199].cevr";
connectAttr "animCurveTU1689.a" "clipLibrary1.cel[0].cev[200].cevr";
connectAttr "animCurveTA1687.a" "clipLibrary1.cel[0].cev[201].cevr";
connectAttr "animCurveTA1688.a" "clipLibrary1.cel[0].cev[202].cevr";
connectAttr "animCurveTA1689.a" "clipLibrary1.cel[0].cev[203].cevr";
connectAttr "animCurveTL1687.a" "clipLibrary1.cel[0].cev[204].cevr";
connectAttr "animCurveTL1688.a" "clipLibrary1.cel[0].cev[205].cevr";
connectAttr "animCurveTL1689.a" "clipLibrary1.cel[0].cev[206].cevr";
connectAttr "animCurveTU1690.a" "clipLibrary1.cel[0].cev[207].cevr";
connectAttr "animCurveTU1691.a" "clipLibrary1.cel[0].cev[208].cevr";
connectAttr "animCurveTU1692.a" "clipLibrary1.cel[0].cev[209].cevr";
connectAttr "animCurveTA1690.a" "clipLibrary1.cel[0].cev[210].cevr";
connectAttr "animCurveTA1691.a" "clipLibrary1.cel[0].cev[211].cevr";
connectAttr "animCurveTA1692.a" "clipLibrary1.cel[0].cev[212].cevr";
connectAttr "animCurveTL1690.a" "clipLibrary1.cel[0].cev[213].cevr";
connectAttr "animCurveTL1691.a" "clipLibrary1.cel[0].cev[214].cevr";
connectAttr "animCurveTL1692.a" "clipLibrary1.cel[0].cev[215].cevr";
connectAttr "animCurveTU1693.a" "clipLibrary1.cel[0].cev[216].cevr";
connectAttr "animCurveTU1694.a" "clipLibrary1.cel[0].cev[217].cevr";
connectAttr "animCurveTU1695.a" "clipLibrary1.cel[0].cev[218].cevr";
connectAttr "animCurveTA1693.a" "clipLibrary1.cel[0].cev[219].cevr";
connectAttr "animCurveTA1694.a" "clipLibrary1.cel[0].cev[220].cevr";
connectAttr "animCurveTA1695.a" "clipLibrary1.cel[0].cev[221].cevr";
connectAttr "animCurveTL1693.a" "clipLibrary1.cel[0].cev[222].cevr";
connectAttr "animCurveTL1694.a" "clipLibrary1.cel[0].cev[223].cevr";
connectAttr "animCurveTL1695.a" "clipLibrary1.cel[0].cev[224].cevr";
connectAttr "animCurveTU1696.a" "clipLibrary1.cel[0].cev[225].cevr";
connectAttr "animCurveTU1697.a" "clipLibrary1.cel[0].cev[226].cevr";
connectAttr "animCurveTU1698.a" "clipLibrary1.cel[0].cev[227].cevr";
connectAttr "animCurveTA1696.a" "clipLibrary1.cel[0].cev[228].cevr";
connectAttr "animCurveTA1697.a" "clipLibrary1.cel[0].cev[229].cevr";
connectAttr "animCurveTA1698.a" "clipLibrary1.cel[0].cev[230].cevr";
connectAttr "animCurveTL1696.a" "clipLibrary1.cel[0].cev[231].cevr";
connectAttr "animCurveTL1697.a" "clipLibrary1.cel[0].cev[232].cevr";
connectAttr "animCurveTL1698.a" "clipLibrary1.cel[0].cev[233].cevr";
connectAttr "animCurveTU1699.a" "clipLibrary1.cel[0].cev[234].cevr";
connectAttr "animCurveTU1700.a" "clipLibrary1.cel[0].cev[235].cevr";
connectAttr "animCurveTU1701.a" "clipLibrary1.cel[0].cev[236].cevr";
connectAttr "animCurveTA1699.a" "clipLibrary1.cel[0].cev[237].cevr";
connectAttr "animCurveTA1700.a" "clipLibrary1.cel[0].cev[238].cevr";
connectAttr "animCurveTA1701.a" "clipLibrary1.cel[0].cev[239].cevr";
connectAttr "animCurveTL1699.a" "clipLibrary1.cel[0].cev[240].cevr";
connectAttr "animCurveTL1700.a" "clipLibrary1.cel[0].cev[241].cevr";
connectAttr "animCurveTL1701.a" "clipLibrary1.cel[0].cev[242].cevr";
connectAttr "animCurveTU1702.a" "clipLibrary1.cel[0].cev[243].cevr";
connectAttr "animCurveTU1703.a" "clipLibrary1.cel[0].cev[244].cevr";
connectAttr "animCurveTU1704.a" "clipLibrary1.cel[0].cev[245].cevr";
connectAttr "animCurveTA1702.a" "clipLibrary1.cel[0].cev[246].cevr";
connectAttr "animCurveTA1703.a" "clipLibrary1.cel[0].cev[247].cevr";
connectAttr "animCurveTA1704.a" "clipLibrary1.cel[0].cev[248].cevr";
connectAttr "animCurveTL1702.a" "clipLibrary1.cel[0].cev[249].cevr";
connectAttr "animCurveTL1703.a" "clipLibrary1.cel[0].cev[250].cevr";
connectAttr "animCurveTL1704.a" "clipLibrary1.cel[0].cev[251].cevr";
connectAttr "animCurveTU1705.a" "clipLibrary1.cel[0].cev[252].cevr";
connectAttr "animCurveTU1706.a" "clipLibrary1.cel[0].cev[253].cevr";
connectAttr "animCurveTU1707.a" "clipLibrary1.cel[0].cev[254].cevr";
connectAttr "animCurveTA1705.a" "clipLibrary1.cel[0].cev[255].cevr";
connectAttr "animCurveTA1706.a" "clipLibrary1.cel[0].cev[256].cevr";
connectAttr "animCurveTA1707.a" "clipLibrary1.cel[0].cev[257].cevr";
connectAttr "animCurveTL1705.a" "clipLibrary1.cel[0].cev[258].cevr";
connectAttr "animCurveTL1706.a" "clipLibrary1.cel[0].cev[259].cevr";
connectAttr "animCurveTL1707.a" "clipLibrary1.cel[0].cev[260].cevr";
connectAttr "animCurveTU1708.a" "clipLibrary1.cel[0].cev[261].cevr";
connectAttr "animCurveTU1709.a" "clipLibrary1.cel[0].cev[262].cevr";
connectAttr "animCurveTU1710.a" "clipLibrary1.cel[0].cev[263].cevr";
connectAttr "animCurveTA1708.a" "clipLibrary1.cel[0].cev[264].cevr";
connectAttr "animCurveTA1709.a" "clipLibrary1.cel[0].cev[265].cevr";
connectAttr "animCurveTA1710.a" "clipLibrary1.cel[0].cev[266].cevr";
connectAttr "animCurveTL1708.a" "clipLibrary1.cel[0].cev[267].cevr";
connectAttr "animCurveTL1709.a" "clipLibrary1.cel[0].cev[268].cevr";
connectAttr "animCurveTL1710.a" "clipLibrary1.cel[0].cev[269].cevr";
// End of bat_get_hit_from_right.ma
