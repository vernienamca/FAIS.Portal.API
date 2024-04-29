--------------------------------------------------------
--  File created - Monday-April-29-2024   
--------------------------------------------------------
DROP TABLE "FAIS"."TEMPLATES" cascade constraints;
DROP TABLE "FAIS"."TEMPLATES" cascade constraints;
--------------------------------------------------------
--  DDL for Table TEMPLATES
--------------------------------------------------------

  CREATE TABLE "FAIS"."TEMPLATES" 
   (	"TEMPLATE_SEQ" NUMBER(*,0), 
	"SUBJECT" VARCHAR2(250 BYTE), 
	"CONTENT" VARCHAR2(500 BYTE), 
	"NOTIFICATION_TYPE" NUMBER, 
	"IS_ACTIVE" CHAR(1 BYTE), 
	"STATUS_DATE" DATE, 
	"USER_CREATED" NUMBER(*,0), 
	"DATE_CREATED" DATE DEFAULT systimestamp, 
	"USER_MODIFIED" NUMBER, 
	"DATE_MODIFIED" DATE, 
	"USERS" VARCHAR2(250 BYTE), 
	"ROLES" VARCHAR2(250 BYTE), 
	"ICON" VARCHAR2(250 BYTE), 
	"ICON_COLOR" NUMBER, 
	"START_DATE" DATE, 
	"START_TIME" VARCHAR2(250 BYTE), 
	"END_DATE" DATE, 
	"END_TIME" VARCHAR2(250 BYTE), 
	"TARGET" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table TEMPLATES
--------------------------------------------------------

  CREATE TABLE "FAIS"."TEMPLATES" 
   (	"TEMPLATE_SEQ" NUMBER(*,0), 
	"SUBJECT" VARCHAR2(250 BYTE), 
	"CONTENT" VARCHAR2(500 BYTE), 
	"NOTIFICATION_TYPE" NUMBER, 
	"IS_ACTIVE" CHAR(1 BYTE), 
	"STATUS_DATE" DATE, 
	"USER_CREATED" NUMBER(*,0), 
	"DATE_CREATED" DATE DEFAULT systimestamp, 
	"USER_MODIFIED" NUMBER, 
	"DATE_MODIFIED" DATE, 
	"USERS" VARCHAR2(250 BYTE), 
	"ROLES" VARCHAR2(250 BYTE), 
	"ICON" VARCHAR2(250 BYTE), 
	"ICON_COLOR" NUMBER, 
	"START_DATE" DATE, 
	"START_TIME" VARCHAR2(250 BYTE), 
	"END_DATE" DATE, 
	"END_TIME" VARCHAR2(250 BYTE), 
	"TARGET" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
REM INSERTING into FAIS.TEMPLATES
SET DEFINE OFF;
--------------------------------------------------------
--  DDL for Index TEMPLATES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "FAIS"."TEMPLATES_PK" ON "FAIS"."TEMPLATES" ("TEMPLATE_SEQ") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Trigger TEMPLATES_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "FAIS"."TEMPLATES_TRG" 
BEFORE INSERT ON TEMPLATES 
FOR EACH ROW
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    NULL;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "FAIS"."TEMPLATES_TRG" ENABLE;
--------------------------------------------------------
--  Constraints for Table TEMPLATES
--------------------------------------------------------

  ALTER TABLE "FAIS"."TEMPLATES" ADD CONSTRAINT "TEMPLATES_PK" PRIMARY KEY ("TEMPLATE_SEQ")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "FAIS"."TEMPLATES" MODIFY ("DATE_CREATED" NOT NULL ENABLE);
  ALTER TABLE "FAIS"."TEMPLATES" MODIFY ("USER_CREATED" NOT NULL ENABLE);
  ALTER TABLE "FAIS"."TEMPLATES" MODIFY ("IS_ACTIVE" NOT NULL ENABLE);
  ALTER TABLE "FAIS"."TEMPLATES" MODIFY ("TEMPLATE_SEQ" NOT NULL ENABLE);
