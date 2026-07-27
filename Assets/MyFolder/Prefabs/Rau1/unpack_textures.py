import bpy
import os

blend_dir = os.path.dirname(bpy.data.filepath)
if not blend_dir:
    blend_dir = os.getcwd()

tex_dir = os.path.join(blend_dir, "Textures")
os.makedirs(tex_dir, exist_ok=True)

for img in bpy.data.images:
    if img.packed_file:
        # Construct a path for the image
        img_name = img.name
        if not img_name.endswith('.png') and not img_name.endswith('.jpg'):
            img_name += '.png'
            
        save_path = os.path.join(tex_dir, img_name)
        img.filepath_raw = save_path
        img.save()
        print(f"Unpacked {img.name} to {save_path}")
