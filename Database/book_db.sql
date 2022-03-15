--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: class; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.class (
    id bigint NOT NULL,
    capacity integer NOT NULL
);


ALTER TABLE public.class OWNER TO postgres;

--
-- Name: class_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.class_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.class_id_seq OWNER TO postgres;

--
-- Name: class_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.class_id_seq OWNED BY public.class.id;


--
-- Name: student; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student (
    id bigint NOT NULL,
    name character varying(50) NOT NULL,
    dob date NOT NULL,
    address character varying(255) NOT NULL,
    gender character varying(50) NOT NULL,
    mobile bigint NOT NULL,
    class_id integer NOT NULL
);


ALTER TABLE public.student OWNER TO postgres;

--
-- Name: student_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.student_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.student_id_seq OWNER TO postgres;

--
-- Name: student_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.student_id_seq OWNED BY public.student.id;


--
-- Name: student_subject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student_subject (
    student_id integer,
    subject_id integer
);


ALTER TABLE public.student_subject OWNER TO postgres;

--
-- Name: student_teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student_teacher (
    student_id integer,
    teacher_id integer
);


ALTER TABLE public.student_teacher OWNER TO postgres;

--
-- Name: subject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subject (
    id bigint NOT NULL,
    name character varying(50) NOT NULL
);


ALTER TABLE public.subject OWNER TO postgres;

--
-- Name: subject_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subject_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subject_id_seq OWNER TO postgres;

--
-- Name: subject_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subject_id_seq OWNED BY public.subject.id;


--
-- Name: teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teacher (
    id bigint NOT NULL,
    name character varying(50) NOT NULL,
    gender character varying(50) NOT NULL,
    mobile bigint NOT NULL,
    subject_id integer NOT NULL
);


ALTER TABLE public.teacher OWNER TO postgres;

--
-- Name: teacher_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.teacher_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.teacher_id_seq OWNER TO postgres;

--
-- Name: teacher_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.teacher_id_seq OWNED BY public.teacher.id;


--
-- Name: class id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.class ALTER COLUMN id SET DEFAULT nextval('public.class_id_seq'::regclass);


--
-- Name: student id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student ALTER COLUMN id SET DEFAULT nextval('public.student_id_seq'::regclass);


--
-- Name: subject id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject ALTER COLUMN id SET DEFAULT nextval('public.subject_id_seq'::regclass);


--
-- Name: teacher id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher ALTER COLUMN id SET DEFAULT nextval('public.teacher_id_seq'::regclass);


--
-- Data for Name: class; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.class (id, capacity) FROM stdin;
1	30
\.


--
-- Data for Name: student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student (id, name, dob, address, gender, mobile, class_id) FROM stdin;
1	sandhya	1999-09-09	hyd	female	9876543210	1
7	str	2022-03-14	str	male	9876543218	1
\.


--
-- Data for Name: student_subject; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student_subject (student_id, subject_id) FROM stdin;
1	1
\.


--
-- Data for Name: student_teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student_teacher (student_id, teacher_id) FROM stdin;
1	1
\.


--
-- Data for Name: subject; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.subject (id, name) FROM stdin;
1	C
2	C
3	c
4	C
5	C
6	C
\.


--
-- Data for Name: teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teacher (id, name, gender, mobile, subject_id) FROM stdin;
1	suppu	female	9876545432	1
\.


--
-- Name: class_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.class_id_seq', 1, true);


--
-- Name: student_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.student_id_seq', 7, true);


--
-- Name: subject_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subject_id_seq', 6, true);


--
-- Name: teacher_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.teacher_id_seq', 1, true);


--
-- Name: class class_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.class
    ADD CONSTRAINT class_pkey PRIMARY KEY (id);


--
-- Name: student student_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_pkey PRIMARY KEY (id);


--
-- Name: subject subject_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject
    ADD CONSTRAINT subject_pkey PRIMARY KEY (id);


--
-- Name: teacher teacher_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_pkey PRIMARY KEY (id);


--
-- Name: student class_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT class_id FOREIGN KEY (class_id) REFERENCES public.class(id) NOT VALID;


--
-- Name: student_subject student_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_subject
    ADD CONSTRAINT student_id FOREIGN KEY (student_id) REFERENCES public.student(id);


--
-- Name: student_teacher student_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_teacher
    ADD CONSTRAINT student_id FOREIGN KEY (student_id) REFERENCES public.student(id);


--
-- Name: student_subject subject_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_subject
    ADD CONSTRAINT subject_id FOREIGN KEY (subject_id) REFERENCES public.subject(id) NOT VALID;


--
-- Name: teacher subject_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT subject_id FOREIGN KEY (subject_id) REFERENCES public.subject(id) NOT VALID;


--
-- Name: student_teacher teacher_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_teacher
    ADD CONSTRAINT teacher_id FOREIGN KEY (teacher_id) REFERENCES public.teacher(id) NOT VALID;


--
-- PostgreSQL database dump complete
--

