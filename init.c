char* my_strrchr(char* param_1, char param_2)
{
int i = 0, op = 0;

	while (op == 0)
	{
		if ((*(param_1 + i) == '\0') && (*(param_2 + i) == '\0'))
			break;
		op = *(param_1 + i) - *(param_2 + i);
		i++;
	}

	return (op);
}