def getLCIndes(List:list):
    for x in range(len(List)):
        String = List[x]
        if String == 'Lethal Company':
            return x
    return -1

def writeLog(Message:str):
    with open("log.txt", 'w') as f:
        f.write(Message)

def getLCPath(List:list):
    LCindex = getLCIndes(List)
    if LCindex == -1:
        writeLog('Modloader not installed in LC Directory')
    new_List = []
    for x in range(len(List)):
        if x <= LCindex:
             new_List.append(List[x])
        else:
            return new_List