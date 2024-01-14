/*==============================================================*/
/* DBMS name:      ORACLE Version 19c                           */
/* Created on:     13.01.2024 13:52:40                          */
/*==============================================================*/


drop procedure GENERATESALT
/

drop procedure INSERTINGREDIENT
/

alter table APPOINTMENT
   drop constraint FK_APPOINTM_TRAINING__TRAINING
/

alter table EMPLOYEE
   drop constraint FK_EMPLOYEE_IS_EMPLOY_USER
/

alter table EXERCISE
   drop constraint FK_EXERCISE_SPORT_EXE_SPORT
/

alter table EXERCISEUNIT
   drop constraint FK_EXERCISE_UNIT_EXER_EXERCISE
/

alter table INGREDIENT
   drop constraint FK_INGREDIE_INGREDIEN_QUANTITY
/

alter table MANAGES_SPORT
   drop constraint FK_MANAGES__MANAGES_S_SPORT
/

alter table MANAGES_SPORT
   drop constraint FK_MANAGES__MANAGES_S_EMPLOYEE
/

alter table PLANTRAININGUNIT
   drop constraint FK_PLANTRAI_PLAN_UNIT_TRAINING
/

alter table PLAN_UNIT_UNIT
   drop constraint FK_PLAN_UNI_PLAN_UNIT_PLANTRAI
/

alter table PLAN_UNIT_UNIT
   drop constraint FK_PLAN_UNI_PLAN_UNIT_TRAINING
/

alter table QUANTITYPRICE
   drop constraint FK_QUANTITY_INGREDIEN_INGREDIE
/

alter table RECIPE
   drop constraint FK_RECIPE_RECIPE_CA_RECIPECA
/

alter table RECIPE
   drop constraint FK_RECIPE_RECIPE_CR_USER
/

alter table RECIPEINGREDIENT
   drop constraint FK_RECIPEIN_QUANTITY__INGREDIE
/

alter table RECIPEINGREDIENT
   drop constraint FK_RECIPEIN_RECIPE_IN_RECIPE
/

alter table RECIPE_APPOINTMENT
   drop constraint FK_RECIPE_A_RECIPE_AP_RECIPE
/

alter table RECIPE_APPOINTMENT
   drop constraint FK_RECIPE_A_RECIPE_AP_APPOINTM
/

alter table TRACK
   drop constraint FK_TRACK_USER_TRAC_USER
/

alter table TRAININGPLAN
   drop constraint FK_TRAINING_PLAN_CREA_EMPLOYEE
/

alter table TRAININGPLAN
   drop constraint FK_TRAINING_PLAN_SPOR_SPORT
/

alter table TRAINING_UNIT_UNIT
   drop constraint FK_TRAINING_TRAINING__EXERCISE
/

alter table TRAINING_UNIT_UNIT
   drop constraint FK_TRAINING_TRAINING__TRAINING
/

alter table "USER"
   drop constraint FK_USER_IS_EMPLOY_EMPLOYEE
/

alter table "USER"
   drop constraint FK_USER_USER_FITN_FITNESSL
/

alter table USER_APPOINTMENT
   drop constraint FK_USER_APP_USER_APPO_APPOINTM
/

alter table USER_APPOINTMENT
   drop constraint FK_USER_APP_USER_APPO_USER
/

alter table USER_PLAN
   drop constraint FK_USER_PLA_USER_PLAN_TRAINING
/

alter table USER_PLAN
   drop constraint FK_USER_PLA_USER_PLAN_USER
/

alter table USER_SAVED_RECIPES
   drop constraint FK_USER_SAV_USER_SAVE_RECIPE
/

alter table USER_SAVED_RECIPES
   drop constraint FK_USER_SAV_USER_SAVE_USER
/

drop index TRAINING_UNIT_APPOINTMENT_FK
/

drop table APPOINTMENT cascade constraints
/

drop index IS_EMPLOYEE2_FK
/

drop table EMPLOYEE cascade constraints
/

drop index SPORT_EXERCISE_FK
/

drop table EXERCISE cascade constraints
/

drop index UNIT_EXERCISE_FK
/

drop table EXERCISEUNIT cascade constraints
/

drop table FITNESSLEVEL cascade constraints
/

drop index INGREDIENT_PRICE2_FK
/

