using UnityEngine;

namespace Khoa.Farming.Boating
{
    /// <summary>
    /// Bộ phím giả lập cho Editor và Developer khi thử nghiệm cơ chế chèo xuồng ba lá:
    /// - W / S: Chèo tiến / lùi đối xứng
    /// - A / D: Chèo lệch để quay trái / phải
    /// - F: Lên / xuống xuồng
    /// </summary>
    [DisallowMultipleComponent]
    public class SampanDevInput : MonoBehaviour
    {
        public SampanPhysics sampan;
        public SampanOar leftOar;
        public SampanOar rightOar;
        public SampanSeat seat;

        public float simulatedStrokeSpeed = 2.2f;

        private void Start()
        {
            if (sampan == null) sampan = GetComponent<SampanPhysics>();
            if (seat == null) seat = GetComponentInChildren<SampanSeat>();

            if (leftOar == null || rightOar == null)
            {
                SampanOar[] oars = GetComponentsInChildren<SampanOar>();
                foreach (var o in oars)
                {
                    if (o.side == OarSide.Left) leftOar = o;
                    if (o.side == OarSide.Right) rightOar = o;
                }
            }
        }

        private void Update()
        {
            if (!Application.isEditor) return;

            // F: Lên / Xuống xuồng
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (seat != null)
                {
                    if (!seat.IsSeated) seat.Mount(null);
                    else seat.Dismount();
                }
            }

            // Chỉ xử lý chèo phím khi đang ngồi trên xuồng hoặc đang test
            bool canRow = (seat == null || seat.IsSeated || Input.GetKey(KeyCode.LeftShift));
            if (!canRow) return;

            // W: Chèo tiến đối xứng (cả 2 mái chèo quét về sau)
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 strokeVel = -transform.forward * simulatedStrokeSpeed;
                if (leftOar != null) leftOar.SimulateStroke(strokeVel);
                if (rightOar != null) rightOar.SimulateStroke(strokeVel);
            }
            // S: Chèo lùi
            else if (Input.GetKey(KeyCode.S))
            {
                Vector3 strokeVel = transform.forward * simulatedStrokeSpeed;
                if (leftOar != null) leftOar.SimulateStroke(strokeVel);
                if (rightOar != null) rightOar.SimulateStroke(strokeVel);
            }

            // A: Quay trái (Chèo mái bên phải về sau)
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 strokeVel = -transform.forward * simulatedStrokeSpeed;
                if (rightOar != null) rightOar.SimulateStroke(strokeVel);
            }
            // D: Quay phải (Chèo mái bên trái về sau)
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 strokeVel = -transform.forward * simulatedStrokeSpeed;
                if (leftOar != null) leftOar.SimulateStroke(strokeVel);
            }
        }
    }
}
