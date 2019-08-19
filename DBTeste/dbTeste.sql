INSERT INTO public.eventos(
	id, "datacriacao", "dataentrega", titulo, descricao, "flagpronto")
	VALUES (1, CURRENT_DATE, (to_date('01/09/2019','dd/mm/yyyy')), 'Teste', 'Teste descricao', false);