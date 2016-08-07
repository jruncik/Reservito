BEGIN;
DROP TABLE IF EXISTS public.users CASCADE;
DROP TABLE IF EXISTS public.rights CASCADE;
DROP TABLE IF EXISTS public.workouts CASCADE;
DROP TABLE IF EXISTS public.workouts_to_user CASCADE;
COMMIT;

BEGIN;
CREATE TABLE public.users (
  id UUID NOT NULL,
  username VARCHAR(64) NOT NULL,
  password VARCHAR NOT NULL,
  firstname VARCHAR(128) NOT NULL,
  lastname VARCHAR(128) NOT NULL,
  phonenumber VARCHAR(32),
  email VARCHAR(256) NOT NULL,
  active boolean NOT NULL,

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

CREATE TABLE public.workouts (
  id UUID NOT NULL,
  time TIMESTAMP(0) WITHOUT TIME ZONE NOT NULL,
  capacity INTEGER DEFAULT 0 NOT NULL,
  price INTEGER DEFAULT 0 NOT NULL,

  CONSTRAINT id_workouts_pkey PRIMARY KEY (id)
)
WITH (oids = false);

CREATE TABLE public.workouts_to_user (
  id UUID NOT NULL,
  fk_workout UUID NOT NULL,
  fk_user UUID NOT NULL,

  CONSTRAINT id_workouts_to_user_pkey PRIMARY KEY (id),

  CONSTRAINT fk_workout_coonstrain FOREIGN KEY (fk_workout)
    REFERENCES public.workouts(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
    NOT DEFERRABLE,

  CONSTRAINT fk_user_coonstrain FOREIGN KEY (fk_user)
    REFERENCES public.users(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
    NOT DEFERRABLE
)
WITH (oids = false);

COMMIT;