drop table INGREDIENT cascade constraints
/

drop index MANAGES_SPORT2_FK
/

drop index MANAGES_SPORT_FK
/

drop table MANAGES_SPORT cascade constraints
/

drop index PLAN_UNIT_FK
/

drop table PLANTRAININGUNIT cascade constraints
/

drop index PLAN_UNIT_UNIT2_FK
/

drop index PLAN_UNIT_UNIT_FK
/

drop table PLAN_UNIT_UNIT cascade constraints
/

drop index INGREDIENT_PRICE_FK
/

drop table QUANTITYPRICE cascade constraints
/

drop index RECIPE_CATEGORY_FK
/

drop index RECIPE_CREATOR_FK
/

drop table RECIPE cascade constraints
/

drop table RECIPECATEGORY cascade constraints
/

drop index QUANTITY_OF_INGREDIENT_FK
/

drop index RECIPE_INGREDIENTS_FK
/

drop table RECIPEINGREDIENT cascade constraints
/

drop index RECIPE_APPOINTMENT2_FK
/

drop index RECIPE_APPOINTMENT_FK
/

drop table RECIPE_APPOINTMENT cascade constraints
/

drop table SPORT cascade constraints
/

drop index USER_TRACK_FK
/

drop table TRACK cascade constraints
/

drop index PLAN_SPORTART_FK
/

drop index PLAN_CREATED_BY_FK
/

drop table TRAININGPLAN cascade constraints
/

drop table TRAININGUNIT cascade constraints
/

drop index TRAINING_UNIT_UNIT2_FK
/

drop index TRAINING_UNIT_UNIT_FK
/

drop table TRAINING_UNIT_UNIT cascade constraints
/

drop index USER_FITNESS_LEVEL_FK
/

drop index IS_EMPLOYEE_FK
/

drop table "USER" cascade constraints
/

drop index USER_APPOINTMENT2_FK
/

drop index USER_APPOINTMENT_FK
/

drop table USER_APPOINTMENT cascade constraints
/

drop index USER_PLAN2_FK
/

drop index USER_PLAN_FK
/

drop table USER_PLAN cascade constraints
/

drop index USER_SAVED_RECIPES2_FK
/

drop index USER_SAVED_RECIPES_FK
/

drop table USER_SAVED_RECIPES cascade constraints
/

/*==============================================================*/
/* Table: APPOINTMENT                                           */
/*==============================================================*/
create table APPOINTMENT (
   APPOINTMENTID        NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   TRAININGUNITID       NUMBER(6),
   "DATE"               DATE                  not null,
   STATUS               NUMBER(1)            default 0  not null
      constraint CKC_STATUS_APPOINTM check (STATUS between 0 and 1 and STATUS in (0,1)),
   constraint PK_APPOINTMENT primary key (APPOINTMENTID)
)
/

/*==============================================================*/
/* Index: TRAINING_UNIT_APPOINTMENT_FK                          */
/*==============================================================*/
create index TRAINING_UNIT_APPOINTMENT_FK on APPOINTMENT (
   TRAININGUNITID ASC
)
/

/*==============================================================*/
/* Table: EMPLOYEE                                              */
/*==============================================================*/
create table EMPLOYEE (
   EMPLOYEEID           NUMBER(3)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   EMAIL                VARCHAR2(128)         not null,
   AUTHORIZATION        NUMBER(1)            default 0  not null
      constraint CKC_AUTHORIZATION_EMPLOYEE check (AUTHORIZATION between 0 and 1 and AUTHORIZATION in (0,1)),
   constraint PK_EMPLOYEE primary key (EMPLOYEEID)
)
/

/*==============================================================*/
/* Index: IS_EMPLOYEE2_FK                                       */
/*==============================================================*/
create index IS_EMPLOYEE2_FK on EMPLOYEE (
   EMAIL ASC
)
/

/*==============================================================*/
/* Table: EXERCISE                                              */
/*==============================================================*/
create table EXERCISE (
   EXERCISEID           NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   SPORTID              NUMBER(4)             not null,
   NAME                 VARCHAR2(128)         not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   EXERCISETYPE         NUMBER(1)             not null
      constraint CKC_EXERCISETYPE_EXERCISE check (EXERCISETYPE between 0 and 2 and EXERCISETYPE in (0,1,2)),
   constraint PK_EXERCISE primary key (EXERCISEID)
)
/

