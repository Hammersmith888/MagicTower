//Maya ASCII 2013 scene
//Name: bat_block.ma
//Last modified: Sat, Jul 12, 2014 02:43:08 PM
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
createNode animClip -n "bat_blockSource";
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
	setAttr ".ss" 66;
	setAttr ".se" 90;
	setAttr ".ci" no;
createNode animCurveTU -n "animCurveTU541";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 67 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU542";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 67 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU543";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 67 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA541";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 30.058616638183594 67 63.993064880371094
		 71 73.134933471679688 80 73.134933471679688 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.079173125326633453 0.26704105734825134 
		0.95924943685531616 0.5270698070526123 1;
	setAttr -s 5 ".kiy[0:4]"  0.99686092138290405 0.96368521451950073 
		0.28256064653396606 -0.84982198476791382 0;
	setAttr -s 5 ".kox[0:4]"  0.070177823305130005 0.26704105734825134 
		0.95924943685531616 0.5270698070526123 1;
	setAttr -s 5 ".koy[0:4]"  0.99753451347351074 0.96368521451950073 
		0.28256064653396606 -0.84982198476791382 0;
createNode animCurveTA -n "animCurveTA542";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 -10.601661682128906 67 -22.323490142822266
		 71 -25.512561798095703 80 -25.512561798095703 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.21968348324298859 0.62494701147079468 
		0.99476194381713867 0.87159162759780884 1;
	setAttr -s 5 ".kiy[0:4]"  -0.97557121515274048 -0.78066712617874146 
		-0.10221829265356064 0.49023258686065674 0;
	setAttr -s 5 ".kox[0:4]"  0.1995682567358017 0.62494701147079468 
		0.99476194381713867 0.87159162759780884 1;
	setAttr -s 5 ".koy[0:4]"  -0.97988384962081909 -0.78066712617874146 
		-0.10221829265356064 0.49023258686065674 0;
createNode animCurveTA -n "animCurveTA543";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 9.0288400650024414 67 19.051445007324219
		 71 21.773078918457031 80 21.773078918457031 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.25562652945518494 0.68360251188278198 
		0.99617683887481689 0.90151774883270264 1;
	setAttr -s 5 ".kiy[0:4]"  0.96677565574645996 0.7298545241355896 
		0.087359815835952759 -0.43274208903312683 0;
	setAttr -s 5 ".kox[0:4]"  0.23171186447143555 0.68360251188278198 
		0.99617683887481689 0.90151774883270264 1;
	setAttr -s 5 ".koy[0:4]"  0.97278451919555664 0.7298545241355896 
		0.087359815835952759 -0.43274208903312683 0;
createNode animCurveTL -n "animCurveTL541";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 20.043542861938477 67 50.567455291748047
		 71 57.267997741699219 80 57.267997741699219 90 -5.7247552871704102;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.0016169770387932658 0.0055965874344110489 
		0.080576367676258087 0.012566587887704372 1;
	setAttr -s 5 ".kiy[0:4]"  0.99999868869781494 0.99998438358306885 
		0.99674844741821289 -0.99992102384567261 0;
	setAttr -s 5 ".kox[0:4]"  0.0013650538166984916 0.0055965874344110489 
		0.080576367676258087 0.012566587887704372 1;
	setAttr -s 5 ".koy[0:4]"  0.99999904632568359 0.99998438358306885 
		0.99674844741821289 -0.99992102384567261 0;
createNode animCurveTL -n "animCurveTL542";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 14.150486946105957 67 15.941396713256836
		 71 16.412363052368164 80 16.412363052368164 90 12.644636154174805;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.027659313753247261 0.091718181967735291 
		0.75463896989822388 0.2056276947259903 1;
	setAttr -s 5 ".kiy[0:4]"  0.99961739778518677 0.99578505754470825 
		0.65614026784896851 -0.97863030433654785 0;
	setAttr -s 5 ".kox[0:4]"  0.023259393870830536 0.091718181967735291 
		0.75463896989822388 0.2056276947259903 1;
	setAttr -s 5 ".koy[0:4]"  0.9997294545173645 0.99578505754470825 
		0.65614026784896851 -0.97863030433654785 0;
createNode animCurveTL -n "animCurveTL543";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 38.173652648925781 67 32.131595611572266
		 71 30.542682647705078 80 30.542682647705078 90 43.253993988037109;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.0082012861967086792 0.02729085274040699 
		0.32266926765441895 0.062160052359104156 1;
	setAttr -s 5 ".kiy[0:4]"  -0.99996638298034668 -0.99962753057479858 
		-0.94651174545288086 0.998066246509552 0;
	setAttr -s 5 ".kox[0:4]"  0.0068959556519985199 0.02729085274040699 
		0.32266926765441895 0.062160052359104156 1;
	setAttr -s 5 ".koy[0:4]"  -0.99997621774673462 -0.99962753057479858 
		-0.94651174545288086 0.998066246509552 0;
createNode animCurveTU -n "animCurveTU544";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU545";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU546";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA544";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 109.05284881591797 67 107.17375946044922
		 69 96.078300476074219 78 94.716819763183594 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.044506561011075974 0.48326358199119568 
		0.90350186824798584 0.46260946989059448 1;
	setAttr -s 5 ".kiy[0:4]"  0.99900907278060913 -0.87547492980957031 
		-0.42858427762985229 -0.88656222820281982 0;
	setAttr -s 5 ".kox[0:4]"  0.044506561011075974 0.48326358199119568 
		0.90350186824798584 0.46260946989059448 1;
	setAttr -s 5 ".koy[0:4]"  0.99900907278060913 -0.87547492980957031 
		-0.42858427762985229 -0.88656222820281982 0;
createNode animCurveTA -n "animCurveTA545";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 16.265592575073242 67 17.51878547668457
		 69 7.6253285408020028 78 4.2309708595275879 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.26295375823974609 0.63817083835601807 
		0.89227592945098877 0.98862969875335693 1;
	setAttr -s 5 ".kiy[0:4]"  0.96480846405029297 -0.76989477872848511 
		-0.45149058103561401 -0.15037016570568085 0;
	setAttr -s 5 ".kox[0:4]"  0.26295375823974609 0.63817083835601807 
		0.89227592945098877 0.98862969875335693 1;
	setAttr -s 5 ".koy[0:4]"  0.96480846405029297 -0.76989477872848511 
		-0.45149058103561401 -0.15037016570568085 0;
createNode animCurveTA -n "animCurveTA546";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 -12.802089691162109 67 -13.519268989562988
		 69 -9.7544689178466797 78 -8.3041057586669922 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.33301550149917603 0.92015588283538818 
		0.98084515333175659 0.98159253597259521 1;
	setAttr -s 5 ".kiy[0:4]"  -0.94292134046554565 0.39155223965644836 
		0.19478893280029297 0.19098716974258423 0;
	setAttr -s 5 ".kox[0:4]"  0.33301550149917603 0.92015588283538818 
		0.98084515333175659 0.98159253597259521 1;
	setAttr -s 5 ".koy[0:4]"  -0.94292134046554565 0.39155223965644836 
		0.19478893280029297 0.19098716974258423 0;
createNode animCurveTL -n "animCurveTL544";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -1.9167585372924805 90 -1.9167585372924805;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL545";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -5.0555992126464844 90 -5.0555992126464844;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL546";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 28.262805938720703 90 28.262805938720703;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU547";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU548";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU549";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA547";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 30.229227066040039 69 66.509300231933594
		 78 71.692169189453125 90 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.14212100207805634 0.56844210624694824 
		0.60193330049514771 1;
	setAttr -s 4 ".kiy[0:3]"  0.9898492693901062 0.82272326946258545 
		-0.79854637384414673 0;
	setAttr -s 4 ".kox[0:3]"  0.14212100207805634 0.56844210624694824 
		0.60193330049514771 1;
	setAttr -s 4 ".koy[0:3]"  0.9898492693901062 0.82272326946258545 
		-0.79854637384414673 0;
createNode animCurveTA -n "animCurveTA548";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 37.415168762207031 69 24.385412216186523
		 78 22.524019241333008 90 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.36463707685470581 0.88728970289230347 
		0.89926332235336304 1;
	setAttr -s 4 ".kiy[0:3]"  0.93114966154098511 -0.46121242642402649 
		-0.43740761280059814 0;
	setAttr -s 4 ".kox[0:3]"  0.36463707685470581 0.88728970289230347 
		0.89926332235336304 1;
	setAttr -s 4 ".koy[0:3]"  0.93114966154098511 -0.46121242642402649 
		-0.43740761280059814 0;
createNode animCurveTA -n "animCurveTA549";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -75.110427856445313 69 -67.22052001953125
		 78 -66.093391418457031 90 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.14064717292785645 0.95386582612991333 
		0.59784883260726929 1;
	setAttr -s 4 ".kiy[0:3]"  -0.99005973339080811 0.30023300647735596 
		0.8016088604927063 0;
	setAttr -s 4 ".kox[0:3]"  0.14064717292785645 0.95386582612991333 
		0.59784883260726929 1;
	setAttr -s 4 ".koy[0:3]"  -0.99005973339080811 0.30023300647735596 
		0.8016088604927063 0;
createNode animCurveTL -n "animCurveTL547";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 42.71490478515625 69 44.781414031982422
		 78 45.076629638671875 90 -5.7247552871704102;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.0032999110408127308 0.20711879432201385 
		0.017322016879916191 1;
	setAttr -s 4 ".kiy[0:3]"  0.99999457597732544 0.97831577062606812 
		-0.99984991550445557 0;
	setAttr -s 4 ".kox[0:3]"  0.0032999110408127308 0.20711879432201385 
		0.017322016879916191 1;
	setAttr -s 4 ".koy[0:3]"  0.99999457597732544 0.97831577062606812 
		-0.99984991550445557 0;
createNode animCurveTL -n "animCurveTL548";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 11.738015174865723 69 4.5663375854492187
		 78 3.5418121814727783 90 12.644636154174805;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.02062702551484108 0.060890655964612961 
		0.10768503695726395 1;
	setAttr -s 4 ".kiy[0:3]"  -0.99978727102279663 -0.99814444780349731 
		0.99418509006500244 0;
	setAttr -s 4 ".kox[0:3]"  0.02062702551484108 0.060890655964612961 
		0.10768503695726395 1;
	setAttr -s 4 ".koy[0:3]"  -0.99978727102279663 -0.99814444780349731 
		0.99418509006500244 0;
createNode animCurveTL -n "animCurveTL549";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -46.299598693847656 69 -37.347469329833984
		 78 -36.068592071533203 90 -43.253993988037109;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.028206165879964828 0.048812787979841232 
		0.14654198288917542 1;
	setAttr -s 4 ".kiy[0:3]"  0.99960213899612427 0.99880790710449219 
		-0.98920446634292603 0;
	setAttr -s 4 ".kox[0:3]"  0.028206165879964828 0.048812787979841232 
		0.14654198288917542 1;
	setAttr -s 4 ".koy[0:3]"  0.99960213899612427 0.99880790710449219 
		-0.98920446634292603 0;
createNode animCurveTU -n "animCurveTU550";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU551";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU552";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA550";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0.0048254411667585373;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.99999696016311646 1;
	setAttr -s 2 ".kiy[0:1]"  -0.0024595898576080799 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  8.4325860370881855e-005 0;
