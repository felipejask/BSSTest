PGDMP     ,    3                w            Agenda    11.5    11.5     �
           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false                        0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false                       1262    16393    Agenda    DATABASE     �   CREATE DATABASE "Agenda" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Portuguese_Brazil.1252' LC_CTYPE = 'Portuguese_Brazil.1252';
    DROP DATABASE "Agenda";
             postgres    false            �            1259    16536    eventos    TABLE     �   CREATE TABLE public.eventos (
    id integer NOT NULL,
    datacriacao date DEFAULT CURRENT_DATE NOT NULL,
    dataentrega date NOT NULL,
    titulo character varying NOT NULL,
    descricao character varying,
    flagpronto "char" NOT NULL
);
    DROP TABLE public.eventos;
       public         postgres    false            �            1259    16534    eventos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.eventos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.eventos_id_seq;
       public       postgres    false    197                       0    0    eventos_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.eventos_id_seq OWNED BY public.eventos.id;
            public       postgres    false    196            ~
           2604    16539 
   eventos id    DEFAULT     h   ALTER TABLE ONLY public.eventos ALTER COLUMN id SET DEFAULT nextval('public.eventos_id_seq'::regclass);
 9   ALTER TABLE public.eventos ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    197    196    197            �
          0    16536    eventos 
   TABLE DATA               ^   COPY public.eventos (id, datacriacao, dataentrega, titulo, descricao, flagpronto) FROM stdin;
    public       postgres    false    197   �
                  0    0    eventos_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.eventos_id_seq', 2, true);
            public       postgres    false    196            �
           2606    16545    eventos eventos_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.eventos
    ADD CONSTRAINT eventos_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.eventos DROP CONSTRAINT eventos_pkey;
       public         postgres    false    197            �
   X   x�3�420��5��5�1-t�<CΒ̒Ҝ|����TΔ�����Dߍː����P�����RS2KS�����p�p��qqq [�%�     