/*==============================================================*/
/* Index: SPORT_EXERCISE_FK                                     */
/*==============================================================*/
create index SPORT_EXERCISE_FK on EXERCISE (
   SPORTID ASC
)
/

/*==============================================================*/
/* Table: EXERCISEUNIT                                          */
/*==============================================================*/
create table EXERCISEUNIT (
   EXERCISEUNITID       NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   EXERCISEID           NUMBER(6)             not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   EXERCISEDIFFICULTY   NUMBER(1)             not null
      constraint CKC_EXERCISEDIFFICULT_EXERCISE check (EXERCISEDIFFICULTY between 0 and 2 and EXERCISEDIFFICULTY in (0,1,2)),
   REPETITIONS          NUMBER(4)             not null,
   constraint PK_EXERCISEUNIT primary key (EXERCISEUNITID)
)
/

/*==============================================================*/
/* Index: UNIT_EXERCISE_FK                                      */
/*==============================================================*/
create index UNIT_EXERCISE_FK on EXERCISEUNIT (
   EXERCISEID ASC
)
/

/*==============================================================*/
/* Table: FITNESSLEVEL                                          */
/*==============================================================*/
create table FITNESSLEVEL (
   FITNESSLEVELID       NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   FITNESSSTATUS        VARCHAR2(256)         not null,
   constraint PK_FITNESSLEVEL primary key (FITNESSLEVELID)
)
/

/*==============================================================*/
/* Table: INGREDIENT                                            */
/*==============================================================*/
create table INGREDIENT (
   INGREDIENTNAME       VARCHAR2(64)          not null,
   QUA_INGREDIENTNAME   VARCHAR2(64),
   QUANTITYPRICEID      NUMBER(6),
   FOODCATEGORY         NUMBER(1)             not null
      constraint CKC_FOODCATEGORY_INGREDIE check (FOODCATEGORY between 0 and 2 and FOODCATEGORY in (0,1,2)),
   CALORIES             NUMBER(4)             not null,
   PROTEIN              NUMBER(3),
   FAT                  NUMBER(3),
   CARBONHYDRATES       NUMBER(3),
   constraint PK_INGREDIENT primary key (INGREDIENTNAME)
)
/

/*==============================================================*/
/* Index: INGREDIENT_PRICE2_FK                                  */
/*==============================================================*/
create index INGREDIENT_PRICE2_FK on INGREDIENT (
   QUA_INGREDIENTNAME ASC,
   QUANTITYPRICEID ASC
)
/

/*==============================================================*/
/* Table: MANAGES_SPORT                                         */
/*==============================================================*/
create table MANAGES_SPORT (
   SPORTID              NUMBER(4)             not null,
   EMPLOYEEID           NUMBER(3)             not null,
   constraint PK_MANAGES_SPORT primary key (SPORTID, EMPLOYEEID)
)
/

/*==============================================================*/
/* Index: MANAGES_SPORT_FK                                      */
/*==============================================================*/
create index MANAGES_SPORT_FK on MANAGES_SPORT (
   SPORTID ASC
)
/

/*==============================================================*/
/* Index: MANAGES_SPORT2_FK                                     */
/*==============================================================*/
create index MANAGES_SPORT2_FK on MANAGES_SPORT (
   EMPLOYEEID ASC
)
/

/*==============================================================*/
/* Table: PLANTRAININGUNIT                                      */
/*==============================================================*/
create table PLANTRAININGUNIT (
   TRAININGPLANID       NUMBER(6)             not null,
   PLANTRAININGUNITID   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   DESCRIPTION          VARCHAR2(1024),
   WEEKDAY              NUMBER(1)             not null
      constraint CKC_WEEKDAY_PLANTRAI check (WEEKDAY between 0 and 6 and WEEKDAY in (0,1,2,3,4,5,6)),
   constraint PK_PLANTRAININGUNIT primary key (TRAININGPLANID, PLANTRAININGUNITID)
)
/

/*==============================================================*/
/* Index: PLAN_UNIT_FK                                          */
/*==============================================================*/
create index PLAN_UNIT_FK on PLANTRAININGUNIT (
   TRAININGPLANID ASC
)
/