createNode animCurveTA -n "animCurveTA551";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 1.5292341709136963;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.83491075038909912 1;
	setAttr -s 2 ".kiy[0:1]"  -0.55038535594940186 0;
	setAttr -s 2 ".kox[0:1]"  0.99964308738708496 1;
	setAttr -s 2 ".koy[0:1]"  0.026714231818914413 0;
createNode animCurveTA -n "animCurveTA552";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 1.0246820449829102;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.91674381494522095 1;
	setAttr -s 2 ".kiy[0:1]"  -0.39947566390037537 0;
	setAttr -s 2 ".kox[0:1]"  0.9998396635055542 1;
	setAttr -s 2 ".koy[0:1]"  0.017903715372085571 0;
createNode animCurveTL -n "animCurveTL550";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -1.1657956838607788 90 -0.72905689477920532;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.091365613043308258 1;
	setAttr -s 2 ".kiy[0:1]"  -0.99581742286682129 0;
	setAttr -s 2 ".kox[0:1]"  0.91622847318649292 1;
	setAttr -s 2 ".koy[0:1]"  0.40065616369247437 0;
createNode animCurveTL -n "animCurveTL551";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -19.400392532348633 90 -19.141372680664063;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.15527833998203278 1;
	setAttr -s 2 ".kiy[0:1]"  -0.98787075281143188 0;
	setAttr -s 2 ".kox[0:1]"  0.96797621250152588 1;
	setAttr -s 2 ".koy[0:1]"  0.25104179978370667 0;
createNode animCurveTL -n "animCurveTL552";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 23.549764633178711 90 23.549764633178711;
	setAttr -s 2 ".kix[0:1]"  0.99609410762786865 1;
	setAttr -s 2 ".kiy[0:1]"  -0.088298074901103973 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU553";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU554";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU555";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA553";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0.062256276607513428 69 -31.845605850219723
		 90 0;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99964606761932373 0.99556243419647217 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.026604980230331421 -0.094103753566741943 
		0;
	setAttr -s 3 ".kox[0:2]"  0.21684476733207703 0.9999958872795105 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.97620606422424316 0.0029004446696490049 
		0;
createNode animCurveTA -n "animCurveTA554";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -82.192222595214844 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.98701238632202148 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.16064436733722687 0;
	setAttr -s 3 ".kox[0:2]"  0.052327200770378113 0.99997198581695557 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99862998723983765 0.0074857533909380436 
		0;
createNode animCurveTA -n "animCurveTA555";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -27.633144378662109 90 12.527528762817383;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.096388399600982666 0.99858886003494263 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.99534386396408081 -0.053106497973203659 
		0;
	setAttr -s 3 ".kox[0:2]"  0.15072375535964966 0.99999332427978516 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.98857587575912476 0.0036577582359313965 
		0;
createNode animCurveTL -n "animCurveTL553";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -36.00830078125 69 -19.895614624023438
		 90 -36.1805419921875;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.16089868545532227 0.47990509867668152 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.98697084188461304 0.87732040882110596 
		0;
	setAttr -s 3 ".kox[0:2]"  0.004665059968829155 0.99640846252441406 
		1;
	setAttr -s 3 ".koy[0:2]"  0.9999890923500061 -0.084676459431648254 
		0;
createNode animCurveTL -n "animCurveTL554";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 16.485666275024414 69 9.7852306365966797
		 90 7.3658723831176758;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.0044994214549660683 0.6603284478187561 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.99998986721038818 -0.75097686052322388 
		0;
	setAttr -s 3 ".kox[0:2]"  0.0184588972479105 0.99992036819458008 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99982959032058716 -0.012624240480363369 
		0;
createNode animCurveTL -n "animCurveTL555";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 41.597587585449219 69 53.975368499755859
		 90 41.597393035888672;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99997586011886597 0.58004212379455566 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.0069462056271731853 0.81458652019500732 
		0;
	setAttr -s 3 ".kox[0:2]"  0.0060726669616997242 0.99792033433914185 
		1;
	setAttr -s 3 ".koy[0:2]"  0.9999815821647644 -0.064459219574928284 
		0;
createNode animCurveTU -n "animCurveTU556";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU557";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU558";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA556";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0.0048254411667585373;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.99999696016311646 1;
	setAttr -s 2 ".kiy[0:1]"  -0.0024595898576080799 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  8.4325860370881855e-005 0;
createNode animCurveTA -n "animCurveTA557";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 1.5292341709136963;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.83491075038909912 1;
	setAttr -s 2 ".kiy[0:1]"  -0.55038535594940186 0;
	setAttr -s 2 ".kox[0:1]"  0.99964308738708496 1;
	setAttr -s 2 ".koy[0:1]"  0.026714231818914413 0;
createNode animCurveTA -n "animCurveTA558";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -116.02542877197266 90 1.0246820449829102;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.87713074684143066 0.97106605768203735 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.48025161027908325 -0.23881122469902039 
		0;
	setAttr -s 3 ".kox[0:2]"  0.03927772119641304 0.99994325637817383 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99922829866409302 0.010660170577466488 
		0;
createNode animCurveTL -n "animCurveTL556";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -0.55049139261245728 69 1.4949040412902832
		 90 -0.11375267058610916;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.091365613043308258 0.94468927383422852 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.99581742286682129 0.32796677947044373 
		0;
	setAttr -s 3 ".kox[0:2]"  0.060368817299604416 0.99996477365493774 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99817609786987305 -0.0083943624049425125 
		0;
createNode animCurveTL -n "animCurveTL557";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -0.32648545503616333 69 -16.930826187133789
		 90 -0.067464433610439301;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.11330085247755051 0.44439959526062012 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.99356073141098022 -0.89582866430282593 
		0;
	setAttr -s 3 ".kox[0:2]"  0.004792406689375639 0.99615031480789185 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99998855590820313 0.087661445140838623 
		0;
createNode animCurveTL -n "animCurveTL558";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 41.135360717773437 69 6.5330557823181152
		 90 41.135360717773437;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99609410762786865 0.23140786588191986 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.088298074901103973 -0.97285687923431396 
		0;
	setAttr -s 3 ".kox[0:2]"  0.0023013136815279722 0.98408544063568115 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99999731779098511 0.17769590020179749 
		0;
createNode animCurveTU -n "animCurveTU559";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU560";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU561";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA559";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0.062256276607513428 69 79.531150817871094
		 90 0;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99924689531326294 0.98784446716308594 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.038802113384008408 0.15544509887695313 
		0;
	setAttr -s 3 ".kox[0:2]"  0.054113123565912247 0.99997377395629883 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99853479862213135 -0.0072434050962328911 
		0;
createNode animCurveTA -n "animCurveTA560";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -1.4485911130905151 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.9999958872795105 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.0028685091529041529 0;
	setAttr -s 3 ".kox[0:2]"  0.94782161712646484 1 1;
	setAttr -s 3 ".koy[0:2]"  -0.31880101561546326 0.00013193584163673222 
		0;
createNode animCurveTA -n "animCurveTA561";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 3.6046044826507568 90 12.527528762817383;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.18177492916584015 0.95310407876968384 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.98334020376205444 0.30264276266098022 
		0;
	setAttr -s 3 ".kox[0:2]"  0.8925400972366333 0.95424449443817139 
		1;
	setAttr -s 3 ".koy[0:2]"  0.45096796751022339 0.29902741312980652 
		0;
createNode animCurveTL -n "animCurveTL559";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -54.523086547851563 69 -48.936054229736328
		 90 -54.695327758789062;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.16089868545532227 0.84460526704788208 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.98697084188461304 0.53538954257965088 
		0;
	setAttr -s 3 ".kox[0:2]"  0.013452709652483463 0.99954867362976074 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99990952014923096 -0.030040768906474113 
		0;
createNode animCurveTL -n "animCurveTL560";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 12.371971130371094 69 2.2865941524505615
		 90 3.2521772384643555;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.0044994214549660683 0.50441431999206543 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.99998986721038818 -0.86346173286437988 
		0;
	setAttr -s 3 ".kox[0:2]"  0.012264726683497429 0.99998730421066284 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99992477893829346 0.005038759671151638 
		0;
createNode animCurveTL -n "animCurveTL561";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0.00019504915690049529 69 -5.7815289497375488
		 90 0;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99998873472213745 0.71373343467712402 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.0047532781027257442 -0.70041745901107788 
		0;
	setAttr -s 3 ".kox[0:2]"  0.021390752866864204 0.99954509735107422 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99977117776870728 0.030156750231981277 
		0;
createNode animCurveTU -n "animCurveTU562";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU563";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU564";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA562";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0.0048254411667585373;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.99999696016311646 1;
	setAttr -s 2 ".kiy[0:1]"  -0.0024595898576080799 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  8.4325860370881855e-005 0;
createNode animCurveTA -n "animCurveTA563";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 1.5292341709136963;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.83491075038909912 1;
	setAttr -s 2 ".kiy[0:1]"  -0.55038535594940186 0;
	setAttr -s 2 ".kox[0:1]"  0.99964308738708496 1;
	setAttr -s 2 ".koy[0:1]"  0.026714231818914413 0;
createNode animCurveTA -n "animCurveTA564";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 1.0246820449829102;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.91674381494522095 1;
	setAttr -s 2 ".kiy[0:1]"  -0.39947566390037537 0;
	setAttr -s 2 ".kox[0:1]"  0.9998396635055542 1;
	setAttr -s 2 ".koy[0:1]"  0.017903715372085571 0;
createNode animCurveTL -n "animCurveTL562";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -3.0419566631317139 90 -2.6052179336547852;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.091365613043308258 1;
	setAttr -s 2 ".kiy[0:1]"  -0.99581742286682129 0;
	setAttr -s 2 ".kox[0:1]"  0.91622847318649292 1;
	setAttr -s 2 ".koy[0:1]"  0.40065616369247437 0;
createNode animCurveTL -n "animCurveTL563";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -19.400392532348633 90 -19.141372680664063;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.15527833998203278 1;
	setAttr -s 2 ".kiy[0:1]"  -0.98787075281143188 0;
	setAttr -s 2 ".kox[0:1]"  0.96797621250152588 1;
	setAttr -s 2 ".koy[0:1]"  0.25104179978370667 0;
createNode animCurveTL -n "animCurveTL564";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 23.227632522583008 90 23.227632522583008;
	setAttr -s 2 ".kix[0:1]"  0.99609410762786865 1;
	setAttr -s 2 ".kiy[0:1]"  -0.088298074901103973 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU565";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU566";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU567";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA565";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 0.062256276607513428 69 -141.62908935546875
		 79 15.853647232055664 90 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.99964606761932373 0.91355973482131958 
		0.99800848960876465 1;
	setAttr -s 4 ".kiy[0:3]"  0.026604980230331421 -0.40670448541641235 
		0.063079982995986938 0;
	setAttr -s 4 ".kox[0:3]"  0.056626636534929276 0.99800986051559448 
		0.99998611211776733 1;
	setAttr -s 4 ".koy[0:3]"  -0.99839544296264648 0.063057556748390198 
		-0.0052576512098312378 0;
createNode animCurveTA -n "animCurveTA566";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 0 69 36.570098876953125 79 60.472423553466797
		 90 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.32137948274612427 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0.94695043563842773 0 0;
	setAttr -s 4 ".kox[0:3]"  0.068589173257350922 0.31681337952613831 
		0.99979889392852783 1;
	setAttr -s 4 ".koy[0:3]"  0.99764502048492432 0.94848787784576416 
		-0.020051121711730957 0;
