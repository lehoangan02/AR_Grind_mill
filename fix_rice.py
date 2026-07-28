import re
import random

prefab_path = "/Volumes/Baracuda/Unity/AR_Grind_mill/Assets/MyFolder/Prefabs/rice_plant/RicePlant/RicePlant.prefab"

with open(prefab_path, 'r') as f:
    content = f.read()

# Find all MeshRenderers
renderer_ids = re.findall(r'--- !u!23 &(\d+)', content)

# Find root GameObject
root_go_match = re.search(r'--- !u!1 &(\d+)\nGameObject:(?:.*?\n)*?  m_Name: RicePlant', content, re.MULTILINE)
if not root_go_match:
    print("Could not find root GameObject")
    exit(1)

root_go_id = root_go_match.group(1)

# Find the end of m_Component list for root GameObject
m_component_match = re.search(r'(--- !u!1 &' + root_go_id + r'\nGameObject:(?:.*?\n)*?  m_Component:\n(?:  - component: \{fileID: \d+\}\n)+)', content, re.MULTILINE)
if not m_component_match:
    print("Could not find m_Component list")
    exit(1)

new_lod_group_id = str(random.randint(100000000000000000, 999999999999999999))

new_component_line = f"  - component: {{fileID: {new_lod_group_id}}}\n"

# insert new component line
content = content[:m_component_match.end()] + new_component_line + content[m_component_match.end():]

# append LODGroup object
lod_group_yaml = f"""--- !u!205 &{new_lod_group_id}
LODGroup:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {{fileID: 0}}
  m_PrefabInstance: {{fileID: 0}}
  m_PrefabAsset: {{fileID: 0}}
  m_GameObject: {{fileID: {root_go_id}}}
  serializedVersion: 2
  m_LocalReferencePoint: {{x: 0, y: 0, z: 0}}
  m_Size: 1
  m_FadeMode: 0
  m_AnimateCrossFading: 0
  m_LastLODIsBillboard: 0
  m_LODs:
  - screenRelativeHeight: 0.01
    fadeTransitionWidth: 0
    renderers:
"""
for r_id in renderer_ids:
    lod_group_yaml += f"    - renderer: {{fileID: {r_id}}}\n"

lod_group_yaml += "  m_Enabled: 1\n"

content += lod_group_yaml

with open(prefab_path, 'w') as f:
    f.write(content)

print("Added LODGroup to RicePlant.prefab")