/*==============================================================*/
/* Table: PLAN_UNIT_UNIT                                        */
/*==============================================================*/
create table PLAN_UNIT_UNIT (
   TRAININGPLANID       NUMBER(6)             not null,
   PLANTRAININGUNITID   NUMBER(6)             not null,
   TRAININGUNITID       NUMBER(6)             not null,
   constraint PK_PLAN_UNIT_UNIT primary key (TRAININGPLANID, PLANTRAININGUNITID, TRAININGUNITID)
)
/

/*==============================================================*/
/* Index: PLAN_UNIT_UNIT_FK                                     */
/*==============================================================*/
create index PLAN_UNIT_UNIT_FK on PLAN_UNIT_UNIT (
   TRAININGPLANID ASC,
   PLANTRAININGUNITID ASC
)
/

/*==============================================================*/
/* Index: PLAN_UNIT_UNIT2_FK                                    */
/*==============================================================*/
create index PLAN_UNIT_UNIT2_FK on PLAN_UNIT_UNIT (
   TRAININGUNITID ASC
)
/

/*==============================================================*/
/* Table: QUANTITYPRICE                                         */
/*==============================================================*/
create table QUANTITYPRICE (
   INGREDIENTNAME       VARCHAR2(64)          not null,
   QUANTITYPRICEID      NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   QUANTITYUNIT         NUMBER(1)             not null
      constraint CKC_QUANTITYUNIT_QUANTITY check (QUANTITYUNIT between 0 and 3 and QUANTITYUNIT in (0,1,2,3)),
   PRICELOWER           NUMBER(4,2)           not null,
   PRICEUPPER           NUMBER(4,2)           not null,
   constraint PK_QUANTITYPRICE primary key (INGREDIENTNAME, QUANTITYPRICEID)
)
/

/*==============================================================*/
/* Index: INGREDIENT_PRICE_FK                                   */
/*==============================================================*/
create index INGREDIENT_PRICE_FK on QUANTITYPRICE (
   INGREDIENTNAME ASC
)
/

/*==============================================================*/
/* Table: RECIPE                                                */
/*==============================================================*/
create table RECIPE (
   RECIPEID             NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   RECIPECATEGORYID     NUMBER(6)             not null,
   EMAIL                VARCHAR2(128)         not null,
   NAME                 VARCHAR2(128)         not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   INSTRUCTIONS         CLOB                  not null,
   VISIBILITY           NUMBER(1)            default 0  not null
      constraint CKC_VISIBILITY_RECIPE check (VISIBILITY between 0 and 2 and VISIBILITY in (0,1,2)),
   constraint PK_RECIPE primary key (RECIPEID)
)
/

/*==============================================================*/
/* Index: RECIPE_CREATOR_FK                                     */
/*==============================================================*/
create index RECIPE_CREATOR_FK on RECIPE (
   EMAIL ASC
)
/

/*==============================================================*/
/* Index: RECIPE_CATEGORY_FK                                    */
/*==============================================================*/
create index RECIPE_CATEGORY_FK on RECIPE (
   RECIPECATEGORYID ASC
)
/

/*==============================================================*/
/* Table: RECIPECATEGORY                                        */
/*==============================================================*/
create table RECIPECATEGORY (
   RECIPECATEGORYID     NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   MEALTYPE             NUMBER(1)             not null
      constraint CKC_MEALTYPE_RECIPECA check (MEALTYPE between 0 and 4 and MEALTYPE in (0,1,2,3,4)),
   FOODCATEGORY         NUMBER(1)             not null
      constraint CKC_FOODCATEGORY_RECIPECA check (FOODCATEGORY between 0 and 2 and FOODCATEGORY in (0,1,2)),
   constraint PK_RECIPECATEGORY primary key (RECIPECATEGORYID)
)
/

/*==============================================================*/
/* Table: RECIPEINGREDIENT                                      */
/*==============================================================*/
create table RECIPEINGREDIENT (
   RECIPEID             NUMBER(6)             not null,
   INGREDIENTNAME       VARCHAR2(64)          not null,
   RECIPEINGREDIENTID   NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   QUANTITY             NUMBER                not null,
   constraint PK_RECIPEINGREDIENT primary key (RECIPEID, INGREDIENTNAME, RECIPEINGREDIENTID)
)
/