createNode animCurveTA -n "animCurveTA567";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 0 69 -121.27610778808594 79 11.400468826293945
		 90 12.527528762817383;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.096388399600982666 0.97040784358978271 
		0.9839775562286377 1;
	setAttr -s 4 ".kiy[0:3]"  -0.99534386396408081 -0.2414717972278595 
		0.17829242348670959 0;
	setAttr -s 4 ".kox[0:3]"  0.036533236503601074 0.99860793352127075 
		0.99186074733734131 1;
	setAttr -s 4 ".koy[0:3]"  -0.99933242797851563 0.05274670198559761 
		0.12732666730880737 0;
createNode animCurveTL -n "animCurveTL565";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -36.00830078125 69 30.172710418701172
		 90 -36.1805419921875;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.16089868545532227 0.087698578834533691 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.98697084188461304 0.9961470365524292 
		0;
	setAttr -s 3 ".kox[0:2]"  0.0019108220003545284 0.94495522975921631 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99999821186065674 -0.327199786901474 
		0;
createNode animCurveTL -n "animCurveTL566";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 16.485666275024414 69 40.470111846923828
		 90 7.3658723831176758;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.0030789240263402462 0.34492877125740051 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.99999529123306274 0.93862885236740112 
		0;
	setAttr -s 3 ".kox[0:2]"  0.0031339942943304777 0.98540419340133667 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99999511241912842 -0.17023062705993652 
		0;
createNode animCurveTL -n "animCurveTL567";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -41.399566650390625 69 -61.744575500488281
		 90 -41.399761199951172;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99998873472213745 0.27815824747085571 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.0047532781027257442 -0.96053522825241089 
		0;
	setAttr -s 3 ".kox[0:2]"  0.006080184131860733 0.9944114089012146 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99998152256011963 0.1055745854973793 
		0;
createNode animCurveTU -n "animCurveTU568";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU569";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU570";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA568";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -18.101388931274414 80 13.149617195129395
		 90 0;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.81612461805343628 0.99997955560684204 
		0.99998611211776733;
	setAttr -s 3 ".kiy[0:2]"  -0.57787591218948364 0.0064007933251559734 
		-0.0052756550721824169;
	setAttr -s 3 ".kox[0:2]"  0.99997955560684204 0.99998611211776733 
		1;
	setAttr -s 3 ".koy[0:2]"  0.0064007933251559734 -0.005277540534734726 
		0;
createNode animCurveTA -n "animCurveTA569";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 14.616578102111816 80 15.084242820739746
		 90 0;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.85329025983810425 1 0.99998164176940918;
	setAttr -s 3 ".kiy[0:2]"  0.52143621444702148 0 -0.0060518034733831882;
	setAttr -s 3 ".kox[0:2]"  0.99912422895431519 0.99998164176940918 
		1;
	setAttr -s 3 ".koy[0:2]"  0.041841857135295868 -0.0060539674013853073 
		0;
createNode animCurveTA -n "animCurveTA570";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 78.005088806152344 80 41.954982757568359
		 90 0;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.31142812967300415 0.29589629173278809 
		0.99997878074645996;
	setAttr -s 3 ".kiy[0:2]"  0.95026969909667969 -0.95522010326385498 
		-0.0065124384127557278;
	setAttr -s 3 ".kox[0:2]"  1 0.29555168747901917 1;
	setAttr -s 3 ".koy[0:2]"  0 -0.95532673597335815 0;
createNode animCurveTL -n "animCurveTL568";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 20.077089309692383 80 3.6638190746307373
		 90 22.400806427001953;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.013384945690631866 0.99972409009933472 
		0.91843020915985107;
	setAttr -s 3 ".kiy[0:2]"  -0.99991041421890259 -0.023487644270062447 
		0.39558321237564087;
	setAttr -s 3 ".kox[0:2]"  0.013508541509509087 0.91837877035140991 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.9999086856842041 0.39570245146751404 
		0;
createNode animCurveTL -n "animCurveTL569";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -1.2265430688858032 90 10.647112846374512;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.037550892680883408 0.99887633323669434;
	setAttr -s 2 ".kiy[0:1]"  -0.99929475784301758 0.047392211854457855;
	setAttr -s 2 ".kox[0:1]"  0.99887633323669434 1;
	setAttr -s 2 ".koy[0:1]"  0.047392211854457855 0;
createNode animCurveTL -n "animCurveTL570";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 15.736483573913574 90 0;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  0.028341896831989288 0.99802881479263306;
	setAttr -s 2 ".kiy[0:1]"  0.99959832429885864 -0.062756910920143127;
	setAttr -s 2 ".kox[0:1]"  0.99802881479263306 1;
	setAttr -s 2 ".koy[0:1]"  -0.062756910920143127 0;
createNode animCurveTU -n "animCurveTU571";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU572";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU573";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA571";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA572";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA573";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL571";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 35.083248138427734 90 35.083248138427734;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL572";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 30.643020629882813 90 30.643020629882813;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL573";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 36.804916381835937 90 36.804916381835937;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU574";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU575";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU576";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA574";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA575";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA576";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL574";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 35.083248138427734 90 35.083248138427734;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL575";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 30.643020629882813 90 30.643020629882813;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL576";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -36.361770629882813 90 -36.361770629882813;
	setAttr -s 2 ".ktl[0:1]" no yes;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU577";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU578";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU579";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA577";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 14.535603523254393 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99952524900436401 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.030808469280600548 0;
	setAttr -s 3 ".kox[0:2]"  0.2994791567325592 0.99999910593032837 
		1;
	setAttr -s 3 ".koy[0:2]"  0.95410281419754028 -0.0013238830724731088 
		0;
createNode animCurveTA -n "animCurveTA578";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -6.2114448547363281 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99991321563720703 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.013170375488698483 0;
	setAttr -s 3 ".kox[0:2]"  0.59199255704879761 0.99999982118606567 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.80594342947006226 0.00056573032634332776 
		0;
createNode animCurveTA -n "animCurveTA579";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -23.420516967773438 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99876904487609863 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.04960264265537262 0;
	setAttr -s 3 ".kox[0:2]"  0.19121384620666504 0.99999767541885376 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.98154842853546143 0.0021331054158508778 
		0;
createNode animCurveTL -n "animCurveTL577";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -5.8221402168273926 69 -5.8221402168273926
		 90 -5.8221402168273926;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL578";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -10.433219909667969 69 -10.433219909667969
		 90 -10.433219909667969;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL579";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -28.427871704101563 69 -28.427871704101563
		 90 -28.427871704101563;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU580";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU581";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU582";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA580";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 0 69 55.218418121337891 79 -5.1879787445068359
		 90 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.98688375949859619 0.99970626831054688 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.16143243014812469 -0.024237057194113731 
		0;
	setAttr -s 4 ".kox[0:3]"  0.12731312215328217 0.9997064471244812 
		0.99999850988388062 1;
	setAttr -s 4 ".koy[0:3]"  0.99186265468597412 -0.024228397756814957 
		0.0017205455806106329 0;
createNode animCurveTA -n "animCurveTA581";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 0 69 40.382923126220703 79 54.036571502685547
		 90 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.49297705292701721 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0.87004232406616211 0 0;
	setAttr -s 4 ".kox[0:3]"  0.11249415576457977 0.50477725267410278 
		0.99983954429626465 1;
	setAttr -s 4 ".koy[0:3]"  0.99365240335464478 0.86324965953826904 
		-0.01791788637638092 0;
createNode animCurveTA -n "animCurveTA582";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 0 69 56.378120422363281 79 11.136163711547852
		 90 0;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.99292945861816406 0.6149412989616394 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.1187058761715889 -0.78857284784317017 
		0;
	setAttr -s 4 ".kox[0:3]"  0.08066336065530777 0.9999006986618042 
		0.61912119388580322 1;
	setAttr -s 4 ".koy[0:3]"  0.99674141407012939 -0.014092624187469482 
		-0.78529542684555054 0;
createNode animCurveTL -n "animCurveTL580";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 11.41090202331543 69 11.41090202331543
		 90 11.41090202331543;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL581";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -0.91886520385742188 69 -0.91886520385742188
		 90 -0.91886520385742188;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL582";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -13.740226745605469 69 -13.740226745605469
		 90 -13.740226745605469;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU583";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU584";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU585";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA583";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 124.35298156738283 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.96694695949554443 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.25497764348983765 0;
	setAttr -s 3 ".kox[0:2]"  0.036665339022874832 0.99993586540222168 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99932765960693359 -0.011325185187160969 
		0;
createNode animCurveTA -n "animCurveTA584";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 74.599456787109375 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.98771804571151733 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.15624704957008362 0;
	setAttr -s 3 ".kox[0:2]"  0.061046186834573746 0.99997693300247192 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99813497066497803 -0.0067942645400762558 
		0;
createNode animCurveTA -n "animCurveTA585";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 66.628868103027344 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99016577005386353 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.13989865779876709 0;
	setAttr -s 3 ".kox[0:2]"  0.068316534161567688 0.99998164176940918 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99766373634338379 -0.0060683600604534149 
		0;
createNode animCurveTL -n "animCurveTL583";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 0.057151313871145248 69 37.553073883056641
		 79 27.298284530639648 90 0.057151313871145248;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.21440322697162628 0.013584543950855732 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.97674518823623657 -0.9999077320098877 
		0;
	setAttr -s 4 ".kox[0:3]"  0.0021237153559923172 1 0.013527290895581245 
		1;
	setAttr -s 4 ".koy[0:3]"  0.99999779462814331 -0.00025191513122990727 
		-0.999908447265625 0;
createNode animCurveTL -n "animCurveTL584";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 23.729547500610352 69 27.447813034057617
		 79 44.221267700195312 90 23.729547500610352;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.015927830711007118 0.98374229669570923 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.99987316131591797 0.17958569526672363 
		0;
	setAttr -s 4 ".kox[0:3]"  0.021723682060837746 0.015708176419138908 
		0.9318510890007019 1;
	setAttr -s 4 ".koy[0:3]"  0.99976396560668945 0.99987661838531494 
		-0.3628409206867218 0;
createNode animCurveTL -n "animCurveTL585";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -53.338920593261719 69 -33.887031555175781
		 79 -55.223255157470703 90 -53.338920593261719;
	setAttr -s 4 ".ktl[0:3]" no yes yes no;
	setAttr -s 4 ".kix[0:3]"  1 0.38968035578727722 0.8977624773979187 
		1;
	setAttr -s 4 ".kiy[0:3]"  0 0.92095017433166504 -0.44047990441322327 
		0;
	setAttr -s 4 ".kox[0:3]"  0.0040937038138508797 0.89782470464706421 
		0.9993596076965332 1;
	setAttr -s 4 ".koy[0:3]"  0.99999159574508667 -0.44035312533378601 
		0.035782508552074432 0;
createNode animCurveTU -n "animCurveTU586";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU587";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU588";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA586";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -12.352696418762207 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99965715408325195 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.026185210794210434 0;
	setAttr -s 3 ".kox[0:2]"  0.34647563099861145 0.99999934434890747 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.93805903196334839 0.0011250671232119203 
		0;
