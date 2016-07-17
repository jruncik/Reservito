CREATE DATABASE "TiskarnaVosahlo"
  WITH ENCODING='UTF8'
       OWNER=postgres
       CONNECTION LIMIT=-1;
	   
COMMIT;
	   
CREATE TABLE public.users (
  id UUID NOT NULL,
  username VARCHAR(64) NOT NULL,
  password VARCHAR NOT NULL,
  CONSTRAINT users_pkey PRIMARY KEY(id),
  CONSTRAINT users_username_key UNIQUE(username)
) 
WITH (oids = false);
COMMIT;

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
COMMIT;

CREATE TABLE public.paperformats (
  id UUID NOT NULL,
  name VARCHAR(128) NOT NULL,
  width INTEGER NOT NULL,
  height INTEGER NOT NULL,
  CONSTRAINT paper_format_name_key UNIQUE(name),
  CONSTRAINT paper_format_pkey PRIMARY KEY(id)
) 
WITH (oids = false);
COMMIT;

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

CREATE TABLE public.finishingjob (
  id UUID NOT NULL,
  flags INTEGER NOT NULL,
  other VARCHAR(511),
  CONSTRAINT finishingjob_pkey PRIMARY KEY(id)
) 
WITH (oids = false);
COMMIT;

CREATE TABLE "order"
(
  id uuid NOT NULL,
  ordertype character varying(256) NOT NULL,
  ordertime date NOT NULL,
  CONSTRAINT orders_pkey PRIMARY KEY (id)
)
WITH (oids=false);
COMMIT;

CREATE TABLE public.papertype (
  id UUID NOT NULL,
  color INTEGER NOT NULL,
  type VARCHAR(256),
  PRIMARY KEY(id)
) 
WITH (oids = false);
COMMIT;

CREATE TABLE public."order" (
  id UUID NOT NULL,
  contactperson UUID NOT NULL,
  ordertype VARCHAR(256) NOT NULL,
  ordertime TIMESTAMP(0) WITHOUT TIME ZONE NOT NULL,
  finishtime TIMESTAMP(0) WITHOUT TIME ZONE NOT NULL,
  priority INTEGER NOT NULL,
  format UUID NOT NULL,
  pagecount INTEGER,
  count INTEGER NOT NULL,
  quirecount INTEGER,
  printcolor INTEGER,
  papertype UUID,
  implementation UUID,
  isspecimensupplied BOOLEAN,
  ispagecompositionsupplied BOOLEAN,
  proofsheet UUID,
  finishingjob UUID,
  details VARCHAR(512),
  CONSTRAINT order_pkey PRIMARY KEY(id)
) 
WITH (oids = false);
COMMIT;