/*==============================================================*/
/* Index: RECIPE_INGREDIENTS_FK                                 */
/*==============================================================*/
create index RECIPE_INGREDIENTS_FK on RECIPEINGREDIENT (
   RECIPEID ASC
)
/

/*==============================================================*/
/* Index: QUANTITY_OF_INGREDIENT_FK                             */
/*==============================================================*/
create index QUANTITY_OF_INGREDIENT_FK on RECIPEINGREDIENT (
   INGREDIENTNAME ASC
)
/

/*==============================================================*/
/* Table: RECIPE_APPOINTMENT                                    */
/*==============================================================*/
create table RECIPE_APPOINTMENT (
   RECIPEID             NUMBER(6)             not null,
   APPOINTMENTID        NUMBER(6)             not null,
   constraint PK_RECIPE_APPOINTMENT primary key (RECIPEID, APPOINTMENTID)
)
/

/*==============================================================*/
/* Index: RECIPE_APPOINTMENT_FK                                 */
/*==============================================================*/
create index RECIPE_APPOINTMENT_FK on RECIPE_APPOINTMENT (
   RECIPEID ASC
)
/

/*==============================================================*/
/* Index: RECIPE_APPOINTMENT2_FK                                */
/*==============================================================*/
create index RECIPE_APPOINTMENT2_FK on RECIPE_APPOINTMENT (
   APPOINTMENTID ASC
)
/

/*==============================================================*/
/* Table: SPORT                                                 */
/*==============================================================*/
create table SPORT (
   SPORTID              NUMBER(4)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 VARCHAR2(128)         not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   constraint PK_SPORT primary key (SPORTID)
)
/

/*==============================================================*/
/* Table: TRACK                                                 */
/*==============================================================*/
create table TRACK (
   EMAIL                VARCHAR2(128)         not null,
   TRACKID              NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   "DATE"               DATE                  not null,
   CALORIES             NUMBER(4)             not null,
   PROTEIN              NUMBER(3)             not null,
   FAT                  NUMBER(3)             not null,
   CARBONHYDRATES       NUMBER(3),
   constraint PK_TRACK primary key (EMAIL, TRACKID)
)
/

/*==============================================================*/
/* Index: USER_TRACK_FK                                         */
/*==============================================================*/
create index USER_TRACK_FK on TRACK (
   EMAIL ASC
)
/

/*==============================================================*/
/* Table: TRAININGPLAN                                          */
/*==============================================================*/
create table TRAININGPLAN (
   TRAININGPLANID       NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   EMPLOYEEID           NUMBER(3)             not null,
   SPORTID              NUMBER(4)             not null,
   NAME                 VARCHAR2(128)         not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   TRAININGPLANDIFFICULTY NUMBER(1)           
      constraint CKC_TRAININGPLANDIFFI_TRAINING check (TRAININGPLANDIFFICULTY is null or (TRAININGPLANDIFFICULTY between 0 and 2 and TRAININGPLANDIFFICULTY in (0,1,2))),
   constraint PK_TRAININGPLAN primary key (TRAININGPLANID)
)
/

/*==============================================================*/
/* Index: PLAN_CREATED_BY_FK                                    */
/*==============================================================*/
create index PLAN_CREATED_BY_FK on TRAININGPLAN (
   EMPLOYEEID ASC
)
/

/*==============================================================*/
/* Index: PLAN_SPORTART_FK                                      */
/*==============================================================*/
create index PLAN_SPORTART_FK on TRAININGPLAN (
   SPORTID ASC
)
/

/*==============================================================*/
/* Table: TRAININGUNIT                                          */
/*==============================================================*/
create table TRAININGUNIT (
   TRAININGUNITID       NUMBER(6)           
      generated as identity ( start with 1 nocycle noorder)  not null,
   NAME                 VARCHAR2(128)         not null,
   DESCRIPTION          VARCHAR2(1024)        not null,
   TRAININGUNITDIFFICULTY NUMBER(1)             not null
      constraint CKC_TRAININGUNITDIFFI_TRAINING check (TRAININGUNITDIFFICULTY between 0 and 2 and TRAININGUNITDIFFICULTY in (0,1,2)),
   constraint PK_TRAININGUNIT primary key (TRAININGUNITID)
)
/

