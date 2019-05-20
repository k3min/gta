using RenderWare.SCM.Types;

namespace RenderWare.SCM
{
	public class VirtualMachine
	{
		public static readonly OpCodes OpCodes = new OpCodes
		{
			/* 0	 */ {true, "NOP"},
			/* 1	 */ {true, "WAIT", new[] {Arg.ANY_INT}},
			/* 2	 */ {true, "GOTO", new[] {Arg.LABEL}},
			/* 3	 */ {true, "SHAKE_CAM", new[] {Arg.ANY_INT}},
			/* 4	 */ {true, "SET_VAR_INT", new[] {Arg.VAR_INT, Arg.INT}},
			/* 5	 */ {true, "SET_VAR_FLOAT", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 6	 */ {true, "SET_LVAR_INT", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 7	 */ {true, "SET_LVAR_FLOAT", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 8	 */ {true, "ADD_VAL_TO_INT_VAR", new[] {Arg.VAR_INT, Arg.INT}},
			/* 9	 */ {true, "ADD_VAL_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 10	 */ {true, "ADD_VAL_TO_INT_LVAR", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 11	 */ {true, "ADD_VAL_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 12	 */ {true, "SUB_VAL_FROM_INT_VAR", new[] {Arg.VAR_INT, Arg.INT}},
			/* 13	 */ {true, "SUB_VAL_FROM_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 14	 */ {true, "SUB_VAL_FROM_INT_LVAR", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 15	 */ {true, "SUB_VAL_FROM_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 16	 */ {true, "MULT_INT_VAR_BY_VAL", new[] {Arg.VAR_INT, Arg.INT}},
			/* 17	 */ {true, "MULT_FLOAT_VAR_BY_VAL", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 18	 */ {true, "MULT_INT_LVAR_BY_VAL", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 19	 */ {true, "MULT_FLOAT_LVAR_BY_VAL", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 20	 */ {true, "DIV_INT_VAR_BY_VAL", new[] {Arg.VAR_INT, Arg.INT}},
			/* 21	 */ {true, "DIV_FLOAT_VAR_BY_VAL", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 22	 */ {true, "DIV_INT_LVAR_BY_VAL", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 23	 */ {true, "DIV_FLOAT_LVAR_BY_VAL", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 24	 */ {true, "IS_INT_VAR_GREATER_THAN_NUMBER", new[] {Arg.VAR_INT, Arg.INT}},
			/* 25	 */ {true, "IS_INT_LVAR_GREATER_THAN_NUMBER", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 26	 */ {true, "IS_NUMBER_GREATER_THAN_INT_VAR", new[] {Arg.INT, Arg.VAR_INT}},
			/* 27	 */ {true, "IS_NUMBER_GREATER_THAN_INT_LVAR", new[] {Arg.INT, Arg.LVAR_INT}},
			/* 28	 */ {true, "IS_INT_VAR_GREATER_THAN_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 29	 */ {true, "IS_INT_LVAR_GREATER_THAN_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 30	 */ {true, "IS_INT_VAR_GREATER_THAN_INT_LVAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 31	 */ {true, "IS_INT_LVAR_GREATER_THAN_INT_VAR", new[] {Arg.LVAR_INT, Arg.VAR_INT}},
			/* 32	 */ {true, "IS_FLOAT_VAR_GREATER_THAN_NUMBER", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 33	 */ {true, "IS_FLOAT_LVAR_GREATER_THAN_NUMBER", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 34	 */ {true, "IS_NUMBER_GREATER_THAN_FLOAT_VAR", new[] {Arg.FLOAT, Arg.VAR_FLOAT}},
			/* 35	 */ {true, "IS_NUMBER_GREATER_THAN_FLOAT_LVAR", new[] {Arg.FLOAT, Arg.LVAR_FLOAT}},
			/* 36	 */ {true, "IS_FLOAT_VAR_GREATER_THAN_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 37	 */ {true, "IS_FLOAT_LVAR_GREATER_THAN_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 38	 */ {true, "IS_FLOAT_VAR_GREATER_THAN_FLOAT_LVAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 39	 */ {true, "IS_FLOAT_LVAR_GREATER_THAN_FLOAT_VAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 40	 */ {true, "IS_INT_VAR_GREATER_OR_EQUAL_TO_NUMBER", new[] {Arg.VAR_INT, Arg.INT}},
			/* 41	 */ {true, "IS_INT_LVAR_GREATER_OR_EQUAL_TO_NUMBER", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 42	 */ {true, "IS_NUMBER_GREATER_OR_EQUAL_TO_INT_VAR", new[] {Arg.INT, Arg.VAR_INT}},
			/* 43	 */ {true, "IS_NUMBER_GREATER_OR_EQUAL_TO_INT_LVAR", new[] {Arg.INT, Arg.LVAR_INT}},
			/* 44	 */ {true, "IS_INT_VAR_GREATER_OR_EQUAL_TO_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 45	 */ {true, "IS_INT_LVAR_GREATER_OR_EQUAL_TO_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 46	 */ {true, "IS_INT_VAR_GREATER_OR_EQUAL_TO_INT_LVAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 47	 */ {true, "IS_INT_LVAR_GREATER_OR_EQUAL_TO_INT_VAR", new[] {Arg.LVAR_INT, Arg.VAR_INT}},
			/* 48	 */ {true, "IS_FLOAT_VAR_GREATER_OR_EQUAL_TO_NUMBER", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 49	 */ {true, "IS_FLOAT_LVAR_GREATER_OR_EQUAL_TO_NUMBER", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 50	 */ {true, "IS_NUMBER_GREATER_OR_EQUAL_TO_FLOAT_VAR", new[] {Arg.FLOAT, Arg.VAR_FLOAT}},
			/* 51	 */ {true, "IS_NUMBER_GREATER_OR_EQUAL_TO_FLOAT_LVAR", new[] {Arg.FLOAT, Arg.LVAR_FLOAT}},
			/* 52	 */ {true, "IS_FLOAT_VAR_GREATER_OR_EQUAL_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 53	 */ {true, "IS_FLOAT_LVAR_GREATER_OR_EQUAL_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 54	 */ {true, "IS_FLOAT_VAR_GREATER_OR_EQUAL_TO_FLOAT_LVAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 55	 */ {true, "IS_FLOAT_LVAR_GREATER_OR_EQUAL_TO_FLOAT_VAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 56	 */ {true, "IS_INT_VAR_EQUAL_TO_NUMBER", new[] {Arg.VAR_INT, Arg.INT}},
			/* 57	 */ {true, "IS_INT_LVAR_EQUAL_TO_NUMBER", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 58	 */ {true, "IS_INT_VAR_EQUAL_TO_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 59	 */ {true, "IS_INT_LVAR_EQUAL_TO_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 60	 */ {true, "IS_INT_VAR_EQUAL_TO_INT_LVAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 61	 */ {true, "IS_INT_VAR_NOT_EQUAL_TO_NUMBER", new[] {Arg.VAR_INT, Arg.INT}},
			/* 62	 */ {true, "IS_INT_LVAR_NOT_EQUAL_TO_NUMBER", new[] {Arg.LVAR_INT, Arg.INT}},
			/* 63	 */ {true, "IS_INT_VAR_NOT_EQUAL_TO_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 64	 */ {true, "IS_INT_LVAR_NOT_EQUAL_TO_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 65	 */ {true, "IS_INT_VAR_NOT_EQUAL_TO_INT_LVAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 66	 */ {true, "IS_FLOAT_VAR_EQUAL_TO_NUMBER", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 67	 */ {true, "IS_FLOAT_LVAR_EQUAL_TO_NUMBER", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 68	 */ {true, "IS_FLOAT_VAR_EQUAL_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 69	 */ {true, "IS_FLOAT_LVAR_EQUAL_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 70	 */ {true, "IS_FLOAT_VAR_EQUAL_TO_FLOAT_LVAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 71	 */ {true, "IS_FLOAT_VAR_NOT_EQUAL_TO_NUMBER", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 72	 */ {true, "IS_FLOAT_LVAR_NOT_EQUAL_TO_NUMBER", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 73	 */ {true, "IS_FLOAT_VAR_NOT_EQUAL_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 74	 */ {true, "IS_FLOAT_LVAR_NOT_EQUAL_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 75	 */ {true, "IS_FLOAT_VAR_NOT_EQUAL_TO_FLOAT_LVAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 76	 */ {false, "GOTO_IF_TRUE", new[] {Arg.LABEL}},
			/* 77	 */ {true, "GOTO_IF_FALSE", new[] {Arg.LABEL}},
			/* 78	 */ {true, "TERMINATE_THIS_SCRIPT"},
			/* 79	 */
			{
				true, "START_NEW_SCRIPT",
				new[]
				{
					Arg.LABEL, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT,
					Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT,
					Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT, Arg.MULTI_OPT
				}
			},
			/* 80	 */ {true, "GOSUB", new[] {Arg.LABEL}},
			/* 81	 */ {true, "RETURN"},
			/* 82	 */
			{
				true, "LINE",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 83	 */
			{true, "CREATE_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 84	 */
			{
				true, "GET_PLAYER_COORDINATES",
				new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}
			},
			/* 85	 */
			{true, "SET_PLAYER_COORDINATES", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 86	 */
			{
				true, "IS_PLAYER_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 87	 */
			{
				true, "IS_PLAYER_IN_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 88	 */ {true, "ADD_INT_VAR_TO_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 89	 */ {true, "ADD_FLOAT_VAR_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 90	 */ {true, "ADD_INT_LVAR_TO_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 91	 */ {true, "ADD_FLOAT_LVAR_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 92	 */ {true, "ADD_INT_VAR_TO_INT_LVAR", new[] {Arg.LVAR_INT, Arg.VAR_INT}},
			/* 93	 */ {true, "ADD_FLOAT_VAR_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 94	 */ {true, "ADD_INT_LVAR_TO_INT_VAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 95	 */ {true, "ADD_FLOAT_LVAR_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 96	 */ {true, "SUB_INT_VAR_FROM_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 97	 */ {true, "SUB_FLOAT_VAR_FROM_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 98	 */ {true, "SUB_INT_LVAR_FROM_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 99	 */ {true, "SUB_FLOAT_LVAR_FROM_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 100	 */ {true, "SUB_INT_VAR_FROM_INT_LVAR", new[] {Arg.LVAR_INT, Arg.VAR_INT}},
			/* 101	 */ {true, "SUB_FLOAT_VAR_FROM_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 102	 */ {true, "SUB_INT_LVAR_FROM_INT_VAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 103	 */ {true, "SUB_FLOAT_LVAR_FROM_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 104	 */ {true, "MULT_INT_VAR_BY_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 105	 */ {true, "MULT_FLOAT_VAR_BY_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 106	 */ {true, "MULT_INT_LVAR_BY_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 107	 */ {true, "MULT_FLOAT_LVAR_BY_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 108	 */ {true, "MULT_INT_VAR_BY_INT_LVAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 109	 */ {true, "MULT_FLOAT_VAR_BY_FLOAT_LVAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 110	 */ {true, "MULT_INT_LVAR_BY_INT_VAR", new[] {Arg.LVAR_INT, Arg.VAR_INT}},
			/* 111	 */ {true, "MULT_FLOAT_LVAR_BY_FLOAT_VAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 112	 */ {true, "DIV_INT_VAR_BY_INT_VAR", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 113	 */ {true, "DIV_FLOAT_VAR_BY_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 114	 */ {true, "DIV_INT_LVAR_BY_INT_LVAR", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 115	 */ {true, "DIV_FLOAT_LVAR_BY_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 116	 */ {true, "DIV_INT_VAR_BY_INT_LVAR", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 117	 */ {true, "DIV_FLOAT_VAR_BY_FLOAT_LVAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 118	 */ {true, "DIV_INT_LVAR_BY_INT_VAR", new[] {Arg.LVAR_INT, Arg.VAR_INT}},
			/* 119	 */ {true, "DIV_FLOAT_LVAR_BY_FLOAT_VAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 120	 */ {true, "ADD_TIMED_VAL_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 121	 */ {true, "ADD_TIMED_VAL_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 122	 */ {true, "ADD_TIMED_FLOAT_VAR_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 123	 */ {true, "ADD_TIMED_FLOAT_LVAR_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 124	 */ {true, "ADD_TIMED_FLOAT_LVAR_TO_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 125	 */ {true, "ADD_TIMED_FLOAT_VAR_TO_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 126	 */ {true, "SUB_TIMED_VAL_FROM_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.FLOAT}},
			/* 127	 */ {true, "SUB_TIMED_VAL_FROM_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.FLOAT}},
			/* 128	 */ {true, "SUB_TIMED_FLOAT_VAR_FROM_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 129	 */ {true, "SUB_TIMED_FLOAT_LVAR_FROM_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 130	 */ {true, "SUB_TIMED_FLOAT_LVAR_FROM_FLOAT_VAR", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 131	 */ {true, "SUB_TIMED_FLOAT_VAR_FROM_FLOAT_LVAR", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 132	 */ {true, "SET_VAR_INT_TO_VAR_INT", new[] {Arg.VAR_INT, Arg.VAR_INT}},
			/* 133	 */ {true, "SET_LVAR_INT_TO_LVAR_INT", new[] {Arg.LVAR_INT, Arg.LVAR_INT}},
			/* 134	 */ {true, "SET_VAR_FLOAT_TO_VAR_FLOAT", new[] {Arg.VAR_FLOAT, Arg.VAR_FLOAT}},
			/* 135	 */ {true, "SET_LVAR_FLOAT_TO_LVAR_FLOAT", new[] {Arg.LVAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 136	 */ {true, "SET_VAR_FLOAT_TO_LVAR_FLOAT", new[] {Arg.VAR_FLOAT, Arg.LVAR_FLOAT}},
			/* 137	 */ {true, "SET_LVAR_FLOAT_TO_VAR_FLOAT", new[] {Arg.LVAR_FLOAT, Arg.VAR_FLOAT}},
			/* 138	 */ {true, "SET_VAR_INT_TO_LVAR_INT", new[] {Arg.VAR_INT, Arg.LVAR_INT}},
			/* 139	 */ {true, "SET_LVAR_INT_TO_VAR_INT", new[] {Arg.LVAR_INT, Arg.VAR_INT}},
			/* 140	 */ {true, "CSET_VAR_INT_TO_VAR_FLOAT", new[] {Arg.VAR_INT, Arg.VAR_FLOAT}},
			/* 141	 */ {true, "CSET_VAR_FLOAT_TO_VAR_INT", new[] {Arg.VAR_FLOAT, Arg.VAR_INT}},
			/* 142	 */ {true, "CSET_LVAR_INT_TO_VAR_FLOAT", new[] {Arg.LVAR_INT, Arg.VAR_FLOAT}},
			/* 143	 */ {true, "CSET_LVAR_FLOAT_TO_VAR_INT", new[] {Arg.LVAR_FLOAT, Arg.VAR_INT}},
			/* 144	 */ {true, "CSET_VAR_INT_TO_LVAR_FLOAT", new[] {Arg.VAR_INT, Arg.LVAR_FLOAT}},
			/* 145	 */ {true, "CSET_VAR_FLOAT_TO_LVAR_INT", new[] {Arg.VAR_FLOAT, Arg.LVAR_INT}},
			/* 146	 */ {true, "CSET_LVAR_INT_TO_LVAR_FLOAT", new[] {Arg.LVAR_INT, Arg.LVAR_FLOAT}},
			/* 147	 */ {true, "CSET_LVAR_FLOAT_TO_LVAR_INT", new[] {Arg.LVAR_FLOAT, Arg.LVAR_INT}},
			/* 148	 */ {true, "ABS_VAR_INT", new[] {Arg.VAR_INT}},
			/* 149	 */ {true, "ABS_LVAR_INT", new[] {Arg.LVAR_INT}},
			/* 150	 */ {true, "ABS_VAR_FLOAT", new[] {Arg.VAR_FLOAT}},
			/* 151	 */ {true, "ABS_LVAR_FLOAT", new[] {Arg.LVAR_FLOAT}},
			/* 152	 */ {true, "GENERATE_RANDOM_FLOAT", new[] {Arg.VAR_FLOAT}},
			/* 153	 */ {true, "GENERATE_RANDOM_INT", new[] {Arg.VAR_INT}},
			/* 154	 */
			{
				true, "CREATE_CHAR",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}
			},
			/* 155	 */ {true, "DELETE_CHAR", new[] {Arg.ANY_INT}},
			/* 156	 */ {true, "CHAR_WANDER_DIR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 157	 */ {false, "CHAR_WANDER_RANGE", new[] {Arg.ANY_INT}},
			/* 158	 */
			{
				true, "CHAR_FOLLOW_PATH",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 159	 */ {true, "CHAR_SET_IDLE", new[] {Arg.ANY_INT}},
			/* 160	 */
			{
				true, "GET_CHAR_COORDINATES",
				new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}
			},
			/* 161	 */ {true, "SET_CHAR_COORDINATES", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 162	 */ {false, "IS_CHAR_STILL_ALIVE", new[] {Arg.ANY_INT}},
			/* 163	 */
			{
				true, "IS_CHAR_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 164	 */
			{
				true, "IS_CHAR_IN_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 165	 */
			{true, "CREATE_CAR", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 166	 */ {true, "DELETE_CAR", new[] {Arg.ANY_INT}},
			/* 167	 */ {true, "CAR_GOTO_COORDINATES", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 168	 */ {true, "CAR_WANDER_RANDOMLY", new[] {Arg.ANY_INT}},
			/* 169	 */ {true, "CAR_SET_IDLE", new[] {Arg.ANY_INT}},
			/* 170	 */
			{
				true, "GET_CAR_COORDINATES",
				new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}
			},
			/* 171	 */ {true, "SET_CAR_COORDINATES", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 172	 */ {false, "IS_CAR_STILL_ALIVE", new[] {Arg.ANY_INT}},
			/* 173	 */ {true, "SET_CAR_CRUISE_SPEED", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 174	 */ {true, "SET_CAR_DRIVING_STYLE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 175	 */ {true, "SET_CAR_MISSION", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 176	 */
			{
				true, "IS_CAR_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 177	 */
			{
				true, "IS_CAR_IN_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 178	 */ {false, "SPECIAL_0"},
			/* 179	 */ {false, "SPECIAL_1"},
			/* 180	 */ {false, "SPECIAL_2"},
			/* 181	 */ {false, "SPECIAL_3"},
			/* 182	 */ {false, "SPECIAL_4"},
			/* 183	 */ {false, "SPECIAL_5"},
			/* 184	 */ {false, "SPECIAL_6"},
			/* 185	 */ {false, "SPECIAL_7"},
			/* 186	 */ {true, "PRINT_BIG", new[] {Arg.TEXT_LABEL, Arg.INT, Arg.INT}},
			/* 187	 */ {true, "PRINT", new[] {Arg.TEXT_LABEL, Arg.INT, Arg.INT}},
			/* 188	 */ {true, "PRINT_NOW", new[] {Arg.TEXT_LABEL, Arg.INT, Arg.INT}},
			/* 189	 */ {false, "PRINT_SOON", new[] {Arg.TEXT_LABEL, Arg.INT, Arg.INT}},
			/* 190	 */ {true, "CLEAR_PRINTS"},
			/* 191	 */ {true, "GET_TIME_OF_DAY", new[] {Arg.VAR_LVAR_INT, Arg.VAR_LVAR_INT}},
			/* 192	 */ {true, "SET_TIME_OF_DAY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 193	 */ {true, "GET_MINUTES_TO_TIME_OF_DAY", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 194	 */ {true, "IS_POINT_ON_SCREEN", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 195	 */ {true, "DEBUG_ON"},
			/* 196	 */ {true, "DEBUG_OFF"},
			/* 197	 */ {false, "RETURN_TRUE"},
			/* 198	 */ {false, "RETURN_FALSE"},
			/* 199	 */
			{
				true, "VAR_INT",
				new[]
				{
					Arg.VAR_INT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT,
					Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT,
					Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT,
					Arg.VAR_INT_OPT, Arg.VAR_INT_OPT
				}
			},
			/* 200	 */
			{
				true, "VAR_FLOAT",
				new[]
				{
					Arg.VAR_FLOAT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT,
					Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT,
					Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT,
					Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT
				}
			},
			/* 201	 */
			{
				true, "LVAR_INT",
				new[]
				{
					Arg.LVAR_INT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT,
					Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT,
					Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT,
					Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT, Arg.LVAR_INT_OPT
				}
			},
			/* 202	 */
			{
				true, "LVAR_FLOAT",
				new[]
				{
					Arg.LVAR_FLOAT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT,
					Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT,
					Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT,
					Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT, Arg.LVAR_FLOAT_OPT
				}
			},
			/* 203	 */ {true, "{"},
			/* 204	 */ {true, "}"},
			/* 205	 */ {true, "REPEAT", new[] {Arg.INT, Arg.VAR_INT}},
			/* 206	 */ {true, "ENDREPEAT"},
			/* 207	 */ {true, "IF", new[] {Arg.INT}},
			/* 208	 */ {true, "IFNOT", new[] {Arg.INT}},
			/* 209	 */ {true, "ELSE"},
			/* 210	 */ {true, "ENDIF"},
			/* 211	 */ {true, "WHILE", new[] {Arg.INT}},
			/* 212	 */ {true, "WHILENOT", new[] {Arg.INT}},
			/* 213	 */ {true, "ENDWHILE"},
			/* 214	 */ {true, "ANDOR", new[] {Arg.INT}},
			/* 215	 */ {true, "LAUNCH_MISSION", new[] {Arg.LABEL}},
			/* 216	 */ {true, "MISSION_HAS_FINISHED"},
			/* 217	 */ {true, "STORE_CAR_CHAR_IS_IN", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 218	 */ {true, "STORE_CAR_PLAYER_IS_IN", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 219	 */ {true, "IS_CHAR_IN_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 220	 */ {true, "IS_PLAYER_IN_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 221	 */ {true, "IS_CHAR_IN_MODEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 222	 */ {true, "IS_PLAYER_IN_MODEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 223	 */ {true, "IS_CHAR_IN_ANY_CAR", new[] {Arg.ANY_INT}},
			/* 224	 */ {true, "IS_PLAYER_IN_ANY_CAR", new[] {Arg.ANY_INT}},
			/* 225	 */ {true, "IS_BUTTON_PRESSED", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 226	 */ {true, "GET_PAD_STATE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 227	 */
			{
				true, "LOCATE_PLAYER_ANY_MEANS_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 228	 */
			{
				true, "LOCATE_PLAYER_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 229	 */
			{
				true, "LOCATE_PLAYER_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 230	 */
			{
				true, "LOCATE_STOPPED_PLAYER_ANY_MEANS_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 231	 */
			{
				true, "LOCATE_STOPPED_PLAYER_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 232	 */
			{
				true, "LOCATE_STOPPED_PLAYER_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 233	 */
			{
				true, "LOCATE_PLAYER_ANY_MEANS_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 234	 */
			{
				true, "LOCATE_PLAYER_ON_FOOT_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 235	 */
			{
				true, "LOCATE_PLAYER_IN_CAR_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 236	 */
			{
				true, "LOCATE_CHAR_ANY_MEANS_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 237	 */
			{
				true, "LOCATE_CHAR_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 238	 */
			{
				true, "LOCATE_CHAR_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 239	 */
			{
				true, "LOCATE_STOPPED_CHAR_ANY_MEANS_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 240	 */
			{
				true, "LOCATE_STOPPED_CHAR_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 241	 */
			{
				true, "LOCATE_STOPPED_CHAR_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 242	 */
			{
				true, "LOCATE_CHAR_ANY_MEANS_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 243	 */
			{
				true, "LOCATE_CHAR_ON_FOOT_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 244	 */
			{
				true, "LOCATE_CHAR_IN_CAR_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 245	 */
			{
				true, "LOCATE_PLAYER_ANY_MEANS_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 246	 */
			{
				true, "LOCATE_PLAYER_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 247	 */
			{
				true, "LOCATE_PLAYER_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 248	 */
			{
				true, "LOCATE_STOPPED_PLAYER_ANY_MEANS_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 249	 */
			{
				true, "LOCATE_STOPPED_PLAYER_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 250	 */
			{
				true, "LOCATE_STOPPED_PLAYER_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 251	 */
			{
				true, "LOCATE_PLAYER_ANY_MEANS_CHAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 252	 */
			{
				true, "LOCATE_PLAYER_ON_FOOT_CHAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 253	 */
			{
				true, "LOCATE_PLAYER_IN_CAR_CHAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 254	 */
			{
				true, "LOCATE_CHAR_ANY_MEANS_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 255	 */
			{
				true, "LOCATE_CHAR_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 256	 */
			{
				true, "LOCATE_CHAR_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 257	 */
			{
				true, "LOCATE_STOPPED_CHAR_ANY_MEANS_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 258	 */
			{
				true, "LOCATE_STOPPED_CHAR_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 259	 */
			{
				true, "LOCATE_STOPPED_CHAR_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 260	 */
			{
				true, "LOCATE_CHAR_ANY_MEANS_CHAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 261	 */
			{
				true, "LOCATE_CHAR_ON_FOOT_CHAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 262	 */
			{
				true, "LOCATE_CHAR_IN_CAR_CHAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 263	 */
			{true, "CREATE_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 264	 */ {true, "DELETE_OBJECT", new[] {Arg.ANY_INT}},
			/* 265	 */ {true, "ADD_SCORE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 266	 */ {true, "IS_SCORE_GREATER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 267	 */ {true, "STORE_SCORE", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 268	 */
			{
				true, "GIVE_REMOTE_CONTROLLED_CAR_TO_PLAYER",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 269	 */ {true, "ALTER_WANTED_LEVEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 270	 */ {true, "ALTER_WANTED_LEVEL_NO_DROP", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 271	 */ {true, "IS_WANTED_LEVEL_GREATER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 272	 */ {true, "CLEAR_WANTED_LEVEL", new[] {Arg.ANY_INT}},
			/* 273	 */ {true, "SET_DEATHARREST_STATE", new[] {Arg.ANY_INT}},
			/* 274	 */ {true, "HAS_DEATHARREST_BEEN_EXECUTED"},
			/* 275	 */ {false, "ADD_AMMO_TO_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 276	 */ {true, "ADD_AMMO_TO_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 277	 */ {false, "ADD_AMMO_TO_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 278	 */ {false, "IS_PLAYER_STILL_ALIVE", new[] {Arg.ANY_INT}},
			/* 279	 */ {true, "IS_PLAYER_DEAD", new[] {Arg.ANY_INT}},
			/* 280	 */ {true, "IS_CHAR_DEAD", new[] {Arg.ANY_INT}},
			/* 281	 */ {true, "IS_CAR_DEAD", new[] {Arg.ANY_INT}},
			/* 282	 */ {true, "SET_CHAR_THREAT_SEARCH", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 283	 */ {false, "SET_CHAR_THREAT_REACTION", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 284	 */ {true, "SET_CHAR_OBJ_NO_OBJ", new[] {Arg.ANY_INT}},
			/* 285	 */ {false, "ORDER_DRIVER_OUT_OF_CAR", new[] {Arg.ANY_INT}},
			/* 286	 */ {false, "ORDER_CHAR_TO_DRIVE_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 287	 */ {false, "ADD_PATROL_POINT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 288	 */ {false, "IS_PLAYER_IN_GANGZONE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 289	 */ {true, "IS_PLAYER_IN_ZONE", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 290	 */ {true, "IS_PLAYER_PRESSING_HORN", new[] {Arg.ANY_INT}},
			/* 291	 */ {true, "HAS_CHAR_SPOTTED_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 292	 */ {false, "ORDER_CHAR_TO_BACKDOOR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 293	 */ {false, "ADD_CHAR_TO_GANG", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 294	 */ {true, "IS_CHAR_OBJECTIVE_PASSED", new[] {Arg.ANY_INT}},
			/* 295	 */ {false, "SET_CHAR_DRIVE_AGGRESSION", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 296	 */ {false, "SET_CHAR_MAX_DRIVESPEED", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 297	 */
			{true, "CREATE_CHAR_INSIDE_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 298	 */
			{true, "WARP_PLAYER_FROM_CAR_TO_COORD", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 299	 */ {false, "MAKE_CHAR_DO_NOTHING", new[] {Arg.ANY_INT}},
			/* 300	 */ {false, "SET_CHAR_INVINCIBLE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 301	 */ {false, "SET_PLAYER_INVINCIBLE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 302	 */ {false, "SET_CHAR_GRAPHIC_TYPE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 303	 */ {false, "SET_PLAYER_GRAPHIC_TYPE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 304	 */ {false, "HAS_PLAYER_BEEN_ARRESTED", new[] {Arg.ANY_INT}},
			/* 305	 */ {false, "STOP_CHAR_DRIVING", new[] {Arg.ANY_INT}},
			/* 306	 */ {false, "KILL_CHAR", new[] {Arg.ANY_INT}},
			/* 307	 */ {false, "SET_FAVOURITE_CAR_MODEL_FOR_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 308	 */ {false, "SET_CHAR_OCCUPATION", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 309	 */ {false, "CHANGE_CAR_LOCK", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 310	 */
			{false, "SHAKE_CAM_WITH_POINT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 311	 */ {true, "IS_CAR_MODEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 312	 */ {false, "IS_CAR_REMAP", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 313	 */ {false, "HAS_CAR_JUST_SUNK", new[] {Arg.ANY_INT}},
			/* 314	 */ {false, "SET_CAR_NO_COLLIDE", new[] {Arg.ANY_INT}},
			/* 315	 */
			{
				false, "IS_CAR_DEAD_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 316	 */
			{
				false, "IS_CAR_DEAD_IN_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 317	 */ {false, "IS_TRAILER_ATTACHED", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 318	 */ {false, "IS_CAR_ON_TRAILER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 319	 */ {false, "HAS_CAR_GOT_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 320	 */ {false, "PARK", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 321	 */ {false, "HAS_PARK_FINISHED"},
			/* 322	 */ {false, "KILL_ALL_PASSENGERS", new[] {Arg.ANY_INT}},
			/* 323	 */ {false, "SET_CAR_BULLETPROOF", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 324	 */ {false, "SET_CAR_FLAMEPROOF", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 325	 */ {false, "SET_CAR_ROCKETPROOF", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 326	 */ {false, "IS_CARBOMB_ACTIVE", new[] {Arg.ANY_INT}},
			/* 327	 */ {false, "GIVE_CAR_ALARM", new[] {Arg.ANY_INT}},
			/* 328	 */ {false, "PUT_CAR_ON_TRAILER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 329	 */ {false, "IS_CAR_CRUSHED", new[] {Arg.ANY_INT}},
			/* 330	 */
			{
				false, "CREATE_GANG_CAR",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}
			},
			/* 331	 */
			{
				true, "CREATE_CAR_GENERATOR",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT
				}
			},
			/* 332	 */ {true, "SWITCH_CAR_GENERATOR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 333	 */ {false, "ADD_PAGER_MESSAGE", new[] {Arg.TEXT_LABEL, Arg.INT, Arg.INT, Arg.INT}},
			/* 334	 */ {true, "DISPLAY_ONSCREEN_TIMER", new[] {Arg.VAR_INT, Arg.ANY_INT}},
			/* 335	 */ {true, "CLEAR_ONSCREEN_TIMER", new[] {Arg.VAR_INT}},
			/* 336	 */ {false, "DISPLAY_ONSCREEN_COUNTER", new[] {Arg.VAR_INT, Arg.ANY_INT}},
			/* 337	 */ {true, "CLEAR_ONSCREEN_COUNTER", new[] {Arg.VAR_INT}},
			/* 338	 */
			{
				true, "SET_ZONE_CAR_INFO",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 339	 */ {false, "IS_CHAR_IN_GANG_ZONE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 340	 */ {true, "IS_CHAR_IN_ZONE", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 341	 */ {false, "SET_CAR_DENSITY", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}},
			/* 342	 */ {false, "SET_PED_DENSITY", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}},
			/* 343	 */ {true, "POINT_CAMERA_AT_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 344	 */ {true, "POINT_CAMERA_AT_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 345	 */ {true, "POINT_CAMERA_AT_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 346	 */ {true, "RESTORE_CAMERA"},
			/* 347	 */ {false, "SHAKE_PAD", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 348	 */
			{
				true, "SET_ZONE_PED_INFO",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 349	 */ {true, "SET_TIME_SCALE", new[] {Arg.ANY_FLOAT}},
			/* 350	 */ {false, "IS_CAR_IN_AIR", new[] {Arg.ANY_INT}},
			/* 351	 */
			{
				true, "SET_FIXED_CAMERA_POSITION",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 352	 */
			{true, "POINT_CAMERA_AT_POINT", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 353	 */ {true, "ADD_BLIP_FOR_CAR_OLD", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 354	 */ {true, "ADD_BLIP_FOR_CHAR_OLD", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 355	 */
			{false, "ADD_BLIP_FOR_OBJECT_OLD", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 356	 */ {true, "REMOVE_BLIP", new[] {Arg.ANY_INT}},
			/* 357	 */ {true, "CHANGE_BLIP_COLOUR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 358	 */ {true, "DIM_BLIP", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 359	 */
			{
				true, "ADD_BLIP_FOR_COORD_OLD",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 360	 */ {true, "CHANGE_BLIP_SCALE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 361	 */ {true, "SET_FADING_COLOUR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 362	 */ {true, "DO_FADE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 363	 */ {true, "GET_FADING_STATUS"},
			/* 364	 */
			{true, "ADD_HOSPITAL_RESTART", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 365	 */ {true, "ADD_POLICE_RESTART", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 366	 */
			{true, "OVERRIDE_NEXT_RESTART", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 367	 */
			{
				false, "DRAW_SHADOW",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 368	 */ {true, "GET_PLAYER_HEADING", new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT}},
			/* 369	 */ {true, "SET_PLAYER_HEADING", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 370	 */ {true, "GET_CHAR_HEADING", new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT}},
			/* 371	 */ {true, "SET_CHAR_HEADING", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 372	 */ {true, "GET_CAR_HEADING", new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT}},
			/* 373	 */ {true, "SET_CAR_HEADING", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 374	 */ {true, "GET_OBJECT_HEADING", new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT}},
			/* 375	 */ {true, "SET_OBJECT_HEADING", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 376	 */ {false, "IS_PLAYER_TOUCHING_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 377	 */ {true, "IS_CHAR_TOUCHING_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 378	 */ {true, "SET_PLAYER_AMMO", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 379	 */ {false, "SET_CHAR_AMMO", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 380	 */ {false, "SET_CAR_AMMO", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 381	 */ {false, "LOAD_CAMERA_SPLINE", new[] {Arg.TEXT_LABEL}},
			/* 382	 */ {false, "MOVE_CAMERA_ALONG_SPLINE", new[] {Arg.ANY_INT}},
			/* 383	 */ {false, "GET_CAMERA_POSITION_ALONG_SPLINE", new[] {Arg.VAR_LVAR_FLOAT}},
			/* 384	 */ {true, "DECLARE_MISSION_FLAG", new[] {Arg.VAR_INT}},
			/* 385	 */ {false, "DECLARE_MISSION_FLAG_FOR_CONTACT", new[] {Arg.ANY_INT, Arg.VAR_INT}},
			/* 386	 */ {false, "DECLARE_BASE_BRIEF_ID_FOR_CONTACT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 387	 */ {true, "IS_PLAYER_HEALTH_GREATER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 388	 */ {true, "IS_CHAR_HEALTH_GREATER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 389	 */ {true, "IS_CAR_HEALTH_GREATER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 390	 */ {true, "ADD_BLIP_FOR_CAR", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 391	 */ {true, "ADD_BLIP_FOR_CHAR", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 392	 */ {true, "ADD_BLIP_FOR_OBJECT", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 393	 */
			{true, "ADD_BLIP_FOR_CONTACT_POINT", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 394	 */
			{true, "ADD_BLIP_FOR_COORD", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 395	 */ {true, "CHANGE_BLIP_DISPLAY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 396	 */ {true, "ADD_ONE_OFF_SOUND", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 397	 */
			{
				true, "ADD_CONTINUOUS_SOUND",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 398	 */ {true, "REMOVE_SOUND", new[] {Arg.ANY_INT}},
			/* 399	 */ {true, "IS_CAR_STUCK_ON_ROOF", new[] {Arg.ANY_INT}},
			/* 400	 */ {true, "ADD_UPSIDEDOWN_CAR_CHECK", new[] {Arg.ANY_INT}},
			/* 401	 */ {true, "REMOVE_UPSIDEDOWN_CAR_CHECK", new[] {Arg.ANY_INT}},
			/* 402	 */ {true, "SET_CHAR_OBJ_WAIT_ON_FOOT", new[] {Arg.ANY_INT}},
			/* 403	 */ {true, "SET_CHAR_OBJ_FLEE_ON_FOOT_TILL_SAFE", new[] {Arg.ANY_INT}},
			/* 404	 */
			{true, "SET_CHAR_OBJ_GUARD_SPOT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 405	 */
			{
				false, "SET_CHAR_OBJ_GUARD_AREA",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 406	 */ {false, "SET_CHAR_OBJ_WAIT_IN_CAR", new[] {Arg.ANY_INT}},
			/* 407	 */
			{
				true, "IS_PLAYER_IN_AREA_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 408	 */
			{
				true, "IS_PLAYER_IN_AREA_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 409	 */
			{
				true, "IS_PLAYER_STOPPED_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 410	 */
			{
				true, "IS_PLAYER_STOPPED_IN_AREA_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 411	 */
			{
				true, "IS_PLAYER_STOPPED_IN_AREA_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 412	 */
			{
				true, "IS_PLAYER_IN_AREA_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 413	 */
			{
				true, "IS_PLAYER_IN_AREA_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 414	 */
			{
				true, "IS_PLAYER_STOPPED_IN_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 415	 */
			{
				true, "IS_PLAYER_STOPPED_IN_AREA_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 416	 */
			{
				true, "IS_PLAYER_STOPPED_IN_AREA_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 417	 */
			{
				true, "IS_CHAR_IN_AREA_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 418	 */
			{
				true, "IS_CHAR_IN_AREA_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 419	 */
			{
				true, "IS_CHAR_STOPPED_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 420	 */
			{
				true, "IS_CHAR_STOPPED_IN_AREA_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 421	 */
			{
				true, "IS_CHAR_STOPPED_IN_AREA_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 422	 */
			{
				true, "IS_CHAR_IN_AREA_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 423	 */
			{
				true, "IS_CHAR_IN_AREA_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 424	 */
			{
				true, "IS_CHAR_STOPPED_IN_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 425	 */
			{
				true, "IS_CHAR_STOPPED_IN_AREA_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 426	 */
			{
				true, "IS_CHAR_STOPPED_IN_AREA_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 427	 */
			{
				true, "IS_CAR_STOPPED_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 428	 */
			{
				true, "IS_CAR_STOPPED_IN_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 429	 */
			{
				true, "LOCATE_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 430	 */
			{
				true, "LOCATE_STOPPED_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 431	 */
			{
				true, "LOCATE_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 432	 */
			{
				true, "LOCATE_STOPPED_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 433	 */ {true, "GIVE_WEAPON_TO_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 434	 */ {true, "GIVE_WEAPON_TO_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 435	 */ {false, "GIVE_WEAPON_TO_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 436	 */ {true, "SET_PLAYER_CONTROL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 437	 */ {true, "FORCE_WEATHER", new[] {Arg.ANY_INT}},
			/* 438	 */ {true, "FORCE_WEATHER_NOW", new[] {Arg.ANY_INT}},
			/* 439	 */ {true, "RELEASE_WEATHER"},
			/* 440	 */ {true, "SET_CURRENT_PLAYER_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 441	 */ {true, "SET_CURRENT_CHAR_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 442	 */ {false, "SET_CURRENT_CAR_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 443	 */
			{
				true, "GET_OBJECT_COORDINATES",
				new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}
			},
			/* 444	 */
			{true, "SET_OBJECT_COORDINATES", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 445	 */ {true, "GET_GAME_TIMER", new[] {Arg.VAR_LVAR_INT}},
			/* 446	 */
			{true, "TURN_CHAR_TO_FACE_COORD", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 447	 */
			{false, "TURN_PLAYER_TO_FACE_COORD", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 448	 */ {true, "STORE_WANTED_LEVEL", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 449	 */ {true, "IS_CAR_STOPPED", new[] {Arg.ANY_INT}},
			/* 450	 */ {true, "MARK_CHAR_AS_NO_LONGER_NEEDED", new[] {Arg.ANY_INT}},
			/* 451	 */ {true, "MARK_CAR_AS_NO_LONGER_NEEDED", new[] {Arg.ANY_INT}},
			/* 452	 */ {true, "MARK_OBJECT_AS_NO_LONGER_NEEDED", new[] {Arg.ANY_INT}},
			/* 453	 */ {true, "DONT_REMOVE_CHAR", new[] {Arg.ANY_INT}},
			/* 454	 */ {false, "DONT_REMOVE_CAR", new[] {Arg.ANY_INT}},
			/* 455	 */ {true, "DONT_REMOVE_OBJECT", new[] {Arg.ANY_INT}},
			/* 456	 */
			{
				true, "CREATE_CHAR_AS_PASSENGER",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 457	 */ {true, "SET_CHAR_OBJ_KILL_CHAR_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 458	 */ {true, "SET_CHAR_OBJ_KILL_PLAYER_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 459	 */ {true, "SET_CHAR_OBJ_KILL_CHAR_ANY_MEANS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 460	 */ {true, "SET_CHAR_OBJ_KILL_PLAYER_ANY_MEANS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 461	 */ {false, "SET_CHAR_OBJ_FLEE_CHAR_ON_FOOT_TILL_SAFE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 462	 */ {true, "SET_CHAR_OBJ_FLEE_PLAYER_ON_FOOT_TILL_SAFE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 463	 */ {true, "SET_CHAR_OBJ_FLEE_CHAR_ON_FOOT_ALWAYS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 464	 */ {true, "SET_CHAR_OBJ_FLEE_PLAYER_ON_FOOT_ALWAYS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 465	 */ {true, "SET_CHAR_OBJ_GOTO_CHAR_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 466	 */ {true, "SET_CHAR_OBJ_GOTO_PLAYER_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 467	 */ {true, "SET_CHAR_OBJ_LEAVE_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 468	 */ {true, "SET_CHAR_OBJ_ENTER_CAR_AS_PASSENGER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 469	 */ {true, "SET_CHAR_OBJ_ENTER_CAR_AS_DRIVER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 470	 */ {false, "SET_CHAR_OBJ_FOLLOW_CAR_IN_CAR", new[] {Arg.ANY_INT}},
			/* 471	 */ {false, "SET_CHAR_OBJ_FIRE_AT_OBJECT_FROM_VEHICLE", new[] {Arg.ANY_INT}},
			/* 472	 */ {true, "SET_CHAR_OBJ_DESTROY_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 473	 */ {true, "SET_CHAR_OBJ_DESTROY_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 474	 */
			{
				false, "SET_CHAR_OBJ_GOTO_AREA_ON_FOOT",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 475	 */ {false, "SET_CHAR_OBJ_GOTO_AREA_IN_CAR", new[] {Arg.ANY_INT}},
			/* 476	 */ {false, "SET_CHAR_OBJ_FOLLOW_CAR_ON_FOOT_WITH_OFFSET", new[] {Arg.ANY_INT}},
			/* 477	 */ {false, "SET_CHAR_OBJ_GUARD_ATTACK", new[] {Arg.ANY_INT}},
			/* 478	 */ {true, "SET_CHAR_AS_LEADER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 479	 */ {true, "SET_PLAYER_AS_LEADER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 480	 */ {true, "LEAVE_GROUP", new[] {Arg.ANY_INT}},
			/* 481	 */ {true, "SET_CHAR_OBJ_FOLLOW_ROUTE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 482	 */ {true, "ADD_ROUTE_POINT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 483	 */ {true, "PRINT_WITH_NUMBER_BIG", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 484	 */ {true, "PRINT_WITH_NUMBER", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 485	 */ {true, "PRINT_WITH_NUMBER_NOW", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 486	 */ {false, "PRINT_WITH_NUMBER_SOON", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 487	 */
			{
				true, "SWITCH_ROADS_ON",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 488	 */
			{
				true, "SWITCH_ROADS_OFF",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 489	 */ {true, "GET_NUMBER_OF_PASSENGERS", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 490	 */ {true, "GET_MAXIMUM_NUMBER_OF_PASSENGERS", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 491	 */ {true, "SET_CAR_DENSITY_MULTIPLIER", new[] {Arg.ANY_FLOAT}},
			/* 492	 */ {true, "SET_CAR_HEAVY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 493	 */ {true, "CLEAR_CHAR_THREAT_SEARCH", new[] {Arg.ANY_INT}},
			/* 494	 */
			{
				false, "ACTIVATE_CRANE",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT
				}
			},
			/* 495	 */ {false, "DEACTIVATE_CRANE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 496	 */ {true, "SET_MAX_WANTED_LEVEL", new[] {Arg.ANY_INT}},
			/* 497	 */
			{
				false, "SAVE_VAR_INT",
				new[]
				{
					Arg.VAR_INT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT,
					Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT,
					Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT, Arg.VAR_INT_OPT
				}
			},
			/* 498	 */
			{
				false, "SAVE_VAR_FLOAT",
				new[]
				{
					Arg.VAR_FLOAT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT,
					Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT,
					Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT, Arg.VAR_FLOAT_OPT,
					Arg.VAR_FLOAT_OPT
				}
			},
			/* 499	 */ {true, "IS_CAR_IN_AIR_PROPER", new[] {Arg.ANY_INT}},
			/* 500	 */ {true, "IS_CAR_UPSIDEDOWN", new[] {Arg.ANY_INT}},
			/* 501	 */ {true, "GET_PLAYER_CHAR", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 502	 */ {true, "CANCEL_OVERRIDE_RESTART"},
			/* 503	 */ {true, "SET_POLICE_IGNORE_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 504	 */
			{
				false, "ADD_PAGER_MESSAGE_WITH_NUMBER",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 505	 */
			{
				true, "START_KILL_FRENZY",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 506	 */ {true, "READ_KILL_FRENZY_STATUS", new[] {Arg.VAR_LVAR_INT}},
			/* 507	 */ {true, "SQRT", new[] {Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 508	 */
			{
				true, "LOCATE_PLAYER_ANY_MEANS_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 509	 */
			{
				true, "LOCATE_PLAYER_ON_FOOT_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 510	 */
			{
				true, "LOCATE_PLAYER_IN_CAR_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 511	 */
			{
				true, "LOCATE_PLAYER_ANY_MEANS_CAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 512	 */
			{
				true, "LOCATE_PLAYER_ON_FOOT_CAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 513	 */
			{
				true, "LOCATE_PLAYER_IN_CAR_CAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 514	 */
			{
				true, "LOCATE_CHAR_ANY_MEANS_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 515	 */
			{
				true, "LOCATE_CHAR_ON_FOOT_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 516	 */
			{
				true, "LOCATE_CHAR_IN_CAR_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 517	 */
			{
				true, "LOCATE_CHAR_ANY_MEANS_CAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 518	 */
			{
				true, "LOCATE_CHAR_ON_FOOT_CAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 519	 */
			{
				true, "LOCATE_CHAR_IN_CAR_CAR_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 520	 */
			{true, "GENERATE_RANDOM_FLOAT_IN_RANGE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 521	 */ {true, "GENERATE_RANDOM_INT_IN_RANGE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 522	 */ {true, "LOCK_CAR_DOORS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 523	 */ {true, "EXPLODE_CAR", new[] {Arg.ANY_INT}},
			/* 524	 */ {true, "ADD_EXPLOSION", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 525	 */ {true, "IS_CAR_UPRIGHT", new[] {Arg.ANY_INT}},
			/* 526	 */ {true, "TURN_CHAR_TO_FACE_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 527	 */ {true, "TURN_CHAR_TO_FACE_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 528	 */ {true, "TURN_PLAYER_TO_FACE_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 529	 */ {true, "SET_CHAR_OBJ_GOTO_COORD_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 530	 */ {false, "SET_CHAR_OBJ_GOTO_COORD_IN_CAR", new[] {Arg.ANY_INT}},
			/* 531	 */
			{
				true, "CREATE_PICKUP",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}
			},
			/* 532	 */ {true, "HAS_PICKUP_BEEN_COLLECTED", new[] {Arg.ANY_INT}},
			/* 533	 */ {true, "REMOVE_PICKUP", new[] {Arg.ANY_INT}},
			/* 534	 */ {true, "SET_TAXI_LIGHTS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 535	 */ {true, "PRINT_BIG_Q", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}},
			/* 536	 */
			{false, "PRINT_WITH_NUMBER_BIG_Q", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 537	 */
			{
				true, "SET_GARAGE",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.VAR_LVAR_INT
				}
			},
			/* 538	 */
			{
				false, "SET_GARAGE_WITH_CAR_MODEL",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT
				}
			},
			/* 539	 */ {true, "SET_TARGET_CAR_FOR_MISSION_GARAGE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 540	 */ {true, "IS_CAR_IN_MISSION_GARAGE", new[] {Arg.ANY_INT}},
			/* 541	 */ {false, "SET_FREE_BOMBS", new[] {Arg.ANY_INT}},
			/* 542	 */
			{
				false, "SET_POWERPOINT",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_INT
				}
			},
			/* 543	 */ {false, "SET_ALL_TAXI_LIGHTS", new[] {Arg.ANY_INT}},
			/* 544	 */ {false, "IS_CAR_ARMED_WITH_ANY_BOMB", new[] {Arg.ANY_INT}},
			/* 545	 */ {true, "APPLY_BRAKES_TO_PLAYERS_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 546	 */ {true, "SET_PLAYER_HEALTH", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 547	 */ {true, "SET_CHAR_HEALTH", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 548	 */ {true, "SET_CAR_HEALTH", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 549	 */ {true, "GET_PLAYER_HEALTH", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 550	 */ {true, "GET_CHAR_HEALTH", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 551	 */ {true, "GET_CAR_HEALTH", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 552	 */ {false, "IS_CAR_ARMED_WITH_BOMB", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 553	 */ {true, "CHANGE_CAR_COLOUR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 554	 */
			{
				true, "SWITCH_PED_ROADS_ON",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 555	 */
			{
				true, "SWITCH_PED_ROADS_OFF",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 556	 */ {true, "CHAR_LOOK_AT_CHAR_ALWAYS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 557	 */ {true, "CHAR_LOOK_AT_PLAYER_ALWAYS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 558	 */ {true, "PLAYER_LOOK_AT_CHAR_ALWAYS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 559	 */ {true, "STOP_CHAR_LOOKING", new[] {Arg.ANY_INT}},
			/* 560	 */ {true, "STOP_PLAYER_LOOKING", new[] {Arg.ANY_INT}},
			/* 561	 */ {false, "SWITCH_HELICOPTER", new[] {Arg.ANY_INT}},
			/* 562	 */
			{
				false, "SET_GANG_ATTITUDE",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT
				}
			},
			/* 563	 */ {false, "SET_GANG_GANG_ATTITUDE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 564	 */ {false, "SET_GANG_PLAYER_ATTITUDE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 565	 */ {true, "SET_GANG_PED_MODELS", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 566	 */ {true, "SET_GANG_CAR_MODEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 567	 */ {true, "SET_GANG_WEAPONS", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 568	 */
			{
				false, "SET_CHAR_OBJ_RUN_TO_AREA",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 569	 */ {true, "SET_CHAR_OBJ_RUN_TO_COORD", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 570	 */ {false, "IS_PLAYER_TOUCHING_OBJECT_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 571	 */ {false, "IS_CHAR_TOUCHING_OBJECT_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 572	 */ {true, "LOAD_SPECIAL_CHARACTER", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 573	 */ {true, "HAS_SPECIAL_CHARACTER_LOADED", new[] {Arg.ANY_INT}},
			/* 574	 */ {false, "FLASH_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 575	 */ {false, "FLASH_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 576	 */ {false, "FLASH_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 577	 */ {true, "IS_PLAYER_IN_REMOTE_MODE", new[] {Arg.ANY_INT}},
			/* 578	 */ {false, "ARM_CAR_WITH_BOMB", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 579	 */ {true, "SET_CHAR_PERSONALITY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 580	 */ {true, "SET_CUTSCENE_OFFSET", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 581	 */ {true, "SET_ANIM_GROUP_FOR_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 582	 */ {false, "SET_ANIM_GROUP_FOR_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 583	 */ {true, "REQUEST_MODEL", new[] {Arg.ANY_INT}},
			/* 584	 */ {true, "HAS_MODEL_LOADED", new[] {Arg.ANY_INT}},
			/* 585	 */ {true, "MARK_MODEL_AS_NO_LONGER_NEEDED", new[] {Arg.ANY_INT}},
			/* 586	 */ {true, "GRAB_PHONE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 587	 */ {false, "SET_REPEATED_PHONE_MESSAGE", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 588	 */ {false, "SET_PHONE_MESSAGE", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 589	 */ {false, "HAS_PHONE_DISPLAYED_MESSAGE", new[] {Arg.ANY_INT}},
			/* 590	 */ {true, "TURN_PHONE_OFF", new[] {Arg.ANY_INT}},
			/* 591	 */
			{
				true, "DRAW_CORONA",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 592	 */
			{
				false, "DRAW_LIGHT",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 593	 */ {false, "STORE_WEATHER"},
			/* 594	 */ {false, "RESTORE_WEATHER"},
			/* 595	 */ {true, "STORE_CLOCK"},
			/* 596	 */ {true, "RESTORE_CLOCK"},
			/* 597	 */
			{false, "RESTART_CRITICAL_MISSION", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 598	 */ {true, "IS_PLAYER_PLAYING", new[] {Arg.ANY_INT}},
			/* 599	 */ {false, "SET_COLL_OBJ_NO_OBJ", new[] {Arg.ANY_INT}},
			/* 600	 */ {false, "SET_COLL_OBJ_WAIT_ON_FOOT", new[] {Arg.ANY_INT}},
			/* 601	 */ {false, "SET_COLL_OBJ_FLEE_ON_FOOT_TILL_SAFE", new[] {Arg.ANY_INT}},
			/* 602	 */
			{false, "SET_COLL_OBJ_GUARD_SPOT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 603	 */
			{
				false, "SET_COLL_OBJ_GUARD_AREA",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 604	 */ {false, "SET_COLL_OBJ_WAIT_IN_CAR", new[] {Arg.ANY_INT}},
			/* 605	 */ {false, "SET_COLL_OBJ_KILL_CHAR_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 606	 */ {false, "SET_COLL_OBJ_KILL_PLAYER_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 607	 */ {false, "SET_COLL_OBJ_KILL_CHAR_ANY_MEANS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 608	 */ {false, "SET_COLL_OBJ_KILL_PLAYER_ANY_MEANS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 609	 */ {false, "SET_COLL_OBJ_FLEE_CHAR_ON_FOOT_TILL_SAFE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 610	 */ {false, "SET_COLL_OBJ_FLEE_PLAYER_ON_FOOT_TILL_SAFE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 611	 */ {false, "SET_COLL_OBJ_FLEE_CHAR_ON_FOOT_ALWAYS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 612	 */ {false, "SET_COLL_OBJ_FLEE_PLAYER_ON_FOOT_ALWAYS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 613	 */ {false, "SET_COLL_OBJ_GOTO_CHAR_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 614	 */ {false, "SET_COLL_OBJ_GOTO_PLAYER_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 615	 */ {false, "SET_COLL_OBJ_LEAVE_CAR", new[] {Arg.ANY_INT}},
			/* 616	 */ {false, "SET_COLL_OBJ_ENTER_CAR_AS_PASSENGER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 617	 */ {false, "SET_COLL_OBJ_ENTER_CAR_AS_DRIVER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 618	 */ {false, "SET_COLL_OBJ_FOLLOW_CAR_IN_CAR", new[] {Arg.ANY_INT}},
			/* 619	 */ {false, "SET_COLL_OBJ_FIRE_AT_OBJECT_FROM_VEHICLE", new[] {Arg.ANY_INT}},
			/* 620	 */ {false, "SET_COLL_OBJ_DESTROY_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 621	 */ {false, "SET_COLL_OBJ_DESTROY_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 622	 */
			{
				false, "SET_COLL_OBJ_GOTO_AREA_ON_FOOT",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 623	 */ {false, "SET_COLL_OBJ_GOTO_AREA_IN_CAR", new[] {Arg.ANY_INT}},
			/* 624	 */ {false, "SET_COLL_OBJ_FOLLOW_CAR_ON_FOOT_WITH_OFFSET", new[] {Arg.ANY_INT}},
			/* 625	 */ {false, "SET_COLL_OBJ_GUARD_ATTACK", new[] {Arg.ANY_INT}},
			/* 626	 */ {false, "SET_COLL_OBJ_FOLLOW_ROUTE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 627	 */ {false, "SET_COLL_OBJ_GOTO_COORD_ON_FOOT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 628	 */ {false, "SET_COLL_OBJ_GOTO_COORD_IN_CAR", new[] {Arg.ANY_INT}},
			/* 629	 */
			{
				false, "SET_COLL_OBJ_RUN_TO_AREA",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 630	 */ {false, "SET_COLL_OBJ_RUN_TO_COORD", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 631	 */
			{false, "ADD_PEDS_IN_AREA_TO_COLL", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 632	 */ {false, "ADD_PEDS_IN_VEHICLE_TO_COLL", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 633	 */ {false, "CLEAR_COLL", new[] {Arg.ANY_INT}},
			/* 634	 */ {false, "IS_COLL_IN_CARS", new[] {Arg.ANY_INT}},
			/* 635	 */
			{
				false, "LOCATE_COLL_ANY_MEANS_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 636	 */
			{
				false, "LOCATE_COLL_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 637	 */
			{
				false, "LOCATE_COLL_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 638	 */
			{
				false, "LOCATE_STOPPED_COLL_ANY_MEANS_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 639	 */
			{
				false, "LOCATE_STOPPED_COLL_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 640	 */
			{
				false, "LOCATE_STOPPED_COLL_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 641	 */
			{
				false, "LOCATE_COLL_ANY_MEANS_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 642	 */
			{
				false, "LOCATE_COLL_ON_FOOT_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 643	 */
			{
				false, "LOCATE_COLL_IN_CAR_CHAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 644	 */
			{
				false, "LOCATE_COLL_ANY_MEANS_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 645	 */
			{
				false, "LOCATE_COLL_ON_FOOT_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 646	 */
			{
				false, "LOCATE_COLL_IN_CAR_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 647	 */
			{
				false, "LOCATE_COLL_ANY_MEANS_PLAYER_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 648	 */
			{
				false, "LOCATE_COLL_ON_FOOT_PLAYER_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 649	 */
			{
				false, "LOCATE_COLL_IN_CAR_PLAYER_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 650	 */
			{
				false, "IS_COLL_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 651	 */
			{
				false, "IS_COLL_IN_AREA_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 652	 */
			{
				false, "IS_COLL_IN_AREA_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 653	 */
			{
				false, "IS_COLL_STOPPED_IN_AREA_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 654	 */
			{
				false, "IS_COLL_STOPPED_IN_AREA_ON_FOOT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 655	 */
			{
				false, "IS_COLL_STOPPED_IN_AREA_IN_CAR_2D",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 656	 */ {false, "GET_NUMBER_OF_PEDS_IN_COLL", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 657	 */ {true, "SET_CHAR_HEED_THREATS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 658	 */ {false, "SET_PLAYER_HEED_THREATS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 659	 */ {true, "GET_CONTROLLER_MODE", new[] {Arg.VAR_LVAR_INT}},
			/* 660	 */ {true, "SET_CAN_RESPRAY_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 661	 */ {false, "IS_TAXI", new[] {Arg.ANY_INT}},
			/* 662	 */ {true, "UNLOAD_SPECIAL_CHARACTER", new[] {Arg.ANY_INT}},
			/* 663	 */ {true, "RESET_NUM_OF_MODELS_KILLED_BY_PLAYER"},
			/* 664	 */ {true, "GET_NUM_OF_MODELS_KILLED_BY_PLAYER", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 665	 */ {false, "ACTIVATE_GARAGE", new[] {Arg.ANY_INT}},
			/* 666	 */ {false, "SWITCH_TAXI_TIMER", new[] {Arg.ANY_INT}},
			/* 667	 */
			{
				true, "CREATE_OBJECT_NO_OFFSET",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}
			},
			/* 668	 */ {false, "IS_BOAT", new[] {Arg.ANY_INT}},
			/* 669	 */
			{
				false, "SET_CHAR_OBJ_GOTO_AREA_ANY_MEANS",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 670	 */
			{
				false, "SET_COLL_OBJ_GOTO_AREA_ANY_MEANS",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 671	 */ {true, "IS_PLAYER_STOPPED", new[] {Arg.ANY_INT}},
			/* 672	 */ {true, "IS_CHAR_STOPPED", new[] {Arg.ANY_INT}},
			/* 673	 */ {false, "MESSAGE_WAIT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 674	 */
			{
				false, "ADD_PARTICLE_EFFECT",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 675	 */ {true, "SWITCH_WIDESCREEN", new[] {Arg.ANY_INT}},
			/* 676	 */ {false, "ADD_SPRITE_BLIP_FOR_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 677	 */ {false, "ADD_SPRITE_BLIP_FOR_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 678	 */ {false, "ADD_SPRITE_BLIP_FOR_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 679	 */
			{
				true, "ADD_SPRITE_BLIP_FOR_CONTACT_POINT",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 680	 */
			{
				true, "ADD_SPRITE_BLIP_FOR_COORD",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 681	 */ {true, "SET_CHAR_ONLY_DAMAGED_BY_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 682	 */ {true, "SET_CAR_ONLY_DAMAGED_BY_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 683	 */
			{
				true, "SET_CHAR_PROOFS",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 684	 */
			{
				true, "SET_CAR_PROOFS",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 685	 */
			{
				true, "IS_PLAYER_IN_ANGLED_AREA_2D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 686	 */
			{
				true, "IS_PLAYER_IN_ANGLED_AREA_ON_FOOT_2D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 687	 */
			{
				true, "IS_PLAYER_IN_ANGLED_AREA_IN_CAR_2D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 688	 */
			{
				true, "IS_PLAYER_STOPPED_IN_ANGLED_AREA_2D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 689	 */
			{
				true, "IS_PLAYER_STOPPED_IN_ANGLED_AREA_ON_FOOT_2D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 690	 */
			{
				true, "IS_PLAYER_STOPPED_IN_ANGLED_AREA_IN_CAR_2D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 691	 */
			{
				true, "IS_PLAYER_IN_ANGLED_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 692	 */
			{
				true, "IS_PLAYER_IN_ANGLED_AREA_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 693	 */
			{
				true, "IS_PLAYER_IN_ANGLED_AREA_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 694	 */
			{
				true, "IS_PLAYER_STOPPED_IN_ANGLED_AREA_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 695	 */
			{
				true, "IS_PLAYER_STOPPED_IN_ANGLED_AREA_ON_FOOT_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 696	 */
			{
				true, "IS_PLAYER_STOPPED_IN_ANGLED_AREA_IN_CAR_3D",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 697	 */ {false, "DEACTIVATE_GARAGE", new[] {Arg.ANY_INT}},
			/* 698	 */ {false, "GET_NUMBER_OF_CARS_COLLECTED_BY_GARAGE", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 699	 */ {false, "HAS_CAR_BEEN_TAKEN_TO_GARAGE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 700	 */ {false, "SET_SWAT_REQUIRED", new[] {Arg.ANY_INT}},
			/* 701	 */ {false, "SET_FBI_REQUIRED", new[] {Arg.ANY_INT}},
			/* 702	 */ {false, "SET_ARMY_REQUIRED", new[] {Arg.ANY_INT}},
			/* 703	 */ {true, "IS_CAR_IN_WATER", new[] {Arg.ANY_INT}},
			/* 704	 */
			{
				true, "GET_CLOSEST_CHAR_NODE",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT,
					Arg.VAR_LVAR_FLOAT
				}
			},
			/* 705	 */
			{
				true, "GET_CLOSEST_CAR_NODE",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT,
					Arg.VAR_LVAR_FLOAT
				}
			},
			/* 706	 */
			{true, "CAR_GOTO_COORDINATES_ACCURATE", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 707	 */ {false, "START_PACMAN_RACE", new[] {Arg.ANY_INT}},
			/* 708	 */ {false, "START_PACMAN_RECORD"},
			/* 709	 */ {false, "GET_NUMBER_OF_POWER_PILLS_EATEN", new[] {Arg.VAR_LVAR_INT}},
			/* 710	 */ {false, "CLEAR_PACMAN"},
			/* 711	 */
			{
				false, "START_PACMAN_SCRAMBLE",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 712	 */ {false, "GET_NUMBER_OF_POWER_PILLS_CARRIED", new[] {Arg.VAR_LVAR_INT}},
			/* 713	 */ {false, "CLEAR_NUMBER_OF_POWER_PILLS_CARRIED"},
			/* 714	 */ {true, "IS_CAR_ON_SCREEN", new[] {Arg.ANY_INT}},
			/* 715	 */ {true, "IS_CHAR_ON_SCREEN", new[] {Arg.ANY_INT}},
			/* 716	 */ {true, "IS_OBJECT_ON_SCREEN", new[] {Arg.ANY_INT}},
			/* 717	 */ {false, "GOSUB_FILE", new[] {Arg.LABEL, Arg.LABEL}},
			/* 718	 */
			{
				true, "GET_GROUND_Z_FOR_3D_COORD",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT}
			},
			/* 719	 */
			{true, "START_SCRIPT_FIRE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 720	 */ {true, "IS_SCRIPT_FIRE_EXTINGUISHED", new[] {Arg.ANY_INT}},
			/* 721	 */ {true, "REMOVE_SCRIPT_FIRE", new[] {Arg.ANY_INT}},
			/* 722	 */ {false, "SET_COMEDY_CONTROLS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 723	 */ {true, "BOAT_GOTO_COORDS", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 724	 */ {true, "BOAT_STOP", new[] {Arg.ANY_INT}},
			/* 725	 */
			{
				true, "IS_PLAYER_SHOOTING_IN_AREA",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 726	 */
			{
				false, "IS_CHAR_SHOOTING_IN_AREA",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 727	 */ {true, "IS_CURRENT_PLAYER_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 728	 */ {true, "IS_CURRENT_CHAR_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 729	 */ {false, "CLEAR_NUMBER_OF_POWER_PILLS_EATEN"},
			/* 730	 */ {false, "ADD_POWER_PILL", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 731	 */ {true, "SET_BOAT_CRUISE_SPEED", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 732	 */
			{
				false, "GET_RANDOM_CHAR_IN_AREA",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.VAR_LVAR_INT
				}
			},
			/* 733	 */
			{
				true, "GET_RANDOM_CHAR_IN_ZONE",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 734	 */ {true, "IS_PLAYER_IN_TAXI", new[] {Arg.ANY_INT}},
			/* 735	 */ {true, "IS_PLAYER_SHOOTING", new[] {Arg.ANY_INT}},
			/* 736	 */ {true, "IS_CHAR_SHOOTING", new[] {Arg.ANY_INT}},
			/* 737	 */
			{
				true, "CREATE_MONEY_PICKUP",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 738	 */ {true, "SET_CHAR_ACCURACY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 739	 */ {true, "GET_CAR_SPEED", new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT}},
			/* 740	 */ {true, "LOAD_CUTSCENE", new[] {Arg.TEXT_LABEL}},
			/* 741	 */ {true, "CREATE_CUTSCENE_OBJECT", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 742	 */ {true, "SET_CUTSCENE_ANIM", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 743	 */ {true, "START_CUTSCENE"},
			/* 744	 */ {true, "GET_CUTSCENE_TIME", new[] {Arg.VAR_LVAR_INT}},
			/* 745	 */ {true, "HAS_CUTSCENE_FINISHED"},
			/* 746	 */ {true, "CLEAR_CUTSCENE"},
			/* 747	 */ {true, "RESTORE_CAMERA_JUMPCUT"},
			/* 748	 */ {true, "CREATE_COLLECTABLE1", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 749	 */ {true, "SET_COLLECTABLE1_TOTAL", new[] {Arg.ANY_INT}},
			/* 750	 */
			{
				false, "IS_PROJECTILE_IN_AREA",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 751	 */
			{
				false, "DESTROY_PROJECTILES_IN_AREA",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 752	 */ {false, "DROP_MINE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 753	 */ {false, "DROP_NAUTICAL_MINE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 754	 */ {true, "IS_CHAR_MODEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 755	 */ {true, "LOAD_SPECIAL_MODEL", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 756	 */ {false, "CREATE_CUTSCENE_HEAD", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 757	 */ {false, "SET_CUTSCENE_HEAD_ANIM", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 758	 */ {true, "SIN", new[] {Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 759	 */ {true, "COS", new[] {Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 760	 */ {true, "GET_CAR_FORWARD_X", new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT}},
			/* 761	 */ {true, "GET_CAR_FORWARD_Y", new[] {Arg.ANY_INT, Arg.VAR_LVAR_FLOAT}},
			/* 762	 */ {true, "CHANGE_GARAGE_TYPE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 763	 */
			{
				false, "ACTIVATE_CRUSHER_CRANE",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT
				}
			},
			/* 764	 */
			{false, "PRINT_WITH_2_NUMBERS", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 765	 */
			{
				true, "PRINT_WITH_2_NUMBERS_NOW",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 766	 */
			{
				false, "PRINT_WITH_2_NUMBERS_SOON",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 767	 */
			{
				true, "PRINT_WITH_3_NUMBERS",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 768	 */
			{
				false, "PRINT_WITH_3_NUMBERS_NOW",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 769	 */
			{
				false, "PRINT_WITH_3_NUMBERS_SOON",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 770	 */
			{
				true, "PRINT_WITH_4_NUMBERS",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 771	 */
			{
				false, "PRINT_WITH_4_NUMBERS_NOW",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 772	 */
			{
				false, "PRINT_WITH_4_NUMBERS_SOON",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 773	 */
			{
				false, "PRINT_WITH_5_NUMBERS",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT
				}
			},
			/* 774	 */
			{
				false, "PRINT_WITH_5_NUMBERS_NOW",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT
				}
			},
			/* 775	 */
			{
				false, "PRINT_WITH_5_NUMBERS_SOON",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT
				}
			},
			/* 776	 */
			{
				true, "PRINT_WITH_6_NUMBERS",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 777	 */
			{
				false, "PRINT_WITH_6_NUMBERS_NOW",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 778	 */
			{
				false, "PRINT_WITH_6_NUMBERS_SOON",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 779	 */ {false, "SET_CHAR_OBJ_FOLLOW_CHAR_IN_FORMATION", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 780	 */ {true, "PLAYER_MADE_PROGRESS", new[] {Arg.INT}},
			/* 781	 */ {true, "SET_PROGRESS_TOTAL", new[] {Arg.INT}},
			/* 782	 */ {true, "REGISTER_JUMP_DISTANCE", new[] {Arg.ANY_FLOAT}},
			/* 783	 */ {true, "REGISTER_JUMP_HEIGHT", new[] {Arg.ANY_FLOAT}},
			/* 784	 */ {true, "REGISTER_JUMP_FLIPS", new[] {Arg.ANY_INT}},
			/* 785	 */ {true, "REGISTER_JUMP_SPINS", new[] {Arg.ANY_INT}},
			/* 786	 */ {true, "REGISTER_JUMP_STUNT", new[] {Arg.ANY_INT}},
			/* 787	 */ {true, "REGISTER_UNIQUE_JUMP_FOUND"},
			/* 788	 */ {true, "SET_UNIQUE_JUMPS_TOTAL", new[] {Arg.ANY_INT}},
			/* 789	 */ {true, "REGISTER_PASSENGER_DROPPED_OFF_TAXI"},
			/* 790	 */ {true, "REGISTER_MONEY_MADE_TAXI", new[] {Arg.ANY_INT}},
			/* 791	 */ {true, "REGISTER_MISSION_GIVEN"},
			/* 792	 */ {true, "REGISTER_MISSION_PASSED", new[] {Arg.TEXT_LABEL}},
			/* 793	 */ {true, "SET_CHAR_RUNNING", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 794	 */ {true, "REMOVE_ALL_SCRIPT_FIRES"},
			/* 795	 */ {false, "IS_FIRST_CAR_COLOUR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 796	 */ {false, "IS_SECOND_CAR_COLOUR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 797	 */ {true, "HAS_CHAR_BEEN_DAMAGED_BY_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 798	 */ {true, "HAS_CAR_BEEN_DAMAGED_BY_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 799	 */ {true, "IS_CHAR_IN_CHARS_GROUP", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 800	 */ {true, "IS_CHAR_IN_PLAYERS_GROUP", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 801	 */ {true, "EXPLODE_CHAR_HEAD", new[] {Arg.ANY_INT}},
			/* 802	 */ {true, "EXPLODE_PLAYER_HEAD", new[] {Arg.ANY_INT}},
			/* 803	 */ {true, "ANCHOR_BOAT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 804	 */ {true, "SET_ZONE_GROUP", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}},
			/* 805	 */ {true, "START_CAR_FIRE", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 806	 */ {true, "START_CHAR_FIRE", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 807	 */
			{
				true, "GET_RANDOM_CAR_OF_TYPE_IN_AREA",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 808	 */ {false, "GET_RANDOM_CAR_OF_TYPE_IN_ZONE", new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 809	 */ {true, "HAS_RESPRAY_HAPPENED", new[] {Arg.ANY_INT}},
			/* 810	 */ {true, "SET_CAMERA_ZOOM", new[] {Arg.ANY_INT}},
			/* 811	 */
			{
				true, "CREATE_PICKUP_WITH_AMMO",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT
				}
			},
			/* 812	 */ {true, "SET_CAR_RAM_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 813	 */ {false, "SET_CAR_BLOCK_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 814	 */ {false, "SET_CHAR_OBJ_CATCH_TRAIN", new[] {Arg.ANY_INT}},
			/* 815	 */ {false, "SET_COLL_OBJ_CATCH_TRAIN", new[] {Arg.ANY_INT}},
			/* 816	 */ {true, "SET_PLAYER_NEVER_GETS_TIRED", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 817	 */ {true, "SET_PLAYER_FAST_RELOAD", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 818	 */ {true, "SET_CHAR_BLEEDING", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 819	 */ {false, "SET_CAR_FUNNY_SUSPENSION", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 820	 */ {false, "SET_CAR_BIG_WHEELS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 821	 */ {true, "SET_FREE_RESPRAYS", new[] {Arg.ANY_INT}},
			/* 822	 */ {true, "SET_PLAYER_VISIBLE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 823	 */ {true, "SET_CHAR_VISIBLE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 824	 */ {false, "SET_CAR_VISIBLE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 825	 */
			{
				true, "IS_AREA_OCCUPIED",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 826	 */ {false, "START_DRUG_RUN"},
			/* 827	 */ {false, "HAS_DRUG_RUN_BEEN_COMPLETED"},
			/* 828	 */ {false, "HAS_DRUG_PLANE_BEEN_SHOT_DOWN"},
			/* 829	 */ {false, "SAVE_PLAYER_FROM_FIRES", new[] {Arg.ANY_INT}},
			/* 830	 */ {true, "DISPLAY_TEXT", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.TEXT_LABEL}},
			/* 831	 */ {true, "SET_TEXT_SCALE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 832	 */ {true, "SET_TEXT_COLOUR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 833	 */ {true, "SET_TEXT_JUSTIFY", new[] {Arg.ANY_INT}},
			/* 834	 */ {true, "SET_TEXT_CENTRE", new[] {Arg.ANY_INT}},
			/* 835	 */ {true, "SET_TEXT_WRAPX", new[] {Arg.ANY_FLOAT}},
			/* 836	 */ {false, "SET_TEXT_CENTRE_SIZE", new[] {Arg.ANY_FLOAT}},
			/* 837	 */ {true, "SET_TEXT_BACKGROUND", new[] {Arg.ANY_INT}},
			/* 838	 */
			{false, "SET_TEXT_BACKGROUND_COLOUR", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 839	 */ {false, "SET_TEXT_BACKGROUND_ONLY_TEXT", new[] {Arg.ANY_INT}},
			/* 840	 */ {true, "SET_TEXT_PROPORTIONAL", new[] {Arg.ANY_INT}},
			/* 841	 */ {false, "SET_TEXT_FONT", new[] {Arg.ANY_INT}},
			/* 842	 */ {false, "INDUSTRIAL_PASSED"},
			/* 843	 */ {false, "COMMERCIAL_PASSED"},
			/* 844	 */ {false, "SUBURBAN_PASSED"},
			/* 845	 */ {true, "ROTATE_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 846	 */
			{
				true, "SLIDE_OBJECT",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_INT
				}
			},
			/* 847	 */ {true, "REMOVE_CHAR_ELEGANTLY", new[] {Arg.ANY_INT}},
			/* 848	 */ {true, "SET_CHAR_STAY_IN_SAME_PLACE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 849	 */ {false, "IS_NASTY_GAME"},
			/* 850	 */ {true, "UNDRESS_CHAR", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 851	 */ {true, "DRESS_CHAR", new[] {Arg.ANY_INT}},
			/* 852	 */ {false, "START_CHASE_SCENE", new[] {Arg.ANY_FLOAT}},
			/* 853	 */ {false, "STOP_CHASE_SCENE"},
			/* 854	 */
			{
				false, "IS_EXPLOSION_IN_AREA",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT
				}
			},
			/* 855	 */ {false, "IS_EXPLOSION_IN_ZONE", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 856	 */ {false, "START_DRUG_DROP_OFF"},
			/* 857	 */ {false, "HAS_DROP_OFF_PLANE_BEEN_SHOT_DOWN"},
			/* 858	 */
			{
				false, "FIND_DROP_OFF_PLANE_COORDINATES",
				new[] {Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}
			},
			/* 859	 */
			{false, "CREATE_FLOATING_PACKAGE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 860	 */
			{
				true, "PLACE_OBJECT_RELATIVE_TO_CAR",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 861	 */ {true, "MAKE_OBJECT_TARGETTABLE", new[] {Arg.ANY_INT}},
			/* 862	 */ {true, "ADD_ARMOUR_TO_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 863	 */ {true, "ADD_ARMOUR_TO_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 864	 */ {true, "OPEN_GARAGE", new[] {Arg.ANY_INT}},
			/* 865	 */ {true, "CLOSE_GARAGE", new[] {Arg.ANY_INT}},
			/* 866	 */
			{true, "WARP_CHAR_FROM_CAR_TO_COORD", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 867	 */
			{
				true, "SET_VISIBILITY_OF_CLOSEST_OBJECT_OF_TYPE",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 868	 */ {false, "HAS_CHAR_SPOTTED_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 869	 */ {true, "SET_CHAR_OBJ_HAIL_TAXI", new[] {Arg.ANY_INT}},
			/* 870	 */ {true, "HAS_OBJECT_BEEN_DAMAGED", new[] {Arg.ANY_INT}},
			/* 871	 */
			{
				false, "START_KILL_FRENZY_HEADSHOT",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 872	 */
			{
				false, "ACTIVATE_MILITARY_CRANE",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT
				}
			},
			/* 873	 */ {true, "WARP_PLAYER_INTO_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 874	 */ {true, "WARP_CHAR_INTO_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 875	 */ {false, "SWITCH_CAR_RADIO", new[] {Arg.ANY_INT}},
			/* 876	 */ {false, "SET_AUDIO_STREAM", new[] {Arg.ANY_INT}},
			/* 877	 */
			{
				true, "PRINT_WITH_2_NUMBERS_BIG",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 878	 */
			{
				false, "PRINT_WITH_3_NUMBERS_BIG",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 879	 */
			{
				false, "PRINT_WITH_4_NUMBERS_BIG",
				new[] {Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 880	 */
			{
				false, "PRINT_WITH_5_NUMBERS_BIG",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT
				}
			},
			/* 881	 */
			{
				false, "PRINT_WITH_6_NUMBERS_BIG",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 882	 */ {true, "SET_CHAR_WAIT_STATE", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 883	 */ {true, "SET_CAMERA_BEHIND_PLAYER"},
			/* 884	 */ {false, "SET_MOTION_BLUR", new[] {Arg.ANY_INT}},
			/* 885	 */
			{false, "PRINT_STRING_IN_STRING", new[] {Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}},
			/* 886	 */
			{true, "CREATE_RANDOM_CHAR", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 887	 */ {true, "SET_CHAR_OBJ_STEAL_ANY_CAR", new[] {Arg.ANY_INT}},
			/* 888	 */ {false, "SET_2_REPEATED_PHONE_MESSAGES", new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL}},
			/* 889	 */ {false, "SET_2_PHONE_MESSAGES", new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL}},
			/* 890	 */
			{
				false, "SET_3_REPEATED_PHONE_MESSAGES",
				new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL}
			},
			/* 891	 */
			{false, "SET_3_PHONE_MESSAGES", new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL}},
			/* 892	 */
			{
				false, "SET_4_REPEATED_PHONE_MESSAGES",
				new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL}
			},
			/* 893	 */
			{
				false, "SET_4_PHONE_MESSAGES",
				new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL}
			},
			/* 894	 */
			{
				true, "IS_SNIPER_BULLET_IN_AREA",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 895	 */ {false, "GIVE_PLAYER_DETONATOR"},
			/* 896	 */ {false, "SET_COLL_OBJ_STEAL_ANY_CAR", new[] {Arg.ANY_INT}},
			/* 897	 */ {true, "SET_OBJECT_VELOCITY", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 898	 */ {true, "SET_OBJECT_COLLISION", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 899	 */ {true, "IS_ICECREAM_JINGLE_ON", new[] {Arg.ANY_INT}},
			/* 900	 */
			{true, "PRINT_STRING_IN_STRING_NOW", new[] {Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}},
			/* 901	 */
			{false, "PRINT_STRING_IN_STRING_SOON", new[] {Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}},
			/* 902	 */
			{
				false, "SET_5_REPEATED_PHONE_MESSAGES",
				new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL}
			},
			/* 903	 */
			{
				false, "SET_5_PHONE_MESSAGES",
				new[] {Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL}
			},
			/* 904	 */
			{
				false, "SET_6_REPEATED_PHONE_MESSAGES",
				new[]
				{
					Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL,
					Arg.TEXT_LABEL
				}
			},
			/* 905	 */
			{
				false, "SET_6_PHONE_MESSAGES",
				new[]
				{
					Arg.ANY_INT, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL, Arg.TEXT_LABEL,
					Arg.TEXT_LABEL
				}
			},
			/* 906	 */
			{
				true, "IS_POINT_OBSCURED_BY_A_MISSION_ENTITY",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 907	 */ {true, "LOAD_ALL_MODELS_NOW"},
			/* 908	 */
			{true, "ADD_TO_OBJECT_VELOCITY", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 909	 */
			{
				true, "DRAW_SPRITE",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 910	 */
			{
				true, "DRAW_RECT",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT
				}
			},
			/* 911	 */ {true, "LOAD_SPRITE", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 912	 */ {true, "LOAD_TEXTURE_DICTIONARY", new[] {Arg.TEXT_LABEL}},
			/* 913	 */ {true, "REMOVE_TEXTURE_DICTIONARY"},
			/* 914	 */ {true, "SET_OBJECT_DYNAMIC", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 915	 */ {false, "SET_CHAR_ANIM_SPEED", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 916	 */ {true, "PLAY_MISSION_PASSED_TUNE", new[] {Arg.ANY_INT}},
			/* 917	 */
			{true, "CLEAR_AREA", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 918	 */ {true, "FREEZE_ONSCREEN_TIMER", new[] {Arg.ANY_INT}},
			/* 919	 */ {true, "SWITCH_CAR_SIREN", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 920	 */
			{
				false, "SWITCH_PED_ROADS_ON_ANGLED",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT
				}
			},
			/* 921	 */
			{
				false, "SWITCH_PED_ROADS_OFF_ANGLED",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT
				}
			},
			/* 922	 */
			{
				false, "SWITCH_ROADS_ON_ANGLED",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT
				}
			},
			/* 923	 */
			{
				false, "SWITCH_ROADS_OFF_ANGLED",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT
				}
			},
			/* 924	 */ {true, "SET_CAR_WATERTIGHT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 925	 */
			{
				true, "ADD_MOVING_PARTICLE_EFFECT",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT
				}
			},
			/* 926	 */ {true, "SET_CHAR_CANT_BE_DRAGGED_OUT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 927	 */ {true, "TURN_CAR_TO_FACE_COORD", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 928	 */ {false, "IS_CRANE_LIFTING_CAR", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 929	 */ {true, "DRAW_SPHERE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 930	 */ {true, "SET_CAR_STATUS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 931	 */ {true, "IS_CHAR_MALE", new[] {Arg.ANY_INT}},
			/* 932	 */ {true, "SCRIPT_NAME", new[] {Arg.TEXT_LABEL}},
			/* 933	 */ {false, "CHANGE_GARAGE_TYPE_WITH_CAR_MODEL", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 934	 */
			{false, "FIND_DRUG_PLANE_COORDINATES", new[] {Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 935	 */ {true, "SAVE_INT_TO_DEBUG_FILE", new[] {Arg.ANY_INT}},
			/* 936	 */ {true, "SAVE_FLOAT_TO_DEBUG_FILE", new[] {Arg.ANY_FLOAT}},
			/* 937	 */ {true, "SAVE_NEWLINE_TO_DEBUG_FILE"},
			/* 938	 */ {true, "POLICE_RADIO_MESSAGE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 939	 */ {true, "SET_CAR_STRONG", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 940	 */ {true, "REMOVE_ROUTE", new[] {Arg.ANY_INT}},
			/* 941	 */ {true, "SWITCH_RUBBISH", new[] {Arg.ANY_INT}},
			/* 942	 */
			{
				true, "REMOVE_PARTICLE_EFFECTS_IN_AREA",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 943	 */ {true, "SWITCH_STREAMING", new[] {Arg.ANY_INT}},
			/* 944	 */ {true, "IS_GARAGE_OPEN", new[] {Arg.ANY_INT}},
			/* 945	 */ {true, "IS_GARAGE_CLOSED", new[] {Arg.ANY_INT}},
			/* 946	 */ {false, "START_CATALINA_HELI"},
			/* 947	 */ {false, "CATALINA_HELI_TAKE_OFF"},
			/* 948	 */ {false, "REMOVE_CATALINA_HELI"},
			/* 949	 */ {false, "HAS_CATALINA_HELI_BEEN_SHOT_DOWN"},
			/* 950	 */
			{
				true, "SWAP_NEAREST_BUILDING_MODEL",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 951	 */ {true, "SWITCH_WORLD_PROCESSING", new[] {Arg.ANY_INT}},
			/* 952	 */ {true, "REMOVE_ALL_PLAYER_WEAPONS", new[] {Arg.ANY_INT}},
			/* 953	 */ {false, "GRAB_CATALINA_HELI", new[] {Arg.VAR_LVAR_INT}},
			/* 954	 */
			{
				true, "CLEAR_AREA_OF_CARS",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 955	 */ {true, "SET_ROTATING_GARAGE_DOOR", new[] {Arg.ANY_INT}},
			/* 956	 */
			{true, "ADD_SPHERE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_INT}},
			/* 957	 */ {true, "REMOVE_SPHERE", new[] {Arg.ANY_INT}},
			/* 958	 */ {false, "CATALINA_HELI_FLY_AWAY"},
			/* 959	 */ {true, "SET_EVERYONE_IGNORE_PLAYER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 960	 */ {true, "STORE_CAR_CHAR_IS_IN_NO_SAVE", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 961	 */ {true, "STORE_CAR_PLAYER_IS_IN_NO_SAVE", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 962	 */ {false, "IS_PHONE_DISPLAYING_MESSAGE", new[] {Arg.ANY_INT}},
			/* 963	 */ {true, "DISPLAY_ONSCREEN_TIMER_WITH_STRING", new[] {Arg.VAR_INT, Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 964	 */ {true, "DISPLAY_ONSCREEN_COUNTER_WITH_STRING", new[] {Arg.VAR_INT, Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 965	 */
			{
				true, "CREATE_RANDOM_CAR_FOR_CAR_PARK",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 966	 */ {false, "IS_COLLISION_IN_MEMORY", new[] {Arg.ANY_INT}},
			/* 967	 */ {true, "SET_WANTED_MULTIPLIER", new[] {Arg.ANY_FLOAT}},
			/* 968	 */ {true, "SET_CAMERA_IN_FRONT_OF_PLAYER"},
			/* 969	 */ {false, "IS_CAR_VISIBLY_DAMAGED", new[] {Arg.ANY_INT}},
			/* 970	 */ {true, "DOES_OBJECT_EXIST", new[] {Arg.ANY_INT}},
			/* 971	 */ {true, "LOAD_SCENE", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 972	 */ {true, "ADD_STUCK_CAR_CHECK", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 973	 */ {true, "REMOVE_STUCK_CAR_CHECK", new[] {Arg.ANY_INT}},
			/* 974	 */ {true, "IS_CAR_STUCK", new[] {Arg.ANY_INT}},
			/* 975	 */ {true, "LOAD_MISSION_AUDIO", new[] {Arg.ANY_INT, Arg.TEXT_LABEL}},
			/* 976	 */ {true, "HAS_MISSION_AUDIO_LOADED", new[] {Arg.ANY_INT}},
			/* 977	 */ {true, "PLAY_MISSION_AUDIO", new[] {Arg.ANY_INT}},
			/* 978	 */ {true, "HAS_MISSION_AUDIO_FINISHED", new[] {Arg.ANY_INT}},
			/* 979	 */
			{
				true, "GET_CLOSEST_CAR_NODE_WITH_HEADING",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT,
					Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT
				}
			},
			/* 980	 */ {true, "HAS_IMPORT_GARAGE_SLOT_BEEN_FILLED", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 981	 */ {true, "CLEAR_THIS_PRINT", new[] {Arg.TEXT_LABEL}},
			/* 982	 */ {true, "CLEAR_THIS_BIG_PRINT", new[] {Arg.TEXT_LABEL}},
			/* 983	 */
			{true, "SET_MISSION_AUDIO_POSITION", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 984	 */ {true, "ACTIVATE_SAVE_MENU"},
			/* 985	 */ {true, "HAS_SAVE_GAME_FINISHED"},
			/* 986	 */ {true, "NO_SPECIAL_CAMERA_FOR_THIS_GARAGE", new[] {Arg.ANY_INT}},
			/* 987	 */
			{false, "ADD_BLIP_FOR_PICKUP_OLD", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 988	 */ {true, "ADD_BLIP_FOR_PICKUP", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 989	 */ {false, "ADD_SPRITE_BLIP_FOR_PICKUP", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 990	 */ {true, "SET_PED_DENSITY_MULTIPLIER", new[] {Arg.ANY_FLOAT}},
			/* 991	 */ {true, "FORCE_RANDOM_PED_TYPE", new[] {Arg.ANY_INT}},
			/* 992	 */ {false, "SET_TEXT_DRAW_BEFORE_FADE", new[] {Arg.ANY_INT}},
			/* 993	 */ {true, "GET_COLLECTABLE1S_COLLECTED", new[] {Arg.VAR_LVAR_INT}},
			/* 994	 */ {true, "SET_CHAR_OBJ_LEAVE_ANY_CAR", new[] {Arg.ANY_INT}},
			/* 995	 */ {true, "SET_SPRITES_DRAW_BEFORE_FADE", new[] {Arg.ANY_INT}},
			/* 996	 */ {true, "SET_TEXT_RIGHT_JUSTIFY", new[] {Arg.ANY_INT}},
			/* 997	 */ {true, "PRINT_HELP", new[] {Arg.TEXT_LABEL}},
			/* 998	 */ {true, "CLEAR_HELP"},
			/* 999	 */ {true, "FLASH_HUD_OBJECT", new[] {Arg.ANY_INT}},
			/* 1000	 */ {false, "FLASH_RADAR_BLIP", new[] {Arg.ANY_INT}},
			/* 1001	 */ {false, "IS_CHAR_IN_CONTROL", new[] {Arg.ANY_INT}},
			/* 1002	 */ {true, "SET_GENERATE_CARS_AROUND_CAMERA", new[] {Arg.ANY_INT}},
			/* 1003	 */ {true, "CLEAR_SMALL_PRINTS"},
			/* 1004	 */ {false, "HAS_MILITARY_CRANE_COLLECTED_ALL_CARS"},
			/* 1005	 */ {true, "SET_UPSIDEDOWN_CAR_NOT_DAMAGED", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1006	 */ {true, "CAN_PLAYER_START_MISSION", new[] {Arg.ANY_INT}},
			/* 1007	 */ {true, "MAKE_PLAYER_SAFE_FOR_CUTSCENE", new[] {Arg.ANY_INT}},
			/* 1008	 */ {true, "USE_TEXT_COMMANDS", new[] {Arg.ANY_INT}},
			/* 1009	 */ {true, "SET_THREAT_FOR_PED_TYPE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1010	 */ {true, "CLEAR_THREAT_FOR_PED_TYPE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1011	 */ {true, "GET_CAR_COLOURS", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT, Arg.VAR_LVAR_INT}},
			/* 1012	 */ {true, "SET_ALL_CARS_CAN_BE_DAMAGED", new[] {Arg.ANY_INT}},
			/* 1013	 */ {true, "SET_CAR_CAN_BE_DAMAGED", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1014	 */ {false, "MAKE_PLAYER_UNSAFE", new[] {Arg.ANY_INT}},
			/* 1015	 */ {false, "LOAD_COLLISION", new[] {Arg.ANY_INT}},
			/* 1016	 */ {false, "GET_BODY_CAST_HEALTH", new[] {Arg.VAR_LVAR_INT}},
			/* 1017	 */ {true, "SET_CHARS_CHATTING", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 1018	 */ {false, "MAKE_PLAYER_SAFE", new[] {Arg.ANY_INT}},
			/* 1019	 */ {false, "SET_CAR_STAYS_IN_CURRENT_LEVEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1020	 */ {false, "SET_CHAR_STAYS_IN_CURRENT_LEVEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1021	 */ {true, "SET_DRUNK_INPUT_DELAY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1022	 */ {true, "SET_CHAR_MONEY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1023	 */ {false, "INCREASE_CHAR_MONEY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1024	 */
			{
				true, "GET_OFFSET_FROM_OBJECT_IN_WORLD_COORDS",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT,
					Arg.VAR_LVAR_FLOAT
				}
			},
			/* 1025	 */ {true, "REGISTER_LIFE_SAVED"},
			/* 1026	 */ {true, "REGISTER_CRIMINAL_CAUGHT"},
			/* 1027	 */ {true, "REGISTER_AMBULANCE_LEVEL", new[] {Arg.ANY_INT}},
			/* 1028	 */ {true, "REGISTER_FIRE_EXTINGUISHED"},
			/* 1029	 */ {true, "TURN_PHONE_ON", new[] {Arg.ANY_INT}},
			/* 1030	 */ {false, "REGISTER_LONGEST_DODO_FLIGHT", new[] {Arg.ANY_INT}},
			/* 1031	 */
			{
				true, "GET_OFFSET_FROM_CAR_IN_WORLD_COORDS",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT,
					Arg.VAR_LVAR_FLOAT
				}
			},
			/* 1032	 */ {true, "SET_TOTAL_NUMBER_OF_KILL_FRENZIES", new[] {Arg.ANY_INT}},
			/* 1033	 */ {true, "BLOW_UP_RC_BUGGY"},
			/* 1034	 */ {false, "REMOVE_CAR_FROM_CHASE", new[] {Arg.ANY_INT}},
			/* 1035	 */ {true, "IS_FRENCH_GAME"},
			/* 1036	 */ {true, "IS_GERMAN_GAME"},
			/* 1037	 */ {true, "CLEAR_MISSION_AUDIO", new[] {Arg.ANY_INT}},
			/* 1038	 */ {false, "SET_FADE_IN_AFTER_NEXT_ARREST", new[] {Arg.ANY_INT}},
			/* 1039	 */ {false, "SET_FADE_IN_AFTER_NEXT_DEATH", new[] {Arg.ANY_INT}},
			/* 1040	 */ {false, "SET_GANG_PED_MODEL_PREFERENCE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1041	 */ {true, "SET_CHAR_USE_PEDNODE_SEEK", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1042	 */ {false, "SWITCH_VEHICLE_WEAPONS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1043	 */ {false, "SET_GET_OUT_OF_JAIL_FREE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1044	 */ {true, "SET_FREE_HEALTH_CARE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1045	 */ {false, "IS_CAR_DOOR_CLOSED", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1046	 */ {true, "LOAD_AND_LAUNCH_MISSION", new[] {Arg.LABEL}},
			/* 1047	 */ {true, "LOAD_AND_LAUNCH_MISSION_INTERNAL", new[] {Arg.ANY_INT}},
			/* 1048	 */ {true, "SET_OBJECT_DRAW_LAST", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1049	 */ {true, "GET_AMMO_IN_PLAYER_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1050	 */ {false, "GET_AMMO_IN_CHAR_WEAPON", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1051	 */ {false, "REGISTER_KILL_FRENZY_PASSED"},
			/* 1052	 */ {false, "SET_CHAR_SAY", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1053	 */ {true, "SET_NEAR_CLIP", new[] {Arg.ANY_FLOAT}},
			/* 1054	 */ {true, "SET_RADIO_CHANNEL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1055	 */ {false, "OVERRIDE_HOSPITAL_LEVEL", new[] {Arg.ANY_INT}},
			/* 1056	 */ {false, "OVERRIDE_POLICE_STATION_LEVEL", new[] {Arg.ANY_INT}},
			/* 1057	 */ {false, "FORCE_RAIN", new[] {Arg.ANY_INT}},
			/* 1058	 */ {false, "DOES_GARAGE_CONTAIN_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1059	 */ {true, "SET_CAR_TRACTION", new[] {Arg.ANY_INT, Arg.ANY_FLOAT}},
			/* 1060	 */ {true, "ARE_MEASUREMENTS_IN_METRES"},
			/* 1061	 */ {true, "CONVERT_METRES_TO_FEET", new[] {Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 1062	 */
			{
				false, "MARK_ROADS_BETWEEN_LEVELS",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 1063	 */
			{
				false, "MARK_PED_ROADS_BETWEEN_LEVELS",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 1064	 */ {true, "SET_CAR_AVOID_LEVEL_TRANSITIONS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1065	 */ {false, "SET_CHAR_AVOID_LEVEL_TRANSITIONS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1066	 */ {false, "IS_THREAT_FOR_PED_TYPE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1067	 */
			{
				true, "CLEAR_AREA_OF_CHARS",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 1068	 */ {true, "SET_TOTAL_NUMBER_OF_MISSIONS", new[] {Arg.ANY_INT}},
			/* 1069	 */ {true, "CONVERT_METRES_TO_FEET_INT", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1070	 */ {true, "REGISTER_FASTEST_TIME", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1071	 */ {true, "REGISTER_HIGHEST_SCORE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1072	 */ {false, "WARP_CHAR_INTO_CAR_AS_PASSENGER", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 1073	 */ {true, "IS_CAR_PASSENGER_SEAT_FREE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1074	 */ {false, "GET_CHAR_IN_CAR_PASSENGER_SEAT", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1075	 */ {true, "SET_CHAR_IS_CHRIS_CRIMINAL", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1076	 */ {true, "START_CREDITS"},
			/* 1077	 */ {true, "STOP_CREDITS"},
			/* 1078	 */ {true, "ARE_CREDITS_FINISHED"},
			/* 1079	 */
			{
				true, "CREATE_SINGLE_PARTICLE",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_FLOAT, Arg.ANY_FLOAT
				}
			},
			/* 1080	 */ {false, "SET_CHAR_IGNORE_LEVEL_TRANSITIONS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1081	 */ {false, "GET_CHASE_CAR", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1082	 */ {false, "START_BOAT_FOAM_ANIMATION"},
			/* 1083	 */ {false, "UPDATE_BOAT_FOAM_ANIMATION", new[] {Arg.ANY_INT}},
			/* 1084	 */ {true, "SET_MUSIC_DOES_FADE", new[] {Arg.ANY_INT}},
			/* 1085	 */ {false, "SET_INTRO_IS_PLAYING", new[] {Arg.ANY_INT}},
			/* 1086	 */ {true, "SET_PLAYER_HOOKER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1087	 */ {true, "PLAY_END_OF_GAME_TUNE"},
			/* 1088	 */ {true, "STOP_END_OF_GAME_TUNE"},
			/* 1089	 */ {true, "GET_CAR_MODEL", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1090	 */ {true, "IS_PLAYER_SITTING_IN_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1091	 */ {true, "IS_PLAYER_SITTING_IN_ANY_CAR", new[] {Arg.ANY_INT}},
			/* 1092	 */ {false, "SET_SCRIPT_FIRE_AUDIO", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1093	 */ {true, "ARE_ANY_CAR_CHEATS_ACTIVATED"},
			/* 1094	 */ {true, "SET_CHAR_SUFFERS_CRITICAL_HITS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1095	 */ {false, "IS_PLAYER_LIFTING_A_PHONE", new[] {Arg.ANY_INT}},
			/* 1096	 */ {true, "IS_CHAR_SITTING_IN_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1097	 */ {true, "IS_CHAR_SITTING_IN_ANY_CAR", new[] {Arg.ANY_INT}},
			/* 1098	 */ {true, "IS_PLAYER_ON_FOOT", new[] {Arg.ANY_INT}},
			/* 1099	 */ {true, "IS_CHAR_ON_FOOT", new[] {Arg.ANY_INT}},
			/* 1100	 */ {false, "LOAD_COLLISION_WITH_SCREEN", new[] {Arg.ANY_INT}},
			/* 1101	 */ {true, "LOAD_SPLASH_SCREEN", new[] {Arg.TEXT_LABEL}},
			/* 1102	 */ {false, "SET_CAR_IGNORE_LEVEL_TRANSITIONS", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1103	 */ {false, "MAKE_CRAIGS_CAR_A_BIT_STRONGER", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1104	 */ {true, "SET_JAMES_CAR_ON_PATH_TO_PLAYER", new[] {Arg.ANY_INT}},
			/* 1105	 */ {true, "LOAD_END_OF_GAME_TUNE"},
			/* 1106	 */ {false, "ENABLE_PLAYER_CONTROL_CAMERA"},
			/* 1107	 */ {true, "SET_OBJECT_ROTATION", new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}},
			/* 1108	 */
			{true, "GET_DEBUG_CAMERA_COORDINATES", new[] {Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 1109	 */
			{
				false, "GET_DEBUG_CAMERA_FRONT_VECTOR",
				new[] {Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}
			},
			/* 1110	 */ {false, "IS_PLAYER_TARGETTING_ANY_CHAR", new[] {Arg.ANY_INT}},
			/* 1111	 */ {true, "IS_PLAYER_TARGETTING_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1112	 */ {false, "IS_PLAYER_TARGETTING_OBJECT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1113	 */ {true, "TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME", new[] {Arg.TEXT_LABEL}},
			/* 1114	 */
			{true, "DISPLAY_TEXT_WITH_NUMBER", new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.TEXT_LABEL, Arg.ANY_INT}},
			/* 1115	 */
			{
				true, "DISPLAY_TEXT_WITH_2_NUMBERS",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT}
			},
			/* 1116	 */ {true, "FAIL_CURRENT_MISSION"},
			/* 1117	 */
			{
				false, "GET_CLOSEST_OBJECT_OF_TYPE",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.VAR_LVAR_INT}
			},
			/* 1118	 */
			{
				false, "PLACE_OBJECT_RELATIVE_TO_OBJECT",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT}
			},
			/* 1119	 */ {true, "SET_ALL_OCCUPANTS_OF_CAR_LEAVE_CAR", new[] {Arg.ANY_INT}},
			/* 1120	 */ {true, "SET_INTERPOLATION_PARAMETERS", new[] {Arg.ANY_FLOAT, Arg.ANY_INT}},
			/* 1121	 */
			{
				false, "GET_CLOSEST_CAR_NODE_WITH_HEADING_TOWARDS_POINT",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT,
					Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT
				}
			},
			/* 1122	 */
			{
				false, "GET_CLOSEST_CAR_NODE_WITH_HEADING_AWAY_POINT",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.VAR_LVAR_FLOAT,
					Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT
				}
			},
			/* 1123	 */
			{true, "GET_DEBUG_CAMERA_POINT_AT", new[] {Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT, Arg.VAR_LVAR_FLOAT}},
			/* 1124	 */
			{
				true, "ATTACH_CHAR_TO_CAR",
				new[]
				{
					Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_FLOAT,
					Arg.ANY_INT
				}
			},
			/* 1125	 */ {true, "DETACH_CHAR_FROM_CAR", new[] {Arg.ANY_INT}},
			/* 1126	 */ {true, "SET_CAR_CHANGE_LANE", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1127	 */ {true, "CLEAR_CHAR_LAST_WEAPON_DAMAGE", new[] {Arg.ANY_INT}},
			/* 1128	 */ {true, "CLEAR_CAR_LAST_WEAPON_DAMAGE", new[] {Arg.ANY_INT}},
			/* 1129	 */
			{
				true, "GET_RANDOM_COP_IN_AREA",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT,
					Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT
				}
			},
			/* 1130	 */
			{
				false, "GET_RANDOM_COP_IN_ZONE",
				new[]
				{
					Arg.TEXT_LABEL, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT, Arg.VAR_LVAR_INT
				}
			},
			/* 1131	 */ {true, "SET_CHAR_OBJ_FLEE_CAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1132	 */ {true, "GET_DRIVER_OF_CAR", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1133	 */ {true, "GET_NUMBER_OF_FOLLOWERS", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1134	 */
			{
				true, "GIVE_REMOTE_CONTROLLED_MODEL_TO_PLAYER",
				new[] {Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1135	 */ {true, "GET_CURRENT_PLAYER_WEAPON", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1136	 */ {true, "GET_CURRENT_CHAR_WEAPON", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1137	 */
			{
				true, "LOCATE_CHAR_ANY_MEANS_OBJECT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1138	 */
			{
				true, "LOCATE_CHAR_ON_FOOT_OBJECT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1139	 */
			{
				false, "LOCATE_CHAR_IN_CAR_OBJECT_2D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1140	 */
			{
				false, "LOCATE_CHAR_ANY_MEANS_OBJECT_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1141	 */
			{
				false, "LOCATE_CHAR_ON_FOOT_OBJECT_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1142	 */
			{
				false, "LOCATE_CHAR_IN_CAR_OBJECT_3D",
				new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1143	 */ {true, "SET_CAR_TEMP_ACTION", new[] {Arg.ANY_INT, Arg.ANY_INT, Arg.ANY_INT}},
			/* 1144	 */ {false, "SET_CAR_HANDBRAKE_TURN_RIGHT", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1145	 */ {false, "SET_CAR_HANDBRAKE_STOP", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1146	 */ {true, "IS_CHAR_ON_ANY_BIKE", new[] {Arg.ANY_INT}},
			/* 1147	 */
			{
				false, "LOCATE_SNIPER_BULLET_2D",
				new[] {Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_INT}
			},
			/* 1148	 */
			{
				false, "LOCATE_SNIPER_BULLET_3D",
				new[]
				{
					Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT, Arg.ANY_FLOAT,
					Arg.ANY_INT
				}
			},
			/* 1149	 */ {false, "GET_NUMBER_OF_SEATS_IN_MODEL", new[] {Arg.ANY_INT, Arg.VAR_LVAR_INT}},
			/* 1150	 */ {true, "IS_PLAYER_ON_ANY_BIKE", new[] {Arg.ANY_INT}},
			/* 1151	 */ {false, "IS_CHAR_LYING_DOWN", new[] {Arg.ANY_INT}},
			/* 1152	 */ {true, "CAN_CHAR_SEE_DEAD_CHAR", new[] {Arg.ANY_INT, Arg.ANY_INT}},
			/* 1153	 */ {true, "SET_ENTER_CAR_RANGE_MULTIPLIER", new[] {Arg.ANY_FLOAT}},
			/* 1154	 */ {true, "SET_THREAT_REACTION_RANGE_MULTIPLIER", new[] {Arg.ANY_FLOAT}},
		};
	}
}