BEGIN;
DROP TABLE IF EXISTS public.users CASCADE;
DROP TABLE IF EXISTS public.rights CASCADE;
DROP TABLE IF EXISTS public.workouts CASCADE;
DROP TABLE IF EXISTS public.workouts_to_user CASCADE;
DROP TABLE IF EXISTS public.workouts_and_users CASCADE;
DROP TABLE IF EXISTS public.workout_info CASCADE;
DROP TABLE IF EXISTS public.courses CASCADE;
DROP TABLE IF EXISTS public.courses_and_workouts CASCADE;
COMMIT;

BEGIN;
CREATE TABLE public.users (
  id UUID NOT NULL,
  username VARCHAR(256) NOT NULL,
  password VARCHAR(256) NOT NULL,
  firstname VARCHAR(256) NOT NULL,
  lastname VARCHAR(256) NOT NULL,
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
  fk_workout_info UUID,

  CONSTRAINT id_workouts_pkey PRIMARY KEY (id)
)
WITH (oids = false);

CREATE TABLE public.workouts_and_users (
  fk_workout UUID NOT NULL,
  fk_user UUID NOT NULL,

  CONSTRAINT workouts_and_users_pkey PRIMARY KEY (fk_workout, fk_user),

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

CREATE TABLE public.workout_info
(
  id uuid NOT NULL,
  price integer NOT NULL,
  capacity integer NOT NULL,
  length integer NOT NULL,

  CONSTRAINT id_workout_info_pkey PRIMARY KEY (id)
)
WITH (oids = false);

CREATE TABLE public.courses
(
  id uuid NOT NULL,
  name VARCHAR(256) NOT NULL,
  fk_coach UUID,
  fk_workout_info UUID,

  CONSTRAINT id_course_pkey PRIMARY KEY (id)
)
WITH (oids = false);

CREATE TABLE public.courses_and_workouts
(
  fk_course UUID NOT NULL,
  fk_workout UUID NOT NULL,

  CONSTRAINT workouts_to_user_pkey PRIMARY KEY (fk_workout, fk_course),

  CONSTRAINT fk_workout_coonstrain FOREIGN KEY (fk_workout)
    REFERENCES public.workouts(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
    NOT DEFERRABLE,

  CONSTRAINT fk_course_coonstrain FOREIGN KEY (fk_course)
    REFERENCES public.courses(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
    NOT DEFERRABLE
)
WITH (oids = false);

COMMIT;