createNode animCurveTA -n "animCurveTA587";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 5.9298720359802246 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99992096424102783 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.012573445215821266 0;
	setAttr -s 3 ".kox[0:2]"  0.60980099439620972 0.99999982118606567 
		1;
	setAttr -s 3 ".koy[0:2]"  0.79255455732345581 -0.00054008507868275046 
		0;
createNode animCurveTA -n "animCurveTA588";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -24.585111618041992 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99864381551742554 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.052062615752220154 0;
	setAttr -s 3 ".kox[0:2]"  0.18246488273143768 0.99999749660491943 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.98321235179901123 0.0022391749080270529 
		0;
createNode animCurveTL -n "animCurveTL586";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -5.8221402168273926 69 -5.8221402168273926
		 90 -5.8221402168273926;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL587";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -10.433219909667969 69 -10.433219909667969
		 90 -10.433219909667969;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL588";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 28.427871704101563 69 28.427871704101563
		 90 28.427871704101563;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU589";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU590";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU591";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA589";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -30.54871940612793 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99790841341018677 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.064643800258636475 0;
	setAttr -s 3 ".kox[0:2]"  0.14771360158920288 0.99999606609344482 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.98903018236160278 0.0027823273558169603 
		0;
createNode animCurveTA -n "animCurveTA590";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -16.072597503662109 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99886840581893921 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.047559265047311783 0;
	setAttr -s 3 ".kox[0:2]"  0.40349021553993225 0.99999892711639404 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.91498398780822754 0.0014638700522482395 
		0;
createNode animCurveTA -n "animCurveTA591";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 35.002620697021484 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99725675582885742 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.074020281434059143 0;
	setAttr -s 3 ".kox[0:2]"  0.12925446033477783 0.99999493360519409 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99161148071289063 -0.0031879774760454893 
		0;
createNode animCurveTL -n "animCurveTL589";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 11.41090202331543 69 11.41090202331543
		 90 11.41090202331543;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL590";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -0.91886520385742188 69 -0.91886520385742188
		 90 -0.91886520385742188;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL591";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 13.740226745605469 69 13.740226745605469
		 90 13.740226745605469;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU592";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU593";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU594";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 69 1 90 1;
	setAttr -s 3 ".kix[0:2]"  1 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  1 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA592";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -31.644380569458004 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.9977562427520752 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.066952109336853027 0;
	setAttr -s 3 ".kox[0:2]"  0.14270515739917755 0.9999958872795105 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.98976528644561768 0.0028821185696870089 
		0;
createNode animCurveTA -n "animCurveTA593";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -120.66969299316405 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.96878665685653687 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.24789603054523468 0;
	setAttr -s 3 ".kox[0:2]"  0.037782862782478333 0.99993962049484253 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99928605556488037 0.010989777743816376 
		0;
createNode animCurveTA -n "animCurveTA594";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0 69 -28.072965621948242 90 0;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.99823278188705444 1;
	setAttr -s 3 ".kiy[0:2]"  0 -0.059424187988042831 0;
	setAttr -s 3 ".kox[0:2]"  0.16041851043701172 0.99999678134918213 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.98704910278320313 0.0025568411219865084 
		0;
createNode animCurveTL -n "animCurveTL592";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 0.057151321321725845 69 33.809486389160156
		 90 0.057151321321725845;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.23691198229789734 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.97153109312057495 0;
	setAttr -s 3 ".kox[0:2]"  0.0023592656943947077 0.98484021425247192 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99999719858169556 -0.17346395552158356 
		0;
createNode animCurveTL -n "animCurveTL593";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 23.729547500610352 69 27.486017227172852
		 90 23.729547500610352;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.9097297191619873 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.41520088911056519 0;
	setAttr -s 3 ".kox[0:2]"  0.021193567663431168 0.99980789422988892 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99977535009384155 -0.019599102437496185 
		0;
createNode animCurveTL -n "animCurveTL594";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 53.782066345214844 69 69.243682861328125
		 90 53.782066345214844;
	setAttr -s 3 ".ktl[0:2]" no yes no;
	setAttr -s 3 ".kix[0:2]"  1 0.46989709138870239 1;
	setAttr -s 3 ".kiy[0:2]"  0 0.88272124528884888 0;
	setAttr -s 3 ".kox[0:2]"  0.0051501616835594177 0.99676072597503662 
		1;
	setAttr -s 3 ".koy[0:2]"  0.99998670816421509 -0.080423958599567413 
		0;
createNode animCurveTU -n "animCurveTU595";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU596";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU597";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA595";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -3.7031140327453613 73 -7.0405011177062988
		 90 0;
	setAttr -s 3 ".kix[0:2]"  0.88200497627258301 0.99999982118606567 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.47124013304710388 -0.00061015633400529623 
		0;
	setAttr -s 3 ".kox[0:2]"  0.90695780515670776 0.9999995231628418 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.42122155427932739 0.00097826682031154633 
		0;
createNode animCurveTA -n "animCurveTA596";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 -28.102071762084961 73 -25.78117561340332
		 90 0;
	setAttr -s 3 ".kix[0:2]"  0.80337905883789063 0.95158219337463379 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.59546786546707153 0.30739444494247437 
		0;
	setAttr -s 3 ".kox[0:2]"  0.99999988079071045 0.95064258575439453 
		1;
	setAttr -s 3 ".koy[0:2]"  0.00042416460928507149 0.31028804183006287 
		0;
createNode animCurveTA -n "animCurveTA597";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 9.6554994583129883 73 47.193828582763672
		 90 0;
	setAttr -s 3 ".kix[0:2]"  0.21097338199615479 0.99995535612106323 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.97749179601669312 0.0094485068693757057 
		0;
	setAttr -s 3 ".kox[0:2]"  0.20977590978145599 0.99997848272323608 
		1;
	setAttr -s 3 ".koy[0:2]"  0.9777495265007019 -0.0065573705360293388 
		0;
createNode animCurveTL -n "animCurveTL595";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -1.1630247831344604 90 -1.1630247831344604;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL596";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1.228269100189209 90 1.228269100189209;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL597";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 27.684015274047852 90 27.684015274047852;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU598";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 1 67 1 78 1 90 1;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTU -n "animCurveTU599";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 1 67 1 78 1 90 1;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTU -n "animCurveTU600";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 1 67 1 78 1 90 1;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTA -n "animCurveTA598";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -14.757268404216875 67 -23.762521743774414
		 78 0 90 0;
	setAttr -s 4 ".ktl[2:3]" no no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.98774439096450806 
		0.99996888637542725 1;
	setAttr -s 4 ".kiy[0:3]"  -0.25756287574768066 -0.15608035027980804 
		0.0078803906217217445 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99996888637542725 
		1 1;
	setAttr -s 4 ".koy[0:3]"  -0.25756281614303589 0.0078803906217217445 
		0 0;
createNode animCurveTA -n "animCurveTA599";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -29.230034358603127 67 -47.066932678222656
		 78 0 90 0;
	setAttr -s 4 ".ktl[2:3]" no no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.95434755086898804 
		0.9998781681060791 1;
	setAttr -s 4 ".kiy[0:3]"  -0.51016032695770264 -0.2986985445022583 
		0.015607438981533051 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.9998781681060791 
		1 1;
	setAttr -s 4 ".koy[0:3]"  -0.51016020774841309 0.015607438981533051 
		0 0;
createNode animCurveTA -n "animCurveTA600";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 13.311920455587789 67 21.435186386108398
		 78 0 90 0;
	setAttr -s 4 ".ktl[2:3]" no no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.98999309539794922 
		0.99997466802597046 1;
	setAttr -s 4 ".kiy[0:3]"  0.23233677446842194 0.1411156952381134 
		-0.0071086147800087929 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99997466802597046 
		1 1;
	setAttr -s 4 ".koy[0:3]"  0.23233680427074432 -0.0071086147800087929 
		0 0;
createNode animCurveTL -n "animCurveTL598";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 4.9883952140808105 67 4.9883952140808105
		 78 4.9883952140808105 90 4.9883952140808105;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL599";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 41.4617919921875 67 41.4617919921875
		 78 41.4617919921875 90 41.4617919921875;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL600";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 38.623714447021484 67 38.623714447021484
		 78 38.623714447021484 90 38.623714447021484;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTU -n "animCurveTU601";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 67 1 90 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU602";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 67 1 90 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU603";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1 67 1 90 1;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTA -n "animCurveTA601";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 19.982691961780986 67 32.299873352050781
		 77 33.248371124267578 90 0;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.94589477777481079 
		1 1;
	setAttr -s 4 ".kiy[0:3]"  0.34876361489295959 0.32447355985641479 
		0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99140536785125732 
		0.99996882677078247 1;
	setAttr -s 4 ".koy[0:3]"  0.34876361489295959 0.13082586228847504 
		-0.0078996680676937103 0;
createNode animCurveTA -n "animCurveTA602";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 20.23746713207051 67 32.586875915527344
		 77 18.667545318603516 90 0;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.97731709480285645 
		0.53982114791870117 1;
	setAttr -s 4 ".kiy[0:3]"  0.35321035981178284 0.21178099513053894 
		-0.84177976846694946 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99999982118606567 
		0.53947025537490845 1;
	setAttr -s 4 ".koy[0:3]"  0.35321041941642761 -0.00059683987637981772 
		-0.84200465679168701 0;
createNode animCurveTA -n "animCurveTA603";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 22.326918943372299 67 39.339519500732422
		 77 65.414306640625 90 0;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.25530102849006653 
		0.99999934434890747 1;
	setAttr -s 4 ".kiy[0:3]"  0.38967841863632202 0.96686160564422607 
		-0.0011499503161758184 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.26574742794036865 
		0.99987924098968506 1;
	setAttr -s 4 ".koy[0:3]"  0.38967844843864441 0.96404272317886353 
		-0.015540763735771179 0;
createNode animCurveTL -n "animCurveTL601";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 1.1630247831344604 67 1.1630247831344604
		 90 1.1630247831344604;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL602";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 2.0187394618988037 67 2.0187394618988037
		 90 2.0187394618988037;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTL -n "animCurveTL603";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 27.637619018554688 67 27.637619018554688
		 90 27.637619018554688;
	setAttr -s 3 ".kix[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".kiy[0:2]"  0 0 0;
	setAttr -s 3 ".kox[0:2]"  0.041666507720947266 1 1;
	setAttr -s 3 ".koy[0:2]"  0 0 0;
createNode animCurveTU -n "animCurveTU604";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 1 67 1 82 1 90 1;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTU -n "animCurveTU605";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 1 67 1 82 1 90 1;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTU -n "animCurveTU606";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 1 67 1 82 1 90 1;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTA -n "animCurveTA604";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -8.1476809148823168 67 -13.119601249694824
		 82 0 90 0;
	setAttr -s 4 ".ktl[2:3]" no no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.99621587991714478 
		0.99999725818634033 1;
	setAttr -s 4 ".kiy[0:3]"  -0.14220388233661652 -0.086913526058197021 
		0.0023419137578457594 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99999725818634033 
		1 1;
	setAttr -s 4 ".koy[0:3]"  -0.14220386743545532 0.002341077197343111 
		0 0;
