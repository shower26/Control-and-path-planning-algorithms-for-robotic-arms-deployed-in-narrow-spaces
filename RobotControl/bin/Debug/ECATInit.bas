
'*******************************************************ECAT���߳�ʼ��
global CONST BUS_TYPE = 0				 '�������͡���������λ�����ֵ�ǰ��������
global CONST Bus_Slot	= 0				'��λ��0�������߿�����ȱʡ0��
global CONST PUL_AxisStart	 = 0		'������������ʼ���
global CONST PUL_AxisNum	 = 0		'����������������
global CONST Bus_AxisStart	 = 0	    '��������ʼ���
global CONST Bus_NodeNum	 = 1	    '�������ýڵ�����,�����ж�ʵ�ʼ�⵽�Ĵ�վ�����Ƿ�һ��

global  MAX_AXISNUM 			 '�������
MAX_AXISNUM = SYS_ZFEATURE(0)

global Bus_InitStatus			'���߳�ʼ�����״̬
Bus_InitStatus = -1
global  Bus_TotalAxisnum		'���ɨ���������

delay(3000)				'��ʱ3S�ȴ��������ϵ磬��ͬ�����������ϵ�ʱ�䲻ͬ���������������������ʱ

?"����ͨѶ���ڣ�",SERVO_PERIOD,"us"
Ecat_Init()			'��ʼ��ECAT���� 

end
'***************************************************ECAT���߳�ʼ****************************************
'��ʼ����:  slot_scan��ɨ�����ߣ� ->   ��վ�ڵ�ӳ����/io  ->  SLOT_START���������ߣ� -> ��ʼ���ɹ�
'******************************************************************************************************
global sub Ecat_Init()
	local Node_Num,Temp_Axis,Drive_Vender,Drive_Device,Drive_Alias
	RAPIDSTOP(2)
	for i=0 to MAX_AXISNUM - 1								'��ʼ����ԭ������					
		AXIS_ENABLE(i) = 0
		atype(i)=0	
		DELAY(20)
	next

	Bus_InitStatus = -1
	Bus_TotalAxisnum = 0	
	SLOT_STOP(Bus_Slot)				
	delay(200)
	slot_scan(Bus_Slot)											'ɨ������
	if return then 
		?"����ɨ��ɹ�","���Ӵ�վ�豸����"NODE_COUNT(Bus_Slot)
		if NODE_COUNT(Bus_Slot) <> Bus_NodeNum then		'�ж����߼�������Ƿ�Ϊʵ�ʽ�������
			?""	
			?"ɨ��ڵ��������������������һ��!" ,"��������:"Bus_NodeNum,"���������"NODE_COUNT(Bus_Slot)
			Bus_InitStatus = 0		'��ʼ��ʧ�ܡ�������ʾ
			'return
		endif 	
		
		'"��ʼӳ�����"
		for Node_Num=0 to NODE_COUNT(Bus_Slot)-1						'����ɨ�赽�����д�վ�ڵ�
			Drive_Vender = NODE_INFO(Bus_Slot,Node_Num,0)				'��ȡ����������
			Drive_Device = NODE_INFO(Bus_Slot,Node_Num,1)				'��ȡ�豸���
			Drive_Alias = NODE_INFO(Bus_Slot,Node_Num,3)					'��ȡ�豸����ID
			
			if NODE_AXIS_COUNT(Bus_Slot,Node_Num) <> 0 then			'�жϵ�ǰ�ڵ��Ƿ��е��
				for j=0 to NODE_AXIS_COUNT(Bus_Slot,Node_Num)-1		'���ݽڵ���ĵ������ѭ�����������(���һ�϶�������)
				
					Temp_Axis = Bus_AxisStart + Bus_TotalAxisnum		'��Ű�NODE˳�����
					'Temp_Axis = Dirve_Alias							'��Ű��������趨�Ĳ�����䣨һ�϶���Ҫ���⴦��					
					base(Temp_Axis)
					AXIS_ADDRESS=Bus_TotalAxisnum+1					'ӳ�����
					ATYPE=65											'���ÿ���ģʽ 65-λ�� 66-�ٶ� 67-ת�� 

					Sub_SetPdo(Node_Num,Drive_Vender,Drive_Device)	'�趨PDO����
					Sub_SetDriverIo(Temp_Axis,Drive_Vender,32 + 32*Temp_Axis)		'ӳ��������IO  IOӳ�䵽������IO32-�Ժ�ÿ�����������32��			
					Sub_SetNodePara(Node_Num,Drive_Vender,Drive_Device)	'�����������߲���
					disable_group(Temp_Axis)							'ÿ�ᵥ������
					Bus_TotalAxisnum=Bus_TotalAxisnum+1					'������+1
				next
			else														'IO��չģ��
				'����ͨ��NODE_IN(Bus_Slot,Node_Num)����ģ��IO��ʼ��ַ
			endif
		next
		?"���ӳ�����","������������"Bus_TotalAxisnum
		
		wa 200
		SLOT_START(Bus_Slot)				'��������
		if return then 
			
			wdog=1							'ʹ���ܿ���
			
			'?"��ʼ�������������"
			for i= Bus_AxisStart to Bus_AxisStart + Bus_TotalAxisnum - 1 
				BASE(i)
				DRIVE_CLEAR(0)
				DELAY 50
	
				'?"����������������"
				datum(0)						'�����������״̬����"
				wa 100	
				
				'"��ʹ��"
				AXIS_ENABLE=1
			next
			Bus_InitStatus  = 1
			?"��ʹ�����"
			
			'��������������
			for i = 0 to PUL_AxisNum - 1
				base(PUL_AxisStart + i)
				AXIS_ADDRESS  = (-1<<16) + i
				ATYPE = 4
			next
			?"���߿����ɹ�"			
		else
			?"���߿���ʧ��"
			Bus_InitStatus = 0
		endif	
	else
		?"����ɨ��ʧ��"
		Bus_InitStatus = 0
	endif

end sub

'***************************************************��վ�ڵ������������********************************
'ͨ��SDO��ʽ�޸Ķ�Ӧ�����ֵ��ֵ�޸Ĵ�վ����(��������ֵ�鿴�������ֲ�)
'******************************************************************************************************
global sub Sub_SetNodePara(iNode,iVender,iDevice)
	if	iVender = $41B and iDevice = $1ab0	 then		'���˶�24088������չ��
		SDO_WRITE(Bus_Slot,iNode,$6011,j*$800,5,4)			'������չ������ATYPE����
		SDO_WRITE(Bus_Slot,iNode,$6012,j*$800,6,0)			'������չ������INVERT_STEP�������ģʽ
		NODE_IO(Bus_Slot,iNode) = 32 + 32*iNode				'����240808��IO����ʼӳ���ַ				
	elseif iVender = $66f then							'����������
		SDO_WRITE(Bus_Slot,iNode,$3741,0,3,0)						'�Բ���ΪID
		SDO_WRITE(Bus_Slot,iNode,$3401,0,4,$10101)				'����λ��ƽ $818181
		SDO_WRITE(Bus_Slot,iNode,$3402,0,4,$20202)				'����λ��ƽ $828282
		
		SDO_WRITE(Bus_Slot,iNode,$6091,1,7,1)						'���ֱ�
		SDO_WRITE(Bus_Slot,iNode,$6091,2,7,1)	
		SDO_WRITE(Bus_Slot,iNode,$6092,1,7,10000)					'���һȦ������
		SDO_WRITE(Bus_Slot,iNode,$607E,0,5,224)					'�������0  ��ת224 	
		SDO_WRITE(Bus_Slot,iNode,$6085,0,7,4290000000)			'�쳣���ٶ�
		'SDO_WRITE(Bus_Slot,iNode,$1010,1,7,$65766173)				'дEPPROM(дEPPROM����������Ҫ�����ϵ�)
		'?"дEPPR0M OK ��ϵ�����"		
	elseif iVender = $100000 then							'�㴨������
		SDO_WRITE(Bus_Slot,iNode,$6091,1,7,1)					'���ֱ�
		SDO_WRITE(Bus_Slot,iNode,$6091,2,7,1)	
	endif
end sub

'***************************************************��������IOӳ��**************************************
'ͨ��DRIVE_IOָ��ӳ�������������ֵ���60FD,60FE�������״̬��Ҫ������ȷ��DRIVE_PROFILEE����POD��ſ�������ӳ��
'DRIVE_PROFILEģʽ����60FD/60FE
'iAxis - ���  iVender - ����������  i_IoNum - ���������ʼ���
'******************************************************************************************************
global sub Sub_SetDriverIo(iAxis,iVender,i_IoNum)
	if	iVender = $66f then		'����������
		DRIVE_PROFILE(iAxis) = 35			'�趨��Ӧ�Ĵ�IOӳ���PDOģʽ
		DRIVE_IO(iAxis) = i_IoNum
	elseif  iVender = $41B  then			'���˶�24088������չ��
		DRIVE_PROFILE(iAxis) = 0		
	else
		DRIVE_PROFILE(iAxis) = 30			
		DRIVE_IO(iAxis) = i_IoNum	
	endif

end sub

'***************************************************�ֶ�����PDO****************************************
'��������Ʒ�ƿ�����Ҫ�ֶ����ã��󲿷�ֻ��Ҫͨ��DRIVE_PROFILE�����Զ�������Ӧ��POD��������
'******************************************************************************************************
global sub Sub_SetPdo(iNode,iVender,iDevice)
	if iVender = $147 then											'�¹���������			
		SDO_WRITE (Bus_Slot, iNode, $1c12, 0 ,5 ,0)					'����PDO,���ú�ſ����޸�����
		wa(50)
		SDO_WRITE (Bus_Slot, iNode, $1c13, 0 ,5 ,0)
		wa(50)

		SDO_WRITE (Bus_Slot, iNode, $1600, $0 ,5 ,0)					'RxPDO ���ö�Ӧ����
		SDO_WRITE (Bus_Slot, iNode, $1600, $1 ,7 ,$60400010)			'������
		SDO_WRITE (Bus_Slot, iNode, $1600, $2 ,7 ,$607a0020)			'Ŀ��λ��
		SDO_WRITE (Bus_Slot, iNode, $1600, $3 ,7 ,$60fe0120)			'������IO����
		SDO_WRITE (Bus_Slot, iNode, $1600, $0 ,5 ,3)
		
		SDO_WRITE (Bus_Slot, iNode, $1a00, $0 ,5 ,0)					'TxPDO 
		SDO_WRITE (Bus_Slot, iNode, $1a00, $1 ,7 ,$60410010)			'״̬��
		SDO_WRITE (Bus_Slot, iNode, $1a00, $2 ,7 ,$60640020)			'����λ��
		SDO_WRITE (Bus_Slot, iNode, $1a00, $3 ,7 ,$60fd0020)			'������IO���
		SDO_WRITE (Bus_Slot, iNode, $1a00, $0 ,5 ,3)		

		SDO_WRITE (Bus_Slot, iNode, $1c12, 1 ,6 ,$1600)				'pdo�������			
		wa(50)
		SDO_WRITE (Bus_Slot, iNode, $1c13, 1 ,6 ,$1a00)				'
		wa(50)
		SDO_WRITE (Bus_Slot, iNode, $1c12, 0 ,5 ,1)					'����PDO
		wa(50)
		SDO_WRITE (Bus_Slot, iNode, $1c13, 0 ,5 ,1)

		SDO_WRITE (Bus_Slot, iNode, $1C32, $1 ,6 ,2)					'����DCͬ��ģʽ
		SDO_WRITE (Bus_Slot, iNode, $1C33, $1 ,6 ,2)
		
		DRIVE_PROFILE = -1												'ʹ������ȱʡPDO����
	else
		DRIVE_PROFILE = 30												'ʹ�ÿ�����ģʽ0����											
	endif
end sub


