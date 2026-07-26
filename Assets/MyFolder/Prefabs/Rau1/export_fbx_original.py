import bpy
import os

blend_dir = os.path.dirname(bpy.data.filepath)
if not blend_dir:
    blend_dir = os.getcwd()

# Just export the scene as FBX, relying entirely on the materials already set up in the .blend file.
# path_mode 'COPY' + embed_textures packs any images currently assigned in the nodes into the FBX.
export_path = os.path.join(blend_dir, "Vegetable_Original.fbx")
bpy.ops.export_scene.fbx(
    filepath=export_path,
    use_selection=False,
    path_mode='COPY',
    embed_textures=True
)
print("Export completed successfully to:", export_path)