createNode animCurveTA -n "animCurveTA605";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 29.158396125073338 67 46.951572418212891
		 82 0 90 0;
	setAttr -s 4 ".ktl[2:3]" no no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.9545556902885437 
		0.99996489286422729 1;
	setAttr -s 4 ".kiy[0:3]"  0.50890976190567017 0.29803240299224854 
		-0.008380817249417305 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99996489286422729 
		1 1;
	setAttr -s 4 ".koy[0:3]"  0.50890976190567017 -0.0083778230473399162 
		0 0;
createNode animCurveTA -n "animCurveTA606";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -14.891380710832596 67 -23.978475570678711
		 82 0 90 0;
	setAttr -s 4 ".ktl[2:3]" no no;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 0.98752480745315552 
		0.99999088048934937 1;
	setAttr -s 4 ".kiy[0:3]"  -0.25990363955497742 -0.1574636697769165 
		0.0042802495881915092 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 0.99999088048934937 
		1 1;
	setAttr -s 4 ".koy[0:3]"  -0.25990360975265503 0.0042787212878465652 
		0 0;
createNode animCurveTL -n "animCurveTL604";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 4.9883952140808105 67 4.9883952140808105
		 82 4.9883952140808105 90 4.9883952140808105;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL605";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 41.4617919921875 67 41.4617919921875
		 82 41.4617919921875 90 41.4617919921875;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTL -n "animCurveTL606";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -38.180568695068359 67 -38.180568695068359
		 82 -38.180568695068359 90 -38.180568695068359;
	setAttr -s 4 ".kix[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".kiy[0:3]"  0 0 0 0;
	setAttr -s 4 ".kox[0:3]"  0.041666507720947266 1 1 1;
	setAttr -s 4 ".koy[0:3]"  0 0 0 0;
createNode animCurveTU -n "animCurveTU607";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU608";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU609";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA607";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 5.8036012649536133 90 -9.5584049224853516;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA608";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -6.4366888999938965 90 -14.087939262390137;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA609";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 3.3406755924224854 83 3.7265639305114742
		 90 -2.2710940837860107;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99039983749389648 0.99523770809173584 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.13823196291923523 -0.097477413713932037 
		0;
	setAttr -s 3 ".kox[0:2]"  0.99039983749389648 0.99523770809173584 
		1;
	setAttr -s 3 ".koy[0:2]"  0.13823196291923523 -0.097477413713932037 
		0;
createNode animCurveTL -n "animCurveTL607";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 32.845657348632812 90 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL608";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 17.186578750610352 90 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL609";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 11.930496215820313 90 11.930496215820313;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU610";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU611";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU612";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA610";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1.7018897533416748 90 -0.89352136850357056;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA611";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 5.7117557525634766 90 11.041102409362793;
	setAttr -s 2 ".ktl[1]" no;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA612";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 2.5748500823974609 83 3.1349384784698486
		 90 0.32489952445030212;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.99786877632141113 0.99922990798950195 
		1;
	setAttr -s 3 ".kiy[0:2]"  0.065253227949142456 -0.039238806813955307 
		0;
	setAttr -s 3 ".kox[0:2]"  0.99786877632141113 0.99922990798950195 
		1;
	setAttr -s 3 ".koy[0:2]"  0.065253227949142456 -0.039238806813955307 
		0;
createNode animCurveTL -n "animCurveTL610";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 32.845657348632812 90 32.845657348632812;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL611";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 17.186578750610352 90 17.186578750610352;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL612";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 -11.48735237121582 90 -11.48735237121582;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU613";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU614";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU615";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA613";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA614";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA615";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL613";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 47.368160247802734 90 47.368160247802734;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL614";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 56.057479858398437 71 19.035701751708984
		 90 26.913848876953125;
	setAttr -s 3 ".kix[0:2]"  0.031717374920845032 0.034292634576559067 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.99949687719345093 -0.99941182136535645 
		0;
	setAttr -s 3 ".kox[0:2]"  0.031717374920845032 0.034292634576559067 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.99949687719345093 -0.99941182136535645 
		0;
createNode animCurveTL -n "animCurveTL615";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0.22157172858715057 90 0.22157172858715057;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU616";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU617";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU618";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA616";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 5.8795404434204102 67 6.1860184669494629
		 68 6.7944002151489258 78 6.7944002151489258 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.6110108494758606 0.98213368654251099 
		0.99973171949386597 0.99173593521118164 1;
	setAttr -s 5 ".kiy[0:4]"  0.79162222146987915 0.18818466365337372 
		0.023160917684435844 -0.12829601764678955 0;
	setAttr -s 5 ".kox[0:4]"  0.6110108494758606 0.98213368654251099 
		0.99973171949386597 0.99173593521118164 1;
	setAttr -s 5 ".koy[0:4]"  0.79162222146987915 0.18818466365337372 
		0.023160917684435844 -0.12829601764678955 0;
createNode animCurveTA -n "animCurveTA617";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 13.884525299072266 67 15.371606826782225
		 68 18.323575973510742 78 18.323575973510742 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.29663482308387756 0.7323763370513916 
		0.99374121427536011 0.94418764114379883 1;
	setAttr -s 5 ".kiy[0:4]"  0.95499104261398315 0.68090009689331055 
		0.1117071658372879 -0.329408198595047 0;
	setAttr -s 5 ".kox[0:4]"  0.29663482308387756 0.7323763370513916 
		0.99374121427536011 0.94418764114379883 1;
	setAttr -s 5 ".koy[0:4]"  0.95499104261398315 0.68090009689331055 
		0.1117071658372879 -0.329408198595047 0;
createNode animCurveTA -n "animCurveTA618";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 -0.43729013204574585 67 -2.9657173156738281
		 68 22.737916946411133 78 22.737916946411133 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.84946978092193604 0.20178580284118652 
		0.71464413404464722 0.91769099235534668 1;
	setAttr -s 5 ".kiy[0:4]"  -0.52763724327087402 0.97942972183227539 
		0.69948816299438477 -0.39729499816894531 0;
	setAttr -s 5 ".kox[0:4]"  0.84946978092193604 0.20178580284118652 
		0.71464413404464722 0.91769099235534668 1;
	setAttr -s 5 ".koy[0:4]"  -0.52763724327087402 0.97942972183227539 
		0.69948816299438477 -0.39729499816894531 0;
createNode animCurveTL -n "animCurveTL616";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0.55634701251983643 90 0.55634701251983643;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL617";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  66 26.875389099121094 78 26.875389099121094
		 90 28.874954223632813;
	setAttr -s 3 ".ktl[2]" no;
	setAttr -s 3 ".kix[0:2]"  0.26146844029426575 0.44729128479957581 
		1;
	setAttr -s 3 ".kiy[0:2]"  -0.96521204710006714 0.89438831806182861 
		0;
	setAttr -s 3 ".kox[0:2]"  0.26146844029426575 0.44729128479957581 
		1;
	setAttr -s 3 ".koy[0:2]"  -0.96521204710006714 0.89438831806182861 
		0;
createNode animCurveTL -n "animCurveTL618";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU619";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU620";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU621";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA619";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 10.509672164916992 67 12.110006332397461
		 68 15.286787986755371 78 15.286787986755371 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.36679390072822571 0.7069237232208252 
		0.99276226758956909 0.96015644073486328 1;
	setAttr -s 5 ".kiy[0:4]"  0.93030226230621338 0.70728975534439087 
		0.12009605020284653 -0.27946293354034424 0;
	setAttr -s 5 ".kox[0:4]"  0.36679390072822571 0.7069237232208252 
		0.99276226758956909 0.96015644073486328 1;
	setAttr -s 5 ".koy[0:4]"  0.93030226230621338 0.70728975534439087 
		0.12009605020284653 -0.27946293354034424 0;
createNode animCurveTA -n "animCurveTA620";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 -10.84833812713623 67 -12.500241279602051
		 68 -15.779392242431641 78 -15.779392242431641 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.35682135820388794 0.69562119245529175 
		0.99229377508163452 0.95771050453186035 1;
	setAttr -s 5 ".kiy[0:4]"  -0.93417263031005859 -0.71840876340866089 
		-0.12390754371881485 0.28773349523544312 0;
	setAttr -s 5 ".kox[0:4]"  0.35682135820388794 0.69562119245529175 
		0.99229377508163452 0.95771050453186035 1;
	setAttr -s 5 ".koy[0:4]"  -0.93417263031005859 -0.71840876340866089 
		-0.12390754371881485 0.28773349523544312 0;
createNode animCurveTA -n "animCurveTA621";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 5 ".ktv[0:4]"  66 -12.000167846679687 67 -13.827462196350098
		 68 -17.454780578613281 78 -17.454780578613281 90 0;
	setAttr -s 5 ".ktl[4]" no;
	setAttr -s 5 ".kix[0:4]"  0.32639187574386597 0.658649742603302 0.99059474468231201 
		0.94896620512008667 1;
	setAttr -s 5 ".kiy[0:4]"  -0.94523453712463379 -0.752449631690979 
		-0.13682880997657776 0.31537774205207825 0;
	setAttr -s 5 ".kox[0:4]"  0.32639187574386597 0.658649742603302 0.99059474468231201 
		0.94896620512008667 1;
	setAttr -s 5 ".koy[0:4]"  -0.94523453712463379 -0.752449631690979 
		-0.13682880997657776 0.31537774205207825 0;
createNode animCurveTL -n "animCurveTL619";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  66 -0.28501001000404358 68 20.909780502319336
		 69 -0.28501001000404358 70 -0.28501001000404358 71 -0.28501001000404358 72 -0.28501001000404358
		 73 -0.28501001000404358 74 -0.28501001000404358 75 -0.28501001000404358 78 -0.28501001000404358
		 90 -1.4725730419158936;
	setAttr -s 11 ".ktl[10]" no;
	setAttr -s 11 ".kix[0:10]"  0.0055846697650849819 1 0.0039317584596574306 
		1 1 1 1 1 1 0.4657270610332489 1;
	setAttr -s 11 ".kiy[0:10]"  0.99998444318771362 0 -0.9999922513961792 
		0 0 0 0 0 0 -0.88492840528488159 0;
	setAttr -s 11 ".kox[0:10]"  0.0055846697650849819 1 0.0039317584596574306 
		1 1 1 1 1 1 0.4657270610332489 1;
	setAttr -s 11 ".koy[0:10]"  0.99998444318771362 0 -0.9999922513961792 
		0 0 0 0 0 0 -0.88492840528488159 0;
createNode animCurveTL -n "animCurveTL620";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  66 25.007797241210938 68 25.007797241210938
		 69 25.007797241210938 70 25.007797241210938 71 25.007797241210938 72 25.007797241210938
		 73 25.007797241210938 74 25.007797241210938 75 25.007797241210938 78 25.007797241210938
		 90 25.007797241210938;
	setAttr -s 11 ".kix[0:10]"  1 1 1 1 1 1 1 1 1 1 1;
	setAttr -s 11 ".kiy[0:10]"  0 0 0 0 0 0 0 0 0 0 0;
	setAttr -s 11 ".kox[0:10]"  1 1 1 1 1 1 1 1 1 1 1;
	setAttr -s 11 ".koy[0:10]"  0 0 0 0 0 0 0 0 0 0 0;