/*==============================================================*/
/* Table: TRAINING_UNIT_UNIT                                    */
/*==============================================================*/
create table TRAINING_UNIT_UNIT (
   EXERCISEUNITID       NUMBER(6)             not null,
   TRAININGUNITID       NUMBER(6)             not null,
   constraint PK_TRAINING_UNIT_UNIT primary key (EXERCISEUNITID, TRAININGUNITID)
)
/

/*==============================================================*/
/* Index: TRAINING_UNIT_UNIT_FK                                 */
/*==============================================================*/
create index TRAINING_UNIT_UNIT_FK on TRAINING_UNIT_UNIT (
   EXERCISEUNITID ASC
)
/

/*==============================================================*/
/* Index: TRAINING_UNIT_UNIT2_FK                                */
/*==============================================================*/
create index TRAINING_UNIT_UNIT2_FK on TRAINING_UNIT_UNIT (
   TRAININGUNITID ASC
)
/

/*==============================================================*/
/* Table: "USER"                                                */
/*==============================================================*/
create table "USER" (
   EMAIL                VARCHAR2(128)         not null,
   EMPLOYEEID           NUMBER(3),
   FITNESSLEVELID       NUMBER(6),
   SALT                 VARCHAR2(10)          not null,
   FIRSTNAME            VARCHAR2(32)          not null,
   LASTNAME             VARCHAR2(32)          not null,
   WEIGHT               NUMBER(6,2),
   HEIGHT               NUMBER(6,2),
   BODYFATPERCENTAGE    NUMBER(3,1)         
      constraint CKC_BODYFATPERCENTAGE_USER check (BODYFATPERCENTAGE is null or (BODYFATPERCENTAGE between 0 and 100)),
   BASALMETABOLICRATE   NUMBER(6),
   PASSWORD             VARCHAR2(128),
   TARGETDESCRIPTION    VARCHAR2(1024),
   TARGETWEIGHT         NUMBER(5,2),
   constraint PK_USER primary key (EMAIL)
)
/

/*==============================================================*/
/* Index: IS_EMPLOYEE_FK                                        */
/*==============================================================*/
create index IS_EMPLOYEE_FK on "USER" (
   EMPLOYEEID ASC
)
/

/*==============================================================*/
/* Index: USER_FITNESS_LEVEL_FK                                 */
/*==============================================================*/
create index USER_FITNESS_LEVEL_FK on "USER" (
   FITNESSLEVELID ASC
)
/

/*==============================================================*/
/* Table: USER_APPOINTMENT                                      */
/*==============================================================*/
create table USER_APPOINTMENT (
   APPOINTMENTID        NUMBER(6)             not null,
   EMAIL                VARCHAR2(128)         not null,
   constraint PK_USER_APPOINTMENT primary key (APPOINTMENTID, EMAIL)
)
/

/*==============================================================*/
/* Index: USER_APPOINTMENT_FK                                   */
/*==============================================================*/
create index USER_APPOINTMENT_FK on USER_APPOINTMENT (
   APPOINTMENTID ASC
)
/

/*==============================================================*/
/* Index: USER_APPOINTMENT2_FK                                  */
/*==============================================================*/
create index USER_APPOINTMENT2_FK on USER_APPOINTMENT (
   EMAIL ASC
)
/

/*==============================================================*/
/* Table: USER_PLAN                                             */
/*==============================================================*/
create table USER_PLAN (
   TRAININGPLANID       NUMBER(6)             not null,
   EMAIL                VARCHAR2(128)         not null,
   constraint PK_USER_PLAN primary key (TRAININGPLANID, EMAIL)
)
/

/*==============================================================*/
/* Index: USER_PLAN_FK                                          */
/*==============================================================*/
create index USER_PLAN_FK on USER_PLAN (
   TRAININGPLANID ASC
)
/

/*==============================================================*/
/* Index: USER_PLAN2_FK                                         */
/*==============================================================*/
create index USER_PLAN2_FK on USER_PLAN (
   EMAIL ASC
)
/

/*==============================================================*/
/* Table: USER_SAVED_RECIPES                                    */
/*==============================================================*/
create table USER_SAVED_RECIPES (
   RECIPEID             NUMBER(6)             not null,
   EMAIL                VARCHAR2(128)         not null,
   constraint PK_USER_SAVED_RECIPES primary key (RECIPEID, EMAIL)
)
/

/*==============================================================*/
/* Index: USER_SAVED_RECIPES_FK                                 */
/*==============================================================*/
create index USER_SAVED_RECIPES_FK on USER_SAVED_RECIPES (
   RECIPEID ASC
)
/

/*==============================================================*/
/* Index: USER_SAVED_RECIPES2_FK                                */
/*==============================================================*/
create index USER_SAVED_RECIPES2_FK on USER_SAVED_RECIPES (
   EMAIL ASC
)
/

alter table APPOINTMENT
   add constraint FK_APPOINTM_TRAINING__TRAINING foreign key (TRAININGUNITID)
      references TRAININGUNIT (TRAININGUNITID)
/

alter table EMPLOYEE
   add constraint FK_EMPLOYEE_IS_EMPLOY_USER foreign key (EMAIL)
      references "USER" (EMAIL)
/

alter table EXERCISE
   add constraint FK_EXERCISE_SPORT_EXE_SPORT foreign key (SPORTID)
      references SPORT (SPORTID)
/

alter table EXERCISEUNIT
   add constraint FK_EXERCISE_UNIT_EXER_EXERCISE foreign key (EXERCISEID)
      references EXERCISE (EXERCISEID)
/

alter table INGREDIENT
   add constraint FK_INGREDIE_INGREDIEN_QUANTITY foreign key (QUA_INGREDIENTNAME, QUANTITYPRICEID)
      references QUANTITYPRICE (INGREDIENTNAME, QUANTITYPRICEID)
/

alter table MANAGES_SPORT
   add constraint FK_MANAGES__MANAGES_S_SPORT foreign key (SPORTID)
      references SPORT (SPORTID)
/

alter table MANAGES_SPORT
   add constraint FK_MANAGES__MANAGES_S_EMPLOYEE foreign key (EMPLOYEEID)
      references EMPLOYEE (EMPLOYEEID)
/

alter table PLANTRAININGUNIT
   add constraint FK_PLANTRAI_PLAN_UNIT_TRAINING foreign key (TRAININGPLANID)
      references TRAININGPLAN (TRAININGPLANID)
/

alter table PLAN_UNIT_UNIT
   add constraint FK_PLAN_UNI_PLAN_UNIT_PLANTRAI foreign key (TRAININGPLANID, PLANTRAININGUNITID)
      references PLANTRAININGUNIT (TRAININGPLANID, PLANTRAININGUNITID)
/

alter table PLAN_UNIT_UNIT
   add constraint FK_PLAN_UNI_PLAN_UNIT_TRAINING foreign key (TRAININGUNITID)
      references TRAININGUNIT (TRAININGUNITID)
/

alter table QUANTITYPRICE
   add constraint FK_QUANTITY_INGREDIEN_INGREDIE foreign key (INGREDIENTNAME)
      references INGREDIENT (INGREDIENTNAME)
/

alter table RECIPE
   add constraint FK_RECIPE_RECIPE_CA_RECIPECA foreign key (RECIPECATEGORYID)
      references RECIPECATEGORY (RECIPECATEGORYID)
/

alter table RECIPE
   add constraint FK_RECIPE_RECIPE_CR_USER foreign key (EMAIL)
      references "USER" (EMAIL)
/

alter table RECIPEINGREDIENT
   add constraint FK_RECIPEIN_QUANTITY__INGREDIE foreign key (INGREDIENTNAME)
      references INGREDIENT (INGREDIENTNAME)
/

alter table RECIPEINGREDIENT
   add constraint FK_RECIPEIN_RECIPE_IN_RECIPE foreign key (RECIPEID)
      references RECIPE (RECIPEID)
/

alter table RECIPE_APPOINTMENT
   add constraint FK_RECIPE_A_RECIPE_AP_RECIPE foreign key (RECIPEID)
      references RECIPE (RECIPEID)
/

alter table RECIPE_APPOINTMENT
   add constraint FK_RECIPE_A_RECIPE_AP_APPOINTM foreign key (APPOINTMENTID)
      references APPOINTMENT (APPOINTMENTID)
/

