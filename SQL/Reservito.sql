/*
BEGIN;
CREATE DATABASE "reservito"
  WITH ENCODING='UTF8'
       OWNER=remaster
       CONNECTION LIMIT=-1; 
COMMIT;
*/
	      
BEGIN;
DROP TABLE IF EXISTS public.users CASCADE;
DROP TABLE IF EXISTS public.rights CASCADE;
DROP TABLE IF EXISTS public.contactpersons CASCADE;
COMMIT;

BEGIN;
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

CREATE TABLE public.contactpersons (
  id UUID NOT NULL,
  firstname VARCHAR(128),
  lastname VARCHAR(128),
  phonenumber VARCHAR(32),
  email VARCHAR(256),
  CONSTRAINT contactperson_pkey PRIMARY KEY(id)
) 
WITH (oids = false);

COMMIT;