createNode animCurveTL -n "animCurveTL621";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  66 0 68 0 69 -5.112180233001709 70 2.7128210067749023
		 71 -2.8264994621276855 72 1.4744890928268433 73 -1.7212549448013306 74 -0.86062377691268921
		 75 0 78 0 90 0;
	setAttr -s 11 ".kix[0:10]"  1 0.024444099515676498 0.03070390410721302 
		0.03643462061882019 0.067142918705940247 0.075184829533100128 0.035664331167936325 
		0.048357598483562469 0.19012570381164551 1 1;
	setAttr -s 11 ".kiy[0:10]"  0 -0.99970120191574097 0.99952852725982666 
		0.99933600425720215 -0.99774342775344849 0.99716955423355103 -0.99936383962631226 
		0.99883002042770386 0.98175972700119019 0 0;
	setAttr -s 11 ".kox[0:10]"  1 0.024444099515676498 0.03070390410721302 
		0.03643462061882019 0.067142918705940247 0.075184829533100128 0.035664331167936325 
		0.048357598483562469 0.19012570381164551 1 1;
	setAttr -s 11 ".koy[0:10]"  0 -0.99970120191574097 0.99952852725982666 
		0.99933600425720215 -0.99774342775344849 0.99716955423355103 -0.99936383962631226 
		0.99883002042770386 0.98175972700119019 0 0;
createNode animCurveTU -n "animCurveTU622";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU623";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU624";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA622";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA623";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA624";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL622";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  66 -1.4725730419158936 69 -27.484382629394531
		 70 -20.809471130371094 71 -25.196697235107422 72 -21.747085571289063 73 -23.04002571105957
		 74 -24.332965850830078 75 -24.076234817504883 78 -18.832187652587891 90 -0.28501001000404358;
	setAttr -s 10 ".ktl[9]" no;
	setAttr -s 10 ".kix[0:9]"  0.006127478089183569 0.0086187832057476044 
		0.036402739584445953 0.088528960943222046 0.038611043244600296 0.032209545373916626 
		0.080162480473518372 0.030284857377409935 0.026261130347847939 1;
	setAttr -s 10 ".kiy[0:9]"  -0.99998122453689575 -0.99996286630630493 
		0.99933713674545288 -0.99607360363006592 0.99925434589385986 -0.99948108196258545 
		-0.99678182601928711 0.99954128265380859 0.99965512752532959 0;
	setAttr -s 10 ".kox[0:9]"  0.006127478089183569 0.0086187832057476044 
		0.036402739584445953 0.088528960943222046 0.038611043244600296 0.032209545373916626 
		0.080162480473518372 0.030284857377409935 0.026261130347847939 1;
	setAttr -s 10 ".koy[0:9]"  -0.99998122453689575 -0.99996286630630493 
		0.99933713674545288 -0.99607360363006592 0.99925434589385986 -0.99948108196258545 
		-0.99678182601928711 0.99954128265380859 0.99965512752532959 0;
createNode animCurveTL -n "animCurveTL623";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL624";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU625";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU626";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU627";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA625";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA626";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA627";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL625";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL626";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTL -n "animCurveTL627";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 0 90 0;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU628";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU629";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTU -n "animCurveTU630";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  66 1 90 1;
	setAttr -s 2 ".kix[0:1]"  1 1;
	setAttr -s 2 ".kiy[0:1]"  0 0;
	setAttr -s 2 ".kox[0:1]"  1 1;
	setAttr -s 2 ".koy[0:1]"  0 0;
createNode animCurveTA -n "animCurveTA628";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -63.977764129638672 71 -20.56597900390625
		 80 -34.162349700927734 90 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.57152622938156128 0.74622762203216553 
		0.91075801849365234 1;
	setAttr -s 4 ".kiy[0:3]"  -0.82058382034301758 0.66569089889526367 
		0.4129403829574585 0;
	setAttr -s 4 ".kox[0:3]"  0.57152622938156128 0.74622762203216553 
		0.91075801849365234 1;
	setAttr -s 4 ".koy[0:3]"  -0.82058382034301758 0.66569089889526367 
		0.4129403829574585 0;
createNode animCurveTA -n "animCurveTA629";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 31.560354232788089 71 -24.857259750366211
		 80 -14.910648345947266 90 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.49928352236747742 0.58388364315032959 
		0.87695199251174927 1;
	setAttr -s 4 ".kiy[0:3]"  -0.86643868684768677 -0.81183737516403198 
		0.48057803511619568 0;
	setAttr -s 4 ".kox[0:3]"  0.49928352236747742 0.58388364315032959 
		0.87695199251174927 1;
	setAttr -s 4 ".koy[0:3]"  -0.86643868684768677 -0.81183737516403198 
		0.48057803511619568 0;
createNode animCurveTA -n "animCurveTA630";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -13.004505157470703 71 -50.588706970214844
		 80 -44.06903076171875 90 0;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.27243492007255554 0.73247301578521729 
		0.66757571697235107 1;
	setAttr -s 4 ".kiy[0:3]"  -0.9621741771697998 -0.68079608678817749 
		0.74454188346862793 0;
	setAttr -s 4 ".kox[0:3]"  0.27243492007255554 0.73247301578521729 
		0.66757571697235107 1;
	setAttr -s 4 ".koy[0:3]"  -0.9621741771697998 -0.68079608678817749 
		0.74454188346862793 0;
createNode animCurveTL -n "animCurveTL628";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -0.2280956357717514 71 1.3790065050125122
		 80 1.3790065050125122 90 2.0856802463531494;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.33351486921310425 0.34119150042533875 
		0.74601805210113525 1;
	setAttr -s 4 ".kiy[0:3]"  -0.94274485111236572 0.93999379873275757 
		0.66592580080032349 0;
	setAttr -s 4 ".kox[0:3]"  0.33351486921310425 0.34119150042533875 
		0.74601805210113525 1;
	setAttr -s 4 ".koy[0:3]"  -0.94274485111236572 0.93999379873275757 
		0.66592580080032349 0;
createNode animCurveTL -n "animCurveTL629";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 -6.2536416053771973 71 -5.5554494857788086
		 80 -5.5554494857788086 90 -5.0555992126464844;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.44732066988945007 0.64116138219833374 
		0.84556096792221069 1;
	setAttr -s 4 ".kiy[0:3]"  -0.89437365531921387 0.76740610599517822 
		0.5338788628578186 0;
	setAttr -s 4 ".kox[0:3]"  0.44732066988945007 0.64116138219833374 
		0.84556096792221069 1;
	setAttr -s 4 ".koy[0:3]"  -0.89437365531921387 0.76740610599517822 
		0.5338788628578186 0;
createNode animCurveTL -n "animCurveTL630";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  66 22.264823913574219 71 23.173675537109375
		 80 23.173675537109375 90 28.250843048095703;
	setAttr -s 4 ".ktl[3]" no;
	setAttr -s 4 ".kix[0:3]"  0.049180462956428528 0.54014867544174194 
		0.15406519174575806 1;
	setAttr -s 4 ".kiy[0:3]"  -0.99878990650177002 0.84156966209411621 
		0.98806071281433105 0;
	setAttr -s 4 ".kox[0:3]"  0.049180462956428528 0.54014867544174194 
		0.15406519174575806 1;
	setAttr -s 4 ".koy[0:3]"  -0.99878990650177002 0.84156966209411621 
		0.98806071281433105 0;