alter table TRACK
   add constraint FK_TRACK_USER_TRAC_USER foreign key (EMAIL)
      references "USER" (EMAIL)
/

alter table TRAININGPLAN
   add constraint FK_TRAINING_PLAN_CREA_EMPLOYEE foreign key (EMPLOYEEID)
      references EMPLOYEE (EMPLOYEEID)
/

alter table TRAININGPLAN
   add constraint FK_TRAINING_PLAN_SPOR_SPORT foreign key (SPORTID)
      references SPORT (SPORTID)
/

alter table TRAINING_UNIT_UNIT
   add constraint FK_TRAINING_TRAINING__EXERCISE foreign key (EXERCISEUNITID)
      references EXERCISEUNIT (EXERCISEUNITID)
/

alter table TRAINING_UNIT_UNIT
   add constraint FK_TRAINING_TRAINING__TRAINING foreign key (TRAININGUNITID)
      references TRAININGUNIT (TRAININGUNITID)
/

alter table "USER"
   add constraint FK_USER_IS_EMPLOY_EMPLOYEE foreign key (EMPLOYEEID)
      references EMPLOYEE (EMPLOYEEID)
/

alter table "USER"
   add constraint FK_USER_USER_FITN_FITNESSL foreign key (FITNESSLEVELID)
      references FITNESSLEVEL (FITNESSLEVELID)
/

alter table USER_APPOINTMENT
   add constraint FK_USER_APP_USER_APPO_APPOINTM foreign key (APPOINTMENTID)
      references APPOINTMENT (APPOINTMENTID)
/

alter table USER_APPOINTMENT
   add constraint FK_USER_APP_USER_APPO_USER foreign key (EMAIL)
      references "USER" (EMAIL)
/

alter table USER_PLAN
   add constraint FK_USER_PLA_USER_PLAN_TRAINING foreign key (TRAININGPLANID)
      references TRAININGPLAN (TRAININGPLANID)
/

alter table USER_PLAN
   add constraint FK_USER_PLA_USER_PLAN_USER foreign key (EMAIL)
      references "USER" (EMAIL)
/

alter table USER_SAVED_RECIPES
   add constraint FK_USER_SAV_USER_SAVE_RECIPE foreign key (RECIPEID)
      references RECIPE (RECIPEID)
/

alter table USER_SAVED_RECIPES
   add constraint FK_USER_SAV_USER_SAVE_USER foreign key (EMAIL)
      references "USER" (EMAIL)
/


create or replace function GENERATESALT
RETURN VARCHAR2
IS
  SALT VARCHAR2(10);
BEGIN
  SELECT DBMS_RANDOM.STRING('X', 10) INTO SALT FROM DUAL;
  RETURN SALT;
END GENERATESALT;
/

create or replace procedure INSERTINGREDIENT(P_INGREDIENTNAME IN VARCHAR2,P_FOODCATEGORY IN NUMBER,P_CALORIES IN NUMBER,P_PROTEIN IN NUMBER,P_FAT IN NUMBER,P_CARBOHYDRATES IN NUMBER,P_QUANTITYUNIT IN NUMBER,P_PRICELOWER IN NUMBER,P_PRICEUPPER IN NUMBER,P_NEWINGREDIENTID OUT NUMBER)
AS
   v_QuantityPriceID NUMBER;

BEGIN
   -- Insert into QUANTITYPRICE
   INSERT INTO QUANTITYPRICE (INGREDIENTNAME, QUANTITYUNIT, PRICELOWER, PRICEUPPER)
   VALUES (p_IngredientName, p_QuantityUnit, p_PriceLower, p_PriceUpper)
   RETURNING QUANTITYPRICEID INTO v_QuantityPriceID;

   -- Insert into INGREDIENT
   INSERT INTO INGREDIENT (INGREDIENTNAME, QUA_INGREDIENTNAME, QUANTITYPRICEID, FOODCATEGORY, CALORIES, PROTEIN, FAT, CARBONHYDRATES)
   VALUES (p_IngredientName, p_IngredientName, v_QuantityPriceID, p_FoodCategory, p_Calories, p_Protein, p_Fat, p_Carbohydrates)
   RETURNING QUANTITYPRICEID INTO p_NewIngredientID;

   COMMIT; -- Commit the transaction
END;
/
