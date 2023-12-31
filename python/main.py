import terminal as ter
import os.path
import os
import pathlib as p
from extra_funcs import *
import shutil

Terminal = ter.terminal.Terminal_commands({})
com = {
    "Path_Belphin" : '',
    "Path_Mods" : ''
}
def setup():
    if (not os.path.isdir('Mods')):
        os.makedirs('Mods')
    cwd = os.getcwd()
    path_list = cwd.split('\\')

    #setup Path to the Plugins
    path_list_B = getLCPath(path_list)
    path_list_B.append('BepInEx')
    path_list_B.append('plugins')
    path_list_B = '\\'.join(path_list_B)
    com['Path_Belphin'] = path_list_B


    path_list.append('Mods')
    com['Path_Mods'] = '\\'.join(path_list)


#define commands
def vanilla():
    replace_all_in_dir_to_dir(com['Path_Belphin'], com['Path_Mods'])

def modded():
    replace_all_in_dir_to_dir(com['Path_Mods'], com['Path_Belphin'])

def replace_all_in_dir_to_dir(From:str, To:str):
    Files = os.listdir(From)
    for File in Files:
        From_PATH = rf'{From}\{File}'.replace('\\', f"/")
        To_PATH = rf'{To}\{File}'.replace('\\', f"/")
        os.replace(From_PATH, To_PATH)


#setup commands


#run
if __name__ == '__main__':
    setup()
    if os.listdir(com['Path_Mods']) == []:
        vanilla()
    else:
        modded()