select -ne :time1;
	setAttr ".o" 91;
	setAttr ".unw" 91;
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
connectAttr "bat_blockSource.cl" "clipLibrary1.sc[0]";
connectAttr "animCurveTU541.a" "clipLibrary1.cel[0].cev[0].cevr";
connectAttr "animCurveTU542.a" "clipLibrary1.cel[0].cev[1].cevr";
connectAttr "animCurveTU543.a" "clipLibrary1.cel[0].cev[2].cevr";
connectAttr "animCurveTA541.a" "clipLibrary1.cel[0].cev[3].cevr";
connectAttr "animCurveTA542.a" "clipLibrary1.cel[0].cev[4].cevr";
connectAttr "animCurveTA543.a" "clipLibrary1.cel[0].cev[5].cevr";
connectAttr "animCurveTL541.a" "clipLibrary1.cel[0].cev[6].cevr";
connectAttr "animCurveTL542.a" "clipLibrary1.cel[0].cev[7].cevr";
connectAttr "animCurveTL543.a" "clipLibrary1.cel[0].cev[8].cevr";
connectAttr "animCurveTU544.a" "clipLibrary1.cel[0].cev[9].cevr";
connectAttr "animCurveTU545.a" "clipLibrary1.cel[0].cev[10].cevr";
connectAttr "animCurveTU546.a" "clipLibrary1.cel[0].cev[11].cevr";
connectAttr "animCurveTA544.a" "clipLibrary1.cel[0].cev[12].cevr";
connectAttr "animCurveTA545.a" "clipLibrary1.cel[0].cev[13].cevr";
connectAttr "animCurveTA546.a" "clipLibrary1.cel[0].cev[14].cevr";
connectAttr "animCurveTL544.a" "clipLibrary1.cel[0].cev[15].cevr";
connectAttr "animCurveTL545.a" "clipLibrary1.cel[0].cev[16].cevr";
connectAttr "animCurveTL546.a" "clipLibrary1.cel[0].cev[17].cevr";
connectAttr "animCurveTU547.a" "clipLibrary1.cel[0].cev[18].cevr";
connectAttr "animCurveTU548.a" "clipLibrary1.cel[0].cev[19].cevr";
connectAttr "animCurveTU549.a" "clipLibrary1.cel[0].cev[20].cevr";
connectAttr "animCurveTA547.a" "clipLibrary1.cel[0].cev[21].cevr";
connectAttr "animCurveTA548.a" "clipLibrary1.cel[0].cev[22].cevr";
connectAttr "animCurveTA549.a" "clipLibrary1.cel[0].cev[23].cevr";
connectAttr "animCurveTL547.a" "clipLibrary1.cel[0].cev[24].cevr";
connectAttr "animCurveTL548.a" "clipLibrary1.cel[0].cev[25].cevr";
connectAttr "animCurveTL549.a" "clipLibrary1.cel[0].cev[26].cevr";
connectAttr "animCurveTU550.a" "clipLibrary1.cel[0].cev[27].cevr";
connectAttr "animCurveTU551.a" "clipLibrary1.cel[0].cev[28].cevr";
connectAttr "animCurveTU552.a" "clipLibrary1.cel[0].cev[29].cevr";
connectAttr "animCurveTA550.a" "clipLibrary1.cel[0].cev[30].cevr";
connectAttr "animCurveTA551.a" "clipLibrary1.cel[0].cev[31].cevr";
connectAttr "animCurveTA552.a" "clipLibrary1.cel[0].cev[32].cevr";
connectAttr "animCurveTL550.a" "clipLibrary1.cel[0].cev[33].cevr";
connectAttr "animCurveTL551.a" "clipLibrary1.cel[0].cev[34].cevr";
connectAttr "animCurveTL552.a" "clipLibrary1.cel[0].cev[35].cevr";
connectAttr "animCurveTU553.a" "clipLibrary1.cel[0].cev[36].cevr";
connectAttr "animCurveTU554.a" "clipLibrary1.cel[0].cev[37].cevr";
connectAttr "animCurveTU555.a" "clipLibrary1.cel[0].cev[38].cevr";
connectAttr "animCurveTA553.a" "clipLibrary1.cel[0].cev[39].cevr";
connectAttr "animCurveTA554.a" "clipLibrary1.cel[0].cev[40].cevr";
connectAttr "animCurveTA555.a" "clipLibrary1.cel[0].cev[41].cevr";
connectAttr "animCurveTL553.a" "clipLibrary1.cel[0].cev[42].cevr";
connectAttr "animCurveTL554.a" "clipLibrary1.cel[0].cev[43].cevr";
connectAttr "animCurveTL555.a" "clipLibrary1.cel[0].cev[44].cevr";
connectAttr "animCurveTU556.a" "clipLibrary1.cel[0].cev[45].cevr";
connectAttr "animCurveTU557.a" "clipLibrary1.cel[0].cev[46].cevr";
connectAttr "animCurveTU558.a" "clipLibrary1.cel[0].cev[47].cevr";
connectAttr "animCurveTA556.a" "clipLibrary1.cel[0].cev[48].cevr";
connectAttr "animCurveTA557.a" "clipLibrary1.cel[0].cev[49].cevr";
connectAttr "animCurveTA558.a" "clipLibrary1.cel[0].cev[50].cevr";
connectAttr "animCurveTL556.a" "clipLibrary1.cel[0].cev[51].cevr";
connectAttr "animCurveTL557.a" "clipLibrary1.cel[0].cev[52].cevr";
connectAttr "animCurveTL558.a" "clipLibrary1.cel[0].cev[53].cevr";
connectAttr "animCurveTU559.a" "clipLibrary1.cel[0].cev[54].cevr";
connectAttr "animCurveTU560.a" "clipLibrary1.cel[0].cev[55].cevr";
connectAttr "animCurveTU561.a" "clipLibrary1.cel[0].cev[56].cevr";
connectAttr "animCurveTA559.a" "clipLibrary1.cel[0].cev[57].cevr";
connectAttr "animCurveTA560.a" "clipLibrary1.cel[0].cev[58].cevr";
connectAttr "animCurveTA561.a" "clipLibrary1.cel[0].cev[59].cevr";
connectAttr "animCurveTL559.a" "clipLibrary1.cel[0].cev[60].cevr";
connectAttr "animCurveTL560.a" "clipLibrary1.cel[0].cev[61].cevr";
connectAttr "animCurveTL561.a" "clipLibrary1.cel[0].cev[62].cevr";
connectAttr "animCurveTU562.a" "clipLibrary1.cel[0].cev[63].cevr";
connectAttr "animCurveTU563.a" "clipLibrary1.cel[0].cev[64].cevr";
connectAttr "animCurveTU564.a" "clipLibrary1.cel[0].cev[65].cevr";
connectAttr "animCurveTA562.a" "clipLibrary1.cel[0].cev[66].cevr";
connectAttr "animCurveTA563.a" "clipLibrary1.cel[0].cev[67].cevr";
connectAttr "animCurveTA564.a" "clipLibrary1.cel[0].cev[68].cevr";
connectAttr "animCurveTL562.a" "clipLibrary1.cel[0].cev[69].cevr";
connectAttr "animCurveTL563.a" "clipLibrary1.cel[0].cev[70].cevr";
connectAttr "animCurveTL564.a" "clipLibrary1.cel[0].cev[71].cevr";
connectAttr "animCurveTU565.a" "clipLibrary1.cel[0].cev[72].cevr";
connectAttr "animCurveTU566.a" "clipLibrary1.cel[0].cev[73].cevr";
connectAttr "animCurveTU567.a" "clipLibrary1.cel[0].cev[74].cevr";
connectAttr "animCurveTA565.a" "clipLibrary1.cel[0].cev[75].cevr";
connectAttr "animCurveTA566.a" "clipLibrary1.cel[0].cev[76].cevr";
connectAttr "animCurveTA567.a" "clipLibrary1.cel[0].cev[77].cevr";
connectAttr "animCurveTL565.a" "clipLibrary1.cel[0].cev[78].cevr";
connectAttr "animCurveTL566.a" "clipLibrary1.cel[0].cev[79].cevr";
connectAttr "animCurveTL567.a" "clipLibrary1.cel[0].cev[80].cevr";
connectAttr "animCurveTU568.a" "clipLibrary1.cel[0].cev[81].cevr";
connectAttr "animCurveTU569.a" "clipLibrary1.cel[0].cev[82].cevr";
connectAttr "animCurveTU570.a" "clipLibrary1.cel[0].cev[83].cevr";
connectAttr "animCurveTA568.a" "clipLibrary1.cel[0].cev[84].cevr";
connectAttr "animCurveTA569.a" "clipLibrary1.cel[0].cev[85].cevr";
connectAttr "animCurveTA570.a" "clipLibrary1.cel[0].cev[86].cevr";
connectAttr "animCurveTL568.a" "clipLibrary1.cel[0].cev[87].cevr";
connectAttr "animCurveTL569.a" "clipLibrary1.cel[0].cev[88].cevr";
connectAttr "animCurveTL570.a" "clipLibrary1.cel[0].cev[89].cevr";
connectAttr "animCurveTU571.a" "clipLibrary1.cel[0].cev[90].cevr";
connectAttr "animCurveTU572.a" "clipLibrary1.cel[0].cev[91].cevr";
connectAttr "animCurveTU573.a" "clipLibrary1.cel[0].cev[92].cevr";
connectAttr "animCurveTA571.a" "clipLibrary1.cel[0].cev[93].cevr";
connectAttr "animCurveTA572.a" "clipLibrary1.cel[0].cev[94].cevr";
connectAttr "animCurveTA573.a" "clipLibrary1.cel[0].cev[95].cevr";
connectAttr "animCurveTL571.a" "clipLibrary1.cel[0].cev[96].cevr";
connectAttr "animCurveTL572.a" "clipLibrary1.cel[0].cev[97].cevr";
connectAttr "animCurveTL573.a" "clipLibrary1.cel[0].cev[98].cevr";
connectAttr "animCurveTU574.a" "clipLibrary1.cel[0].cev[99].cevr";
connectAttr "animCurveTU575.a" "clipLibrary1.cel[0].cev[100].cevr";
connectAttr "animCurveTU576.a" "clipLibrary1.cel[0].cev[101].cevr";
connectAttr "animCurveTA574.a" "clipLibrary1.cel[0].cev[102].cevr";
connectAttr "animCurveTA575.a" "clipLibrary1.cel[0].cev[103].cevr";
connectAttr "animCurveTA576.a" "clipLibrary1.cel[0].cev[104].cevr";
connectAttr "animCurveTL574.a" "clipLibrary1.cel[0].cev[105].cevr";
connectAttr "animCurveTL575.a" "clipLibrary1.cel[0].cev[106].cevr";
connectAttr "animCurveTL576.a" "clipLibrary1.cel[0].cev[107].cevr";
connectAttr "animCurveTU577.a" "clipLibrary1.cel[0].cev[108].cevr";
connectAttr "animCurveTU578.a" "clipLibrary1.cel[0].cev[109].cevr";
connectAttr "animCurveTU579.a" "clipLibrary1.cel[0].cev[110].cevr";
connectAttr "animCurveTA577.a" "clipLibrary1.cel[0].cev[111].cevr";
connectAttr "animCurveTA578.a" "clipLibrary1.cel[0].cev[112].cevr";
connectAttr "animCurveTA579.a" "clipLibrary1.cel[0].cev[113].cevr";
connectAttr "animCurveTL577.a" "clipLibrary1.cel[0].cev[114].cevr";
connectAttr "animCurveTL578.a" "clipLibrary1.cel[0].cev[115].cevr";
connectAttr "animCurveTL579.a" "clipLibrary1.cel[0].cev[116].cevr";
connectAttr "animCurveTU580.a" "clipLibrary1.cel[0].cev[117].cevr";
connectAttr "animCurveTU581.a" "clipLibrary1.cel[0].cev[118].cevr";
connectAttr "animCurveTU582.a" "clipLibrary1.cel[0].cev[119].cevr";
connectAttr "animCurveTA580.a" "clipLibrary1.cel[0].cev[120].cevr";
connectAttr "animCurveTA581.a" "clipLibrary1.cel[0].cev[121].cevr";
connectAttr "animCurveTA582.a" "clipLibrary1.cel[0].cev[122].cevr";
connectAttr "animCurveTL580.a" "clipLibrary1.cel[0].cev[123].cevr";
connectAttr "animCurveTL581.a" "clipLibrary1.cel[0].cev[124].cevr";
connectAttr "animCurveTL582.a" "clipLibrary1.cel[0].cev[125].cevr";
connectAttr "animCurveTU583.a" "clipLibrary1.cel[0].cev[126].cevr";
connectAttr "animCurveTU584.a" "clipLibrary1.cel[0].cev[127].cevr";
connectAttr "animCurveTU585.a" "clipLibrary1.cel[0].cev[128].cevr";
connectAttr "animCurveTA583.a" "clipLibrary1.cel[0].cev[129].cevr";
connectAttr "animCurveTA584.a" "clipLibrary1.cel[0].cev[130].cevr";
connectAttr "animCurveTA585.a" "clipLibrary1.cel[0].cev[131].cevr";
connectAttr "animCurveTL583.a" "clipLibrary1.cel[0].cev[132].cevr";
connectAttr "animCurveTL584.a" "clipLibrary1.cel[0].cev[133].cevr";
connectAttr "animCurveTL585.a" "clipLibrary1.cel[0].cev[134].cevr";
connectAttr "animCurveTU586.a" "clipLibrary1.cel[0].cev[135].cevr";
connectAttr "animCurveTU587.a" "clipLibrary1.cel[0].cev[136].cevr";
connectAttr "animCurveTU588.a" "clipLibrary1.cel[0].cev[137].cevr";
connectAttr "animCurveTA586.a" "clipLibrary1.cel[0].cev[138].cevr";
connectAttr "animCurveTA587.a" "clipLibrary1.cel[0].cev[139].cevr";
connectAttr "animCurveTA588.a" "clipLibrary1.cel[0].cev[140].cevr";
connectAttr "animCurveTL586.a" "clipLibrary1.cel[0].cev[141].cevr";
connectAttr "animCurveTL587.a" "clipLibrary1.cel[0].cev[142].cevr";
connectAttr "animCurveTL588.a" "clipLibrary1.cel[0].cev[143].cevr";
connectAttr "animCurveTU589.a" "clipLibrary1.cel[0].cev[144].cevr";
connectAttr "animCurveTU590.a" "clipLibrary1.cel[0].cev[145].cevr";
connectAttr "animCurveTU591.a" "clipLibrary1.cel[0].cev[146].cevr";
connectAttr "animCurveTA589.a" "clipLibrary1.cel[0].cev[147].cevr";
connectAttr "animCurveTA590.a" "clipLibrary1.cel[0].cev[148].cevr";
connectAttr "animCurveTA591.a" "clipLibrary1.cel[0].cev[149].cevr";
connectAttr "animCurveTL589.a" "clipLibrary1.cel[0].cev[150].cevr";
connectAttr "animCurveTL590.a" "clipLibrary1.cel[0].cev[151].cevr";
connectAttr "animCurveTL591.a" "clipLibrary1.cel[0].cev[152].cevr";
connectAttr "animCurveTU592.a" "clipLibrary1.cel[0].cev[153].cevr";
connectAttr "animCurveTU593.a" "clipLibrary1.cel[0].cev[154].cevr";
connectAttr "animCurveTU594.a" "clipLibrary1.cel[0].cev[155].cevr";
connectAttr "animCurveTA592.a" "clipLibrary1.cel[0].cev[156].cevr";
connectAttr "animCurveTA593.a" "clipLibrary1.cel[0].cev[157].cevr";
connectAttr "animCurveTA594.a" "clipLibrary1.cel[0].cev[158].cevr";
connectAttr "animCurveTL592.a" "clipLibrary1.cel[0].cev[159].cevr";
connectAttr "animCurveTL593.a" "clipLibrary1.cel[0].cev[160].cevr";
connectAttr "animCurveTL594.a" "clipLibrary1.cel[0].cev[161].cevr";
connectAttr "animCurveTU595.a" "clipLibrary1.cel[0].cev[162].cevr";
connectAttr "animCurveTU596.a" "clipLibrary1.cel[0].cev[163].cevr";
connectAttr "animCurveTU597.a" "clipLibrary1.cel[0].cev[164].cevr";
connectAttr "animCurveTA595.a" "clipLibrary1.cel[0].cev[165].cevr";
connectAttr "animCurveTA596.a" "clipLibrary1.cel[0].cev[166].cevr";
connectAttr "animCurveTA597.a" "clipLibrary1.cel[0].cev[167].cevr";
connectAttr "animCurveTL595.a" "clipLibrary1.cel[0].cev[168].cevr";
connectAttr "animCurveTL596.a" "clipLibrary1.cel[0].cev[169].cevr";
connectAttr "animCurveTL597.a" "clipLibrary1.cel[0].cev[170].cevr";
connectAttr "animCurveTU598.a" "clipLibrary1.cel[0].cev[171].cevr";
connectAttr "animCurveTU599.a" "clipLibrary1.cel[0].cev[172].cevr";
connectAttr "animCurveTU600.a" "clipLibrary1.cel[0].cev[173].cevr";
connectAttr "animCurveTA598.a" "clipLibrary1.cel[0].cev[174].cevr";
connectAttr "animCurveTA599.a" "clipLibrary1.cel[0].cev[175].cevr";
connectAttr "animCurveTA600.a" "clipLibrary1.cel[0].cev[176].cevr";
connectAttr "animCurveTL598.a" "clipLibrary1.cel[0].cev[177].cevr";
connectAttr "animCurveTL599.a" "clipLibrary1.cel[0].cev[178].cevr";
connectAttr "animCurveTL600.a" "clipLibrary1.cel[0].cev[179].cevr";
connectAttr "animCurveTU601.a" "clipLibrary1.cel[0].cev[180].cevr";
connectAttr "animCurveTU602.a" "clipLibrary1.cel[0].cev[181].cevr";
connectAttr "animCurveTU603.a" "clipLibrary1.cel[0].cev[182].cevr";
connectAttr "animCurveTA601.a" "clipLibrary1.cel[0].cev[183].cevr";
connectAttr "animCurveTA602.a" "clipLibrary1.cel[0].cev[184].cevr";
connectAttr "animCurveTA603.a" "clipLibrary1.cel[0].cev[185].cevr";
connectAttr "animCurveTL601.a" "clipLibrary1.cel[0].cev[186].cevr";
connectAttr "animCurveTL602.a" "clipLibrary1.cel[0].cev[187].cevr";
connectAttr "animCurveTL603.a" "clipLibrary1.cel[0].cev[188].cevr";
connectAttr "animCurveTU604.a" "clipLibrary1.cel[0].cev[189].cevr";
connectAttr "animCurveTU605.a" "clipLibrary1.cel[0].cev[190].cevr";
connectAttr "animCurveTU606.a" "clipLibrary1.cel[0].cev[191].cevr";
connectAttr "animCurveTA604.a" "clipLibrary1.cel[0].cev[192].cevr";
connectAttr "animCurveTA605.a" "clipLibrary1.cel[0].cev[193].cevr";
connectAttr "animCurveTA606.a" "clipLibrary1.cel[0].cev[194].cevr";
connectAttr "animCurveTL604.a" "clipLibrary1.cel[0].cev[195].cevr";
connectAttr "animCurveTL605.a" "clipLibrary1.cel[0].cev[196].cevr";
connectAttr "animCurveTL606.a" "clipLibrary1.cel[0].cev[197].cevr";
connectAttr "animCurveTU607.a" "clipLibrary1.cel[0].cev[198].cevr";
connectAttr "animCurveTU608.a" "clipLibrary1.cel[0].cev[199].cevr";
connectAttr "animCurveTU609.a" "clipLibrary1.cel[0].cev[200].cevr";
connectAttr "animCurveTA607.a" "clipLibrary1.cel[0].cev[201].cevr";
connectAttr "animCurveTA608.a" "clipLibrary1.cel[0].cev[202].cevr";
connectAttr "animCurveTA609.a" "clipLibrary1.cel[0].cev[203].cevr";
connectAttr "animCurveTL607.a" "clipLibrary1.cel[0].cev[204].cevr";
connectAttr "animCurveTL608.a" "clipLibrary1.cel[0].cev[205].cevr";
connectAttr "animCurveTL609.a" "clipLibrary1.cel[0].cev[206].cevr";
connectAttr "animCurveTU610.a" "clipLibrary1.cel[0].cev[207].cevr";
connectAttr "animCurveTU611.a" "clipLibrary1.cel[0].cev[208].cevr";
connectAttr "animCurveTU612.a" "clipLibrary1.cel[0].cev[209].cevr";
connectAttr "animCurveTA610.a" "clipLibrary1.cel[0].cev[210].cevr";
connectAttr "animCurveTA611.a" "clipLibrary1.cel[0].cev[211].cevr";
connectAttr "animCurveTA612.a" "clipLibrary1.cel[0].cev[212].cevr";
connectAttr "animCurveTL610.a" "clipLibrary1.cel[0].cev[213].cevr";
connectAttr "animCurveTL611.a" "clipLibrary1.cel[0].cev[214].cevr";
connectAttr "animCurveTL612.a" "clipLibrary1.cel[0].cev[215].cevr";
connectAttr "animCurveTU613.a" "clipLibrary1.cel[0].cev[216].cevr";
connectAttr "animCurveTU614.a" "clipLibrary1.cel[0].cev[217].cevr";
connectAttr "animCurveTU615.a" "clipLibrary1.cel[0].cev[218].cevr";
connectAttr "animCurveTA613.a" "clipLibrary1.cel[0].cev[219].cevr";
connectAttr "animCurveTA614.a" "clipLibrary1.cel[0].cev[220].cevr";
connectAttr "animCurveTA615.a" "clipLibrary1.cel[0].cev[221].cevr";
connectAttr "animCurveTL613.a" "clipLibrary1.cel[0].cev[222].cevr";
connectAttr "animCurveTL614.a" "clipLibrary1.cel[0].cev[223].cevr";
connectAttr "animCurveTL615.a" "clipLibrary1.cel[0].cev[224].cevr";
connectAttr "animCurveTU616.a" "clipLibrary1.cel[0].cev[225].cevr";
connectAttr "animCurveTU617.a" "clipLibrary1.cel[0].cev[226].cevr";
connectAttr "animCurveTU618.a" "clipLibrary1.cel[0].cev[227].cevr";
connectAttr "animCurveTA616.a" "clipLibrary1.cel[0].cev[228].cevr";
connectAttr "animCurveTA617.a" "clipLibrary1.cel[0].cev[229].cevr";
connectAttr "animCurveTA618.a" "clipLibrary1.cel[0].cev[230].cevr";
connectAttr "animCurveTL616.a" "clipLibrary1.cel[0].cev[231].cevr";
connectAttr "animCurveTL617.a" "clipLibrary1.cel[0].cev[232].cevr";
connectAttr "animCurveTL618.a" "clipLibrary1.cel[0].cev[233].cevr";
connectAttr "animCurveTU619.a" "clipLibrary1.cel[0].cev[234].cevr";
connectAttr "animCurveTU620.a" "clipLibrary1.cel[0].cev[235].cevr";
connectAttr "animCurveTU621.a" "clipLibrary1.cel[0].cev[236].cevr";
connectAttr "animCurveTA619.a" "clipLibrary1.cel[0].cev[237].cevr";
connectAttr "animCurveTA620.a" "clipLibrary1.cel[0].cev[238].cevr";
connectAttr "animCurveTA621.a" "clipLibrary1.cel[0].cev[239].cevr";
connectAttr "animCurveTL619.a" "clipLibrary1.cel[0].cev[240].cevr";
connectAttr "animCurveTL620.a" "clipLibrary1.cel[0].cev[241].cevr";
connectAttr "animCurveTL621.a" "clipLibrary1.cel[0].cev[242].cevr";
connectAttr "animCurveTU622.a" "clipLibrary1.cel[0].cev[243].cevr";
connectAttr "animCurveTU623.a" "clipLibrary1.cel[0].cev[244].cevr";
connectAttr "animCurveTU624.a" "clipLibrary1.cel[0].cev[245].cevr";
connectAttr "animCurveTA622.a" "clipLibrary1.cel[0].cev[246].cevr";
connectAttr "animCurveTA623.a" "clipLibrary1.cel[0].cev[247].cevr";
connectAttr "animCurveTA624.a" "clipLibrary1.cel[0].cev[248].cevr";
connectAttr "animCurveTL622.a" "clipLibrary1.cel[0].cev[249].cevr";
connectAttr "animCurveTL623.a" "clipLibrary1.cel[0].cev[250].cevr";
connectAttr "animCurveTL624.a" "clipLibrary1.cel[0].cev[251].cevr";
connectAttr "animCurveTU625.a" "clipLibrary1.cel[0].cev[252].cevr";
connectAttr "animCurveTU626.a" "clipLibrary1.cel[0].cev[253].cevr";
connectAttr "animCurveTU627.a" "clipLibrary1.cel[0].cev[254].cevr";
connectAttr "animCurveTA625.a" "clipLibrary1.cel[0].cev[255].cevr";
connectAttr "animCurveTA626.a" "clipLibrary1.cel[0].cev[256].cevr";
connectAttr "animCurveTA627.a" "clipLibrary1.cel[0].cev[257].cevr";
connectAttr "animCurveTL625.a" "clipLibrary1.cel[0].cev[258].cevr";
connectAttr "animCurveTL626.a" "clipLibrary1.cel[0].cev[259].cevr";
connectAttr "animCurveTL627.a" "clipLibrary1.cel[0].cev[260].cevr";
connectAttr "animCurveTU628.a" "clipLibrary1.cel[0].cev[261].cevr";
connectAttr "animCurveTU629.a" "clipLibrary1.cel[0].cev[262].cevr";
connectAttr "animCurveTU630.a" "clipLibrary1.cel[0].cev[263].cevr";
connectAttr "animCurveTA628.a" "clipLibrary1.cel[0].cev[264].cevr";
connectAttr "animCurveTA629.a" "clipLibrary1.cel[0].cev[265].cevr";
connectAttr "animCurveTA630.a" "clipLibrary1.cel[0].cev[266].cevr";
connectAttr "animCurveTL628.a" "clipLibrary1.cel[0].cev[267].cevr";
connectAttr "animCurveTL629.a" "clipLibrary1.cel[0].cev[268].cevr";
connectAttr "animCurveTL630.a" "clipLibrary1.cel[0].cev[269].cevr";
// End of bat_block.ma
