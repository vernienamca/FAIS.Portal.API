ALTER TABLE ASSET_PROFILES
DROP CONSTRAINT SYS_C007656;

ALTER TABLE ASSET_PROFILES 
MODIFY (RCA_GL_SEQ VARCHAR2(250));
