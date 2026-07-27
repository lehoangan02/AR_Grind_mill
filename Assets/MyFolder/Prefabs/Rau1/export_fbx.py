import bpy
import os

# Get the directory of the current blend file
blend_dir = os.path.dirname(bpy.data.filepath)
if not blend_dir:
    blend_dir = os.getcwd()

# Define texture paths
tex_dir = os.path.join(blend_dir, "Textures")
base_color_path = os.path.join(tex_dir, "fresh-mint-leaf-2.png")
opacity_path = os.path.join(tex_dir, "fresh-mint-leaf-2 - Opacity.jpg")

# Go through all materials in the scene
for mat in bpy.data.materials:
    mat.use_nodes = True
    nodes = mat.node_tree.nodes
    links = mat.node_tree.links
    
    # Find the Principled BSDF node
    bsdf = None
    for node in nodes:
        if node.type == 'BSDF_PRINCIPLED':
            bsdf = node
            break
            
    if not bsdf:
        bsdf = nodes.new(type='ShaderNodeBsdfPrincipled')
        
    # Load and assign the Base Color texture
    if os.path.exists(base_color_path):
        tex_node = nodes.new('ShaderNodeTexImage')
        tex_node.image = bpy.data.images.load(base_color_path)
        # Link texture color to BSDF Base Color
        links.new(tex_node.outputs['Color'], bsdf.inputs['Base Color'])
        # Link texture alpha to BSDF Alpha if needed (since it's a PNG, it might have alpha)
        links.new(tex_node.outputs['Alpha'], bsdf.inputs['Alpha'])
        
    # Set the blend mode to Alpha Clip or Alpha Blend for transparency to work in Eevee/FBX export
    mat.blend_method = 'CLIP'

# Export as FBX with embedded textures
export_path = os.path.join(blend_dir, "Vegetable.fbx")
bpy.ops.export_scene.fbx(
    filepath=export_path,
    use_selection=False,
    path_mode='COPY',
    embed_textures=True
)

print("Export completed successfully to:", export_path)
