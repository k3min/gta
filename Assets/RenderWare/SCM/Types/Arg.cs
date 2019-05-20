namespace RenderWare.SCM.Types
{
	public enum Arg : byte
	{
		NONE,
		INT,
		FLOAT,
		VAR_INT,
		VAR_FLOAT,
		VAR_INT_OPT,
		VAR_FLOAT_OPT,
		LVAR_INT,
		LVAR_FLOAT,
		LVAR_INT_OPT,
		LVAR_FLOAT_OPT,
		MULTI_OPT,
		ANY_INT,
		ANY_FLOAT,
		VAR_LVAR_INT,
		VAR_LVAR_FLOAT,
		LABEL,
		PAD17,
		TEXT_LABEL,
		VAR_TEXT_LABEL,
		LVAR_TEXT_LABEL,
		VAR_TEXT_LABEL_OPT,
		LVAR_TEXT_LABEL_OPT,
		TEXT_LABEL32,
		PAD24
	}
}