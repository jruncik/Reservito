/*
BEGIN;
CREATE DATABASE "TiskarnaVosahlo"
  WITH ENCODING='UTF8'
       OWNER=postgres
       CONNECTION LIMIT=-1; 
COMMIT;
*/
	      
BEGIN;
DROP TABLE IF EXISTS public.users CASCADE;
DROP TABLE IF EXISTS public.rights CASCADE;
DROP TABLE IF EXISTS public.paperformats CASCADE;
DROP TABLE IF EXISTS public.contactpersons CASCADE;
DROP TABLE IF EXISTS public.finishingjob CASCADE;
DROP TABLE IF EXISTS public.papertype CASCADE;
DROP TABLE IF EXISTS public.proofsheet CASCADE;
DROP TABLE IF EXISTS public.order CASCADE;
DROP TABLE IF EXISTS public.implementation CASCADE;

DROP TABLE IF EXISTS public.bbb CASCADE;
DROP TABLE IF EXISTS public.aaa CASCADE;


CREATE TABLE public.aaa (
  id uuid NOT NULL,
  name character varying,
  fk_bbb uuid NOT NULL,
  CONSTRAINT id_aaa_pkey PRIMARY KEY (id)
)
WITH (OIDS=FALSE);

CREATE TABLE public.bbb (
  id uuid NOT NULL,
  age integer,
  CONSTRAINT id_bbb_pkey PRIMARY KEY (id)
)
WITH (OIDS=FALSE);

CREATE TABLE public.users (
  id UUID NOT NULL,
  username VARCHAR(64) NOT NULL,
  password VARCHAR NOT NULL,
  CONSTRAINT users_pkey PRIMARY KEY(id),
  CONSTRAINT users_username_key UNIQUE(username)
) 
WITH (oids = false);

CREATE TABLE public.rights (
  id UUID NOT NULL,
  fk_user UUID NOT NULL,
  rights INTEGER DEFAULT 0 NOT NULL,
  CONSTRAINT rights_fk_user_key UNIQUE(fk_user),
  CONSTRAINT rights_pkey PRIMARY KEY(id),
  CONSTRAINT rights_fk FOREIGN KEY (fk_user)
    REFERENCES public.users(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
    NOT DEFERRABLE
) 
WITH (oids = false);

CREATE TABLE public.paperformats (
  id UUID NOT NULL,
  name VARCHAR(128) NOT NULL,
  width INTEGER NOT NULL,
  height INTEGER NOT NULL,
  isbuildin BOOLEAN NOT NULL,
  CONSTRAINT paper_format_name_key UNIQUE(name),
  CONSTRAINT paper_format_pkey PRIMARY KEY(id)
) 
WITH (oids = false);

CREATE TABLE public.contactpersons (
  id UUID NOT NULL,
  firstname VARCHAR(128),
  lastname VARCHAR(128),
  phonenumber VARCHAR(32),
  email VARCHAR(256),
  CONSTRAINT contactperson_pkey PRIMARY KEY(id)
) 
WITH (oids = false);

CREATE TABLE public.finishingjob (
  id UUID NOT NULL,
  flags INTEGER NOT NULL,
  other VARCHAR(511),
  CONSTRAINT finishingjob_pkey PRIMARY KEY(id)
) 
WITH (oids = false);

CREATE TABLE public.papertype (
  id UUID NOT NULL,
  color INTEGER NOT NULL,
  type VARCHAR(256),
  CONSTRAINT papertype_pkey PRIMARY KEY(id)
) 
WITH (oids = false);

CREATE TABLE public.proofsheet (
  id UUID NOT NULL,
  time TIMESTAMP(0) WITHOUT TIME ZONE NOT NULL,
  passed BOOLEAN NOT NULL,
  CONSTRAINT proofsheet_pkey PRIMARY KEY(id)
) 
WITH (oids = false);

CREATE TABLE "order"
(
  id uuid NOT NULL,
  fk_contactperson uuid NOT NULL,
  ordertype character varying(256) NOT NULL,
  ordertime timestamp(0) without time zone NOT NULL,
  finishtime timestamp(0) without time zone NOT NULL,
  priority integer NOT NULL,
  fk_format uuid NOT NULL,
  pagecount integer,
  count integer NOT NULL,
  quirecount integer,
  printcolor integer,
  fk_papertype uuid,
  fk_implementation uuid,
  isspecimensupplied boolean,
  ispagecompositionsupplied boolean,
  fk_proofsheet uuid,
  fk_finishingjob uuid,
  details character varying(512),
  CONSTRAINT order_pkey PRIMARY KEY (id)
)
WITH (oids = false);
COMMIT;

CREATE TABLE implementation (
  id uuid NOT NULL,
  CONSTRAINT implementation_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);

BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A0', 841, 1189, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A1', 594, 841, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A2', 420, 594, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A3', 297, 420, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A4', 210, 297, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A5', 148, 210, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A6', 105, 148, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A7', 74, 105, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A8', 52, 74, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A9', 37, 52, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'A10', 26, 37, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B0', 1000, 1414, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B1', 707, 1000, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B2', 500, 707, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B3', 353, 500, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B4', 250, 353, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B5', 176, 250, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B6', 125, 176, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B7', 88, 125, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B8', 62, 88, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B9', 44, 62, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'B10', 31, 44, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C0', 917, 1297, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C1', 648, 917, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C2', 458, 648, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C3', 324, 458, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C4', 229, 324, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C5', 162, 229, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C6', 114, 162, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C7', 81, 114, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C8', 57, 81, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C9', 40, 57, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'C10', 28, 40, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'RA0', 860, 1220, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'RA1', 610, 860, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'RA2', 430, 610, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'RA3', 305, 430, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'RA4', 215, 305, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'SRA0', 900, 1280, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'SRA1', 640, 900, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'SRA2', 450, 640, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'SRA3', 320, 450, TRUE);
COMMIT;
BEGIN;
INSERT INTO paperformats VALUES(uuid_generate_v4(), 'SRA4', 225, 320, TRUE);
COMMIT